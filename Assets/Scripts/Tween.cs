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
        None,
        Restart,
        Cycle
    }

    public enum TweenStatus
    {
        /// <summary>Created but not yet queued.</summary>
        Stopped,
        /// <summary>Queued tween but not yet run.</summary>
        WaitingToRun,
        /// <summary>Tween is runnning.</summary>
        Running,
        /// <summary>Tween is pausing.</summary>
        Pausing,
    }

    public interface ITween
    {
        // passed value is `ref` but must not rewrite values.
        bool MoveNext(ref float deltaTime, ref float unscaledDeltaTime);
    }

    public class TweenSettings
    {
        public static TweenSettings Default = new TweenSettings
        {
            LoopType = LoopType.None,
            IsIgnoreTimeScale = false,
        };

        public LoopType LoopType { get; private set; }
        public bool IsIgnoreTimeScale { get; private set; }
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

        TProperty from;
        TProperty to;
        TProperty difference;

        readonly TProperty originalFrom;
        readonly TProperty originalTo;

        bool isCompleted;
        Subject<Unit> completedEvent;
        float currentTime;

        public Tween(TweenSettings settings, TObject target, TweenGetter<TObject, TProperty> getter, TweenSetter<TObject, TProperty> setter, EasingFunction easingFunction, float duration, TProperty to)
        {
            this.Settings = settings;
            this.target = target;
            this.getter = getter;
            this.setter = setter;
            this.duration = duration;
            this.easingFunction = easingFunction;
            this.to = to;
        }

        public void Reset()
        {
            this.from = originalFrom;
            this.to = originalTo;
            this.difference = GetDifference(from, to);
            currentTime = 0;
        }

        // Start, Reset, Pause, AutoStart

        public Tween<TObject, TProperty> Start()
        {
            if (this.Status == TweenStatus.Stopped)
            {
                // Start.
                this.Status = TweenStatus.WaitingToRun;
            }
            return this;
        }

        public Tween<TObject, TProperty> Start(TProperty from, float delay)
        {
            return this;
        }

        public Tween<TObject, TProperty> StartFrom(TProperty from)
        {
            return this;
        }

        public Tween<TObject, TProperty> StartAfter(float delay)
        {
            return this;
        }

        public IObservable<Unit> ToObservable()
        {
            if (completedEvent == null)
            {
                completedEvent = new Subject<Unit>();
            }

            if (Status == TweenStatus.Running)
            {
                return completedEvent.FirstOrDefault();
            }

            return Observable.Defer(() =>
            {
                if (Status == TweenStatus.Stopped)
                {
                    Start();
                }

                return completedEvent.FirstOrDefault();
            });
        }

        protected abstract TProperty GetDifference(TProperty from, TProperty to);

        protected abstract void CreateValue(ref TProperty from, ref TProperty difference, ref float ratio, out TProperty value);

        /// <summary>
        /// Called frame TweenManager.
        /// </summary>
        public bool MoveNext(ref float deltaTime, ref float unscaledDeltaTime)
        {
            if (this.Status != TweenStatus.Running)
            {
                this.Status = TweenStatus.Running;
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
                        Reset(); // reset state
                        break;
                    case LoopType.Cycle: // swap from -> to
                        var temp = from;
                        from = to;
                        to = temp;
                        difference = GetDifference(from, to);
                        currentTime = 0;
                        break;
                    case LoopType.None:
                    default:
                        return false; // finish, remove from TweenRunner:
                }
            }

            return true;
        }
    }
}
