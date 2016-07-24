using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;

namespace ReMotion
{
    public enum TweenStatus : byte
    {
        /// <summary>Stopped, Tween is not queued.</summary>
        Stopped,
        /// <summary>Tween is queued and runnning.</summary>
        Running,
        /// <summary>Tween is queued and pausing.</summary>
        Pausing,
        /// <summary>Queued stop command.</summary>
        WaitingToStop
    }

    public interface ITween
    {
        // passed value is `ref` but must not rewrite values.
        bool MoveNext(ref float deltaTime, ref float unscaledDeltaTime);
    }

    public abstract class Tween<TObject, TProperty> : ITween
        where TObject : class
    {
        public TweenSettings Settings { get; private set; }
        public TweenStatus Status { get; private set; }

        readonly TObject target;
        readonly TweenGetter<TObject, TProperty> getter;
        readonly TweenSetter<TObject, TProperty> setter;
        readonly EasingFunction easingFunction;
        readonly float duration;
        readonly bool isRelativeTo;

        TProperty from;
        TProperty to;
        TProperty difference;

        TProperty originalFrom;
        TProperty originalTo;

        Subject<Unit> completedEvent;
        float delayTime;
        float currentTime;
        int repeatCount;

        public Tween(TweenSettings settings, TObject target, TweenGetter<TObject, TProperty> getter, TweenSetter<TObject, TProperty> setter, EasingFunction easingFunction, float duration, TProperty to, bool isRelativeTo)
        {
            this.Settings = settings;
            this.target = target;
            this.getter = getter;
            this.setter = setter;
            this.duration = duration;
            this.easingFunction = easingFunction;
            this.originalTo = to;
            this.isRelativeTo = isRelativeTo;
        }

        public void Reset()
        {
            this.from = originalFrom;
            if (isRelativeTo)
            {
                this.to = AddOperator(from, originalTo);
            }
            else
            {
                this.to = originalTo;
            }

            this.difference = GetDifference(from, to);
            this.currentTime = 0;
            this.repeatCount = 0;
        }

        public Tween<TObject, TProperty> Start()
        {
            this.originalFrom = getter(target);
            this.delayTime = 0;

            StartCore();
            return this;
        }


        public Tween<TObject, TProperty> Start(TProperty from, float delay)
        {
            this.originalFrom = from;
            if (delay <= 0) delay = 0;
            this.delayTime = delay;

            StartCore();
            return this;
        }

        public Tween<TObject, TProperty> Start(TProperty from, float delay, bool isRelativeFrom)
        {
            this.originalFrom = (isRelativeFrom)
                ? AddOperator(getter(target), from)
                : from;
            if (delay <= 0) delay = 0;
            this.delayTime = delay;

            StartCore();
            return this;
        }


        public Tween<TObject, TProperty> StartFrom(TProperty from)
        {
            this.originalFrom = from;
            this.delayTime = 0;

            StartCore();
            return this;
        }

        public Tween<TObject, TProperty> StartFromRelative(TProperty from)
        {
            this.originalFrom = AddOperator(getter(target), from);
            this.delayTime = 0;

            StartCore();
            return this;
        }

        public Tween<TObject, TProperty> StartAfter(float delay)
        {
            this.originalFrom = getter(target);
            if (delay <= 0) delay = 0;
            this.delayTime = delay;

            StartCore();
            return this;
        }

        void StartCore()
        {
            Reset();
            switch (this.Status)
            {
                case TweenStatus.Stopped:
                    this.Status = TweenStatus.Running;
                    TweenEngine.Instance.Add(this);
                    break;
                case TweenStatus.Running:
                case TweenStatus.Pausing:
                case TweenStatus.WaitingToStop:
                default:
                    Status = TweenStatus.Running;
                    break;
            }
        }

        public void Stop()
        {
            switch (this.Status)
            {
                case TweenStatus.Stopped:
                    break;
                case TweenStatus.Running:
                case TweenStatus.Pausing:
                case TweenStatus.WaitingToStop:
                default:
                    Status = TweenStatus.WaitingToStop;
                    break;
            }
        }

        public void Pause()
        {
            switch (this.Status)
            {
                case TweenStatus.Running:
                case TweenStatus.WaitingToStop:
                    Status = TweenStatus.Pausing;
                    break;
                case TweenStatus.Pausing:
                case TweenStatus.Stopped:
                default:
                    break;
            }
        }

        public void Resume()
        {
            switch (this.Status)
            {
                case TweenStatus.Pausing:
                    Status = TweenStatus.Running;
                    break;
                case TweenStatus.Stopped:
                case TweenStatus.Running:
                case TweenStatus.WaitingToStop:
                default:
                    break;
            }
        }

        public void PauseOrResume()
        {
            switch (this.Status)
            {
                case TweenStatus.Pausing:
                    Status = TweenStatus.Running;
                    break;
                case TweenStatus.Running:
                    Status = TweenStatus.Pausing;
                    break;
                case TweenStatus.WaitingToStop:
                case TweenStatus.Stopped:
                default:
                    break;
            }
        }

        public IObservable<Unit> ToObservable(bool stopWhenDisposed = true)
        {
            if (completedEvent == null)
            {
                completedEvent = new Subject<Unit>();
            }

            if (Status == TweenStatus.Running)
            {
                var obs = completedEvent.FirstOrDefault();
                return (stopWhenDisposed)
                    ? obs.DoOnCancel(() => this.Stop())
                    : obs;
            }

            return Observable.Defer(() =>
            {
                if (Status == TweenStatus.Stopped)
                {
                    Start();
                }

                var obs = completedEvent.FirstOrDefault();
                return (stopWhenDisposed)
                    ? obs.DoOnCancel(() => this.Stop())
                    : obs;
            });
        }

        public void AttachSafe(GameObject gameObject)
        {
            gameObject.OnDestroyAsObservable().Subscribe(_ => this.Stop());
        }

        public void AttachSafe(Component component)
        {
            component.OnDestroyAsObservable().Subscribe(_ => this.Stop());
        }

        protected abstract TProperty AddOperator(TProperty left, TProperty right);

        protected abstract TProperty GetDifference(TProperty from, TProperty to);

        protected abstract void CreateValue(ref TProperty from, ref TProperty difference, ref float ratio, out TProperty value);

        /// <summary>
        /// Called frame TweenManager.
        /// </summary>
        public bool MoveNext(ref float deltaTime, ref float unscaledDeltaTime)
        {
            switch (this.Status)
            {
                case TweenStatus.Pausing:
                    return true;
                case TweenStatus.Running:
                    break;
                case TweenStatus.WaitingToStop:
                case TweenStatus.Stopped:
                default:
                    this.Status = TweenStatus.Stopped;
                    return false;
            }

            if (delayTime != 0)
            {
                delayTime -= (Settings.IsIgnoreTimeScale)
                    ? unscaledDeltaTime
                    : deltaTime;

                if (delayTime <= 0)
                {
                    delayTime = 0;
                }
                else
                {
                    return true;
                }
            }

            var time = (Settings.IsIgnoreTimeScale)
                ? currentTime += unscaledDeltaTime
                : currentTime += deltaTime;

            var completed = false;
            if (time >= duration)
            {
                time = duration;
                completed = true;
            }

            TProperty value;
            var ratio = easingFunction(time, duration);
            CreateValue(ref from, ref difference, ref ratio, out value);

            setter(target, ref value);

            if (completed)
            {
                repeatCount++;
                switch (Settings.LoopType)
                {
                    case LoopType.Restart:
                        this.from = originalFrom;
                        currentTime = 0;
                        break;
                    case LoopType.CycleOnce:
                        if (repeatCount == 2)
                        {
                            return false; // complete
                        }
                        goto case LoopType.Cycle;
                    case LoopType.Cycle: // swap from -> to
                        var temp = from;
                        from = to;
                        to = temp;
                        difference = GetDifference(from, to);
                        currentTime = 0;
                        break;
                    case LoopType.None:
                    default:
                        if (completedEvent != null)
                        {
                            completedEvent.OnNext(Unit.Default);
                        }
                        return false; // finish, remove from TweenEngine
                }
            }

            return true;
        }
    }
}