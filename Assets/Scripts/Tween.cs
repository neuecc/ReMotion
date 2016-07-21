using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UniRx;

namespace ReMotion
{
    /// <summary>
    /// Calculate ratio(return float between 0.0f ~ 1.0f)
    /// </summary>
    public delegate float EasingFunction(float time, float duration);
    public delegate TProperty TweenGetter<TObject, TProperty>(TObject obj);
    public delegate void TweenSetter<TObject, TProperty>(TObject obj, ref TProperty newValue);

    public enum LoopType
    {
        /// <summary>One shot linear tween.</summary>
        None,
        /// <summary>Repeat infinite from start.</summary>
        Restart,
        /// <summary>Repeat infinite cycling loop.</summary>
        Cycle,
        /// <summary>One shot cycle tween.</summary>
        CycleOnce
    }

    public enum TweenStatus : byte
    {
        /// <summary>Created but not yet queued.</summary>
        Stopped,
        /// <summary>Queued tween but not yet run.</summary>
        WaitingToRun,
        /// <summary>Tween is runnning.</summary>
        Running,
        /// <summary>Tween is pausing.</summary>
        Pausing,
        /// <summary>Queued stop command.</summary>
        WaitingToStop
    }

    public interface ITween
    {
        // passed value is `ref` but must not rewrite values.
        bool MoveNext(ref float deltaTime, ref float unscaledDeltaTime);
    }

    public class TweenSettings
    {
        public static TweenSettings Default = new TweenSettings()
        {
        };

        public static readonly TweenSettings Cycle = new TweenSettings
        {
            LoopType = LoopType.Cycle,
        };

        public static readonly TweenSettings Restart = new TweenSettings
        {
            LoopType = LoopType.Restart,
        };

        public static readonly TweenSettings CycleOnce = new TweenSettings
        {
            LoopType = LoopType.CycleOnce,
        };

        public static readonly TweenSettings IgnoreTimeScale = new TweenSettings
        {
            IsIgnoreTimeScale = true,
        };

        public static readonly TweenSettings IgnoreTimeScaleCycle = new TweenSettings
        {
            IsIgnoreTimeScale = true,
            LoopType = LoopType.Cycle
        };

        public static readonly TweenSettings IgnoreTimeScaleRestart = new TweenSettings
        {
            IsIgnoreTimeScale = true,
            LoopType = LoopType.Restart
        };

        public static readonly TweenSettings IgnoreTimeScaleCycleOnce = new TweenSettings
        {
            IsIgnoreTimeScale = true,
            LoopType = LoopType.CycleOnce
        };


        public static void SetDefault(TweenSettings settings)
        {
            TweenSettings.Default = settings;
        }

        public LoopType LoopType { get; private set; }
        public bool IsIgnoreTimeScale { get; private set; }
        public EasingFunction DefaultEasing { get; private set; }

        public TweenSettings(LoopType loopType = LoopType.None, bool ignoreTimeScale = false, EasingFunction defaultEasing = null)
        {
            LoopType = loopType;
            IsIgnoreTimeScale = ignoreTimeScale;
            DefaultEasing = defaultEasing ?? EasingFunctions.EaseOutQuad;
        }
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

        bool isCompleted;
        Subject<Unit> completedEvent;
        float currentTime;
        float delayTime;
        // TODO:
        // int repeatCount;

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
            currentTime = 0;
        }

        public Tween<TObject, TProperty> Start()
        {
            if (this.Status == TweenStatus.Stopped)
            {
                this.originalFrom = getter(target);
                Reset();
                this.Status = TweenStatus.WaitingToRun;
                TweenEngine.Instance.Add(this);
            }
            return this;
        }


        public Tween<TObject, TProperty> Start(TProperty from, float delay)
        {
            // TODO:set from, delay
            return this;
        }

        public Tween<TObject, TProperty> Start(TProperty from, float delay, bool isRelativeFrom)
        {
            // TODO:set from, delay
            return this;
        }


        public Tween<TObject, TProperty> StartFrom(TProperty from)
        {
            if (this.Status == TweenStatus.Stopped)
            {
                this.originalFrom = from;
                Reset();
                this.Status = TweenStatus.WaitingToRun;
                TweenEngine.Instance.Add(this);
            }
            return this;
        }

        public Tween<TObject, TProperty> StartFromRelative(TProperty from)
        {
            if (this.Status == TweenStatus.Stopped)
            {
                this.originalFrom = from;
                Reset();
                this.Status = TweenStatus.WaitingToRun;
                TweenEngine.Instance.Add(this);
            }
            return this;
        }

        public Tween<TObject, TProperty> StartAfter(float delayTime)
        {
            if (delayTime <= 0) delayTime = 0;
            this.delayTime = delayTime;
            return Start();
        }

        public void Stop()
        {
            if (Status != TweenStatus.Stopped)
            {
                Status = TweenStatus.WaitingToStop;
            }
        }

        public void Pause()
        {
            if (Status == TweenStatus.Running || Status == TweenStatus.WaitingToRun)
            {
                Status = TweenStatus.Pausing;
            }
        }

        public void Resume()
        {
            if (Status == TweenStatus.Pausing)
            {
                Status = TweenStatus.Running;
            }
        }

        public void PauseOrResume()
        {
            if (Status == TweenStatus.Running || Status == TweenStatus.WaitingToRun)
            {
                Status = TweenStatus.Pausing;
            }
            else if (Status == TweenStatus.Pausing)
            {
                Status = TweenStatus.Running;
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

        protected abstract TProperty AddOperator(TProperty left, TProperty right);

        protected abstract TProperty GetDifference(TProperty from, TProperty to);

        protected abstract void CreateValue(ref TProperty from, ref TProperty difference, ref float ratio, out TProperty value);

        /// <summary>
        /// Called frame TweenManager.
        /// </summary>
        public bool MoveNext(ref float deltaTime, ref float unscaledDeltaTime)
        {
            if (this.Status == TweenStatus.WaitingToStop)
            {
                this.Status = TweenStatus.Stopped;
                return false;
            }
            else if (this.Status == TweenStatus.Pausing)
            {
                return true;
            }
            else if (this.Status != TweenStatus.Running)
            {
                this.Status = TweenStatus.Running;
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
                switch (Settings.LoopType)
                {
                    case LoopType.Restart:
                        this.from = originalFrom;
                        currentTime = 0;
                        break;
                    case LoopType.Cycle: // swap from -> to
                    case LoopType.CycleOnce:
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
