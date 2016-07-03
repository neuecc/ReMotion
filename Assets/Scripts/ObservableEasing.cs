using UniRx;

namespace ReMotion
{
    public class ObservableEasing
    {
        const float DefaultOvershoot = 1.70158f;
        const float DefaultAmplitude = 1.70158f;
        const float DefaultPeriod = 0.0f;

        public static IObservable<float> Create(EasingFunction easing, float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(easing, duration, ignoreTimeScale);
        }

        public static IObservable<float> Linear(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.Linear, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInSine(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInSine, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseOutSine(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutSine, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInOutSine(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutSine, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInQuad(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInQuad, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseOutQuad(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutQuad, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInOutQuad(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutQuad, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInCubic(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInCubic, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseOutCubic(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutCubic, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInOutCubic(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutCubic, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInQuart(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInQuart, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseOutQuart(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutQuart, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInOutQuart(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutQuart, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInQuint(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInQuint, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseOutQuint(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutQuint, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInOutQuint(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutQuint, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInExpo(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInExpo, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseOutExpo(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutExpo, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInOutExpo(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutExpo, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInCirc(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInCirc, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseOutCirc(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutCirc, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInOutCirc(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutCirc, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInBack(float duration, float overshoot = DefaultOvershoot, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInBack(overshoot), duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseOutBack(float duration, float overshoot = DefaultOvershoot, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutBack(overshoot), duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInOutBack(float duration, float overshoot = DefaultOvershoot, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutBack(overshoot), duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInElastic(float duration, float amplitude = DefaultAmplitude, float period = DefaultPeriod, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInElastic(amplitude, period), duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseOutElastic(float duration, float amplitude = DefaultAmplitude, float period = DefaultPeriod, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutElastic(amplitude, period), duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInOutElastic(float duration, float amplitude = DefaultAmplitude, float period = DefaultPeriod, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutElastic(amplitude, period), duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInBounce(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInBounce, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseOutBounce(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseOutBounce, duration, ignoreTimeScale);
        }

        public static IObservable<float> EaseInOutBounce(float duration, bool ignoreTimeScale = false)
        {
            return ObservableTween.CreateObservable(EasingFunctions.EaseInOutBounce, duration, ignoreTimeScale);
        }

        class ObservableTween : ITween
        {
            readonly IObserver<float> observer;
            readonly BooleanDisposable cancellation;
            readonly EasingFunction easing;
            readonly bool ignoreTimeScale;
            readonly float duration;
            float currentTime = 0;

            ObservableTween(IObserver<float> observer, BooleanDisposable cancellation, EasingFunction easing, float duration, bool ignoreTimeScale)
            {
                this.observer = observer;
                this.cancellation = cancellation;
                this.easing = easing;
                this.ignoreTimeScale = ignoreTimeScale;
                this.duration = duration;
            }

            public static IObservable<float> CreateObservable(EasingFunction easing, float duration, bool ignoreTimeScale)
            {
                return Observable.CreateSafe<float>(observer =>
                {
                    observer.OnNext(default(float)); // push initial value on subscribe.

                    var cancellation = new BooleanDisposable();
                    var tween = new ObservableTween(observer, cancellation, easing, duration, ignoreTimeScale);
                    TweenEngine.AddTween(tween);

                    return cancellation;
                }, false);
            }

            public bool MoveNext(ref float deltaTime, ref float unscaledDeltaTime)
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

                observer.OnNext(easing(currentTime, duration));

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