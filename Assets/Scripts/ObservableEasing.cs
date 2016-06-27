using UnityEngine;
using System.Collections;
using UniRx;
using System;
using System.Collections.Generic;

namespace ReMotion
{
    public struct EasingState
    {
        public float Elapsed;
        public float Ratio;

        public EasingState(float elapsed, float ratio)
        {
            this.Elapsed = elapsed;
            this.Ratio = ratio;
        }

        public static implicit operator float(EasingState v)
        {
            return v.Ratio;
        }
    }

    public class ObservableEasing
    {
        public static IObservable<EasingState> Linear(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.Linear, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInSine(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInSine, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseOutSine(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutSine, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInOutSine(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutSine, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInQuad(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInQuad, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseOutQuad(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutQuad, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInOutQuad(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutQuad, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInCubic(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInCubic, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseOutCubic(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutCubic, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInOutCubic(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutCubic, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInQuart(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInQuart, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseOutQuart(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutQuart, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInOutQuart(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutQuart, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInQuint(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInQuint, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseOutQuint(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutQuint, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInOutQuint(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutQuint, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInExpo(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInExpo, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseOutExpo(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutExpo, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInOutExpo(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutExpo, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInCirc(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInCirc, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseOutCirc(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutCirc, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInOutCirc(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutCirc, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInBack(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInBack, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseOutBack(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutBack, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInOutBack(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutBack, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInElastic(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInElastic, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseOutElastic(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutElastic, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInOutElastic(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutElastic, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInBounce(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInBounce, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseOutBounce(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutBounce, duration, ignoreTimeScale);
        }

        public static IObservable<EasingState> EaseInOutBounce(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutBounce, duration, ignoreTimeScale);
        }

        class ObservableTween : ITween
        {
            readonly IObserver<EasingState> observer;
            readonly BooleanDisposable cancellation;
            readonly EasingFunction easing;
            readonly bool ignoreTimeScale;
            readonly float duration;
            float currentTime = 0;

            public ObservableTween(IObserver<EasingState> observer, BooleanDisposable cancellation, EasingFunction easing, float duration, bool ignoreTimeScale)
            {
                this.observer = observer;
                this.cancellation = cancellation;
                this.easing = easing;
                this.ignoreTimeScale = ignoreTimeScale;
                this.duration = duration;
            }

            public static IObservable<EasingState> CreateObservable(EasingFunction easing, float duration, bool ignoreTimeScale)
            {
                return Observable.CreateSafe<EasingState>(observer =>
                {
                    observer.OnNext(default(EasingState)); // push initial value on subscribe.

                    var cancellation = new BooleanDisposable();
                    var tween = new ObservableTween(observer, cancellation, easing, duration, ignoreTimeScale);
                    TweenRunner.AddTween(tween);

                    return cancellation;
                }, false);
            }

            public bool MoveNext(float deltaTime, float unscaledDeltaTime)
            {
                if (cancellation.IsDisposed) return false;

                var delta = (ignoreTimeScale) ? unscaledDeltaTime : deltaTime;
                if (delta == 0) return true;

                currentTime += delta;
                bool isCompleted = false;
                if (currentTime >= duration)
                {
                    currentTime = duration;
                    isCompleted = true;
                }

                // TODO:overshootOrAmplitude, period
                var ratio = easing(currentTime, duration, 1, 1);
                observer.OnNext(new EasingState(currentTime, ratio));

                if (isCompleted)
                {
                    observer.OnCompleted();
                    return false;
                }

                return true;
            }
        }
    }
}