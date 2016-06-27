using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;


namespace ReMotion
{
    /// <summary>
    /// Calculate ratio(return float between 0.0f ~ 1.0f)
    /// </summary>
    public delegate float EasingFunction(float time, float duration, float overshootOrAmplitude, float period);
    public delegate TProperty TweenGetter<TObject, TProperty>(TObject obj);
    public delegate void TweenSetter<TObject, TProperty>(TObject obj, ref TProperty newValue);

    public enum LoopType
    {
        None,
        Restart,
        Cycle
    }

    [Flags]
    public enum AxisConstraints
    {
        None = 0,
        X = 2,
        Y = 4,
        Z = 8,
        W = 16
    }

    public interface ITween
    {
        bool MoveNext(float deltaTime, float unscaledDeltaTime);
    }

    public class TweenSettings
    {
        public LoopType LoopType { get; private set; }
        public bool IgnoreTimeScale { get; private set; }
    }


    public abstract class Tween<TObject, TProperty> : ITween
        where TObject : class
    {
        public TweenSettings Settings { get; private set; }

        protected readonly TObject target;

        protected readonly TweenGetter<TObject, TProperty> getter;
        protected readonly TweenSetter<TObject, TProperty> setter;
        protected readonly EasingFunction easingFunction;
        protected readonly float duration;

        protected TProperty from;
        protected TProperty to;
        protected TProperty changeValue;

        readonly TProperty originalFrom;
        readonly TProperty originalTo;

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
            this.changeValue = GetChangeValue(from, to);
            currentTime = 0;
        }

        protected abstract TProperty GetChangeValue(TProperty from, TProperty to);

        protected abstract void CreateValue(ref float ratio, out TProperty value);

        /// <summary>
        /// Called frame TweenManager.
        /// </summary>
        public bool MoveNext(float deltaTime, float unscaledDeltaTime)
        {
            var time = (Settings.IgnoreTimeScale)
                ? currentTime += unscaledDeltaTime
                : currentTime += deltaTime;

            var completed = false;
            if (time >= duration)
            {
                time = duration;
                completed = true;
            }

            TProperty value;
            // TODO:overshoot or amplituide
            var ratio = easingFunction(time, duration, 0, 0);
            CreateValue(ref ratio, out value);

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
                        changeValue = GetChangeValue(from, to);
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
