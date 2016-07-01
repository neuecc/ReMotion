using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ReMotion
{
    public static class EasingFunctions
    {
        const float DefaultOvershoot = 1.70158f;
        const float DefaultAmplitude = 1.70158f;
        const float DefaultPeriod = 0.3f;

        const float PiDivide2 = Mathf.PI / 2.0f;
        const float PiMultiply2 = Mathf.PI * 2.0f;

        // Robert Penner's Easing Functions : http://robertpenner.com/easing/ http://gizma.com/easing/ http://wiki.unity3d.com/index.php?title=Interpolate

        /*
            @t is the current time (or position) of the tween. This can be seconds or frames, steps, seconds, ms, whatever – as long as the unit is the same as is used for the total time [3].
            @b is the beginning value of the property.
            @c is the change between the beginning and destination value of the property.
            @d is the total time of the tween.
        */

        // Calculate Ratio(0.0f ~ 1.0f)
        // b = 0.0f, c = 1.0f
        // t(= time), d(= duration)

        // does not allocate new delegate.

        public static readonly EasingFunction Linear = Linear_;
        public static readonly EasingFunction EaseInSine = EaseInSine_;
        public static readonly EasingFunction EaseOutSine = EaseOutSine_;
        public static readonly EasingFunction EaseInOutSine = EaseInOutSine_;
        public static readonly EasingFunction EaseInQuad = EaseInQuad_;
        public static readonly EasingFunction EaseOutQuad = EaseOutQuad_;
        public static readonly EasingFunction EaseInOutQuad = EaseInOutQuad_;
        public static readonly EasingFunction EaseInCubic = EaseInCubic_;
        public static readonly EasingFunction EaseOutCubic = EaseOutCubic_;
        public static readonly EasingFunction EaseInOutCubic = EaseInOutCubic_;
        public static readonly EasingFunction EaseInQuart = EaseInQuart_;
        public static readonly EasingFunction EaseOutQuart = EaseOutQuart_;
        public static readonly EasingFunction EaseInOutQuart = EaseInOutQuart_;
        public static readonly EasingFunction EaseInQuint = EaseInQuint_;
        public static readonly EasingFunction EaseOutQuint = EaseOutQuint_;
        public static readonly EasingFunction EaseInOutQuint = EaseInOutQuint_;
        public static readonly EasingFunction EaseInExpo = EaseInExpo_;
        public static readonly EasingFunction EaseOutExpo = EaseOutExpo_;
        public static readonly EasingFunction EaseInOutExpo = EaseInOutExpo_;
        public static readonly EasingFunction EaseInCirc = EaseInCirc_;
        public static readonly EasingFunction EaseOutCirc = EaseOutCirc_;
        public static readonly EasingFunction EaseInOutCirc = EaseInOutCirc_;

        // currying...
        // public static readonly EasingFunction EaseInBack = defaultEaseInBack;
        // public static readonly EasingFunction EaseOutBack = EaseOutBack_;
        // public static readonly EasingFunction EaseInOutBack = EaseInOutBack_;
        // public static readonly EasingFunction EaseInElastic = EaseInElastic_;
        // public static readonly EasingFunction EaseOutElastic = EaseOutElastic_;
        // public static readonly EasingFunction EaseInOutElastic = EaseInOutElastic_;

        public static readonly EasingFunction EaseInBounce = EaseInBounce_;
        public static readonly EasingFunction EaseOutBounce = EaseOutBounce_;
        public static readonly EasingFunction EaseInOutBounce = EaseInOutBounce_;

        static readonly EasingFunction defaultEaseInBack = new EasingFunction((time, duration) => EaseInBack_(time, duration, DefaultOvershoot));

        public static EasingFunction EaseInBack(float overshoot = DefaultOvershoot)
        {
            return (overshoot == DefaultOvershoot)
                ? defaultEaseInBack
                : new EasingFunction((time, duration) => EaseInBack_(time, duration, overshoot));
        }

        static readonly EasingFunction defaultEaseOutBack = new EasingFunction((time, duration) => EaseOutBack_(time, duration, DefaultOvershoot));

        public static EasingFunction EaseOutBack(float overshoot = DefaultOvershoot)
        {
            return (overshoot == DefaultOvershoot)
                ? defaultEaseOutBack
                : new EasingFunction((time, duration) => EaseOutBack_(time, duration, overshoot));
        }

        static readonly EasingFunction defaultEaseInOutBack = new EasingFunction((time, duration) => EaseInOutBack_(time, duration, DefaultOvershoot));

        public static EasingFunction EaseInOutBack(float overshoot = DefaultOvershoot)
        {
            return (overshoot == DefaultOvershoot)
                ? defaultEaseInOutBack
                : new EasingFunction((time, duration) => EaseInOutBack_(time, duration, overshoot));
        }

        static readonly EasingFunction defaultEaseInElastic = new EasingFunction((time, duration) => EaseInElastic_(time, duration, DefaultAmplitude, DefaultPeriod));

        public static EasingFunction EaseInElastic(float amplitude = DefaultAmplitude, float period = DefaultPeriod)
        {
            return (amplitude == DefaultOvershoot && period == DefaultPeriod)
                ? defaultEaseInElastic
                : new EasingFunction((time, duration) => EaseInElastic_(time, duration, amplitude, period));
        }

        static readonly EasingFunction defaultEaseOutElastic = new EasingFunction((time, duration) => EaseOutElastic_(time, duration, DefaultAmplitude, DefaultPeriod));

        public static EasingFunction EaseOutElastic(float amplitude = DefaultAmplitude, float period = DefaultPeriod)
        {
            return (amplitude == DefaultOvershoot && period == DefaultPeriod)
                ? defaultEaseOutElastic
                : new EasingFunction((time, duration) => EaseOutElastic_(time, duration, amplitude, period));
        }

        static readonly EasingFunction defaultEaseInOutElastic = new EasingFunction((time, duration) => EaseInOutElastic_(time, duration, DefaultAmplitude, DefaultPeriod));

        public static EasingFunction EaseInOutElastic(float amplitude = DefaultAmplitude, float period = DefaultPeriod)
        {
            return (amplitude == DefaultOvershoot && period == DefaultPeriod)
                ? defaultEaseInOutElastic
                : new EasingFunction((time, duration) => EaseInOutElastic_(time, duration, amplitude, period));
        }

        static float Linear_(float time, float duration)
        {
            return time / duration;
        }

        static float EaseInSine_(float time, float duration)
        {
            return -1.0f * (float)Math.Cos(time / duration * PiDivide2) + 1.0f;
        }

        static float EaseOutSine_(float time, float duration)
        {
            return (float)Math.Sin(time / duration * PiDivide2);
        }

        static float EaseInOutSine_(float time, float duration)
        {
            return -0.5f * ((float)Math.Cos(Mathf.PI * time / duration) - 1);
        }

        static float EaseInQuad_(float time, float duration)
        {
            time /= duration;
            return time * time;
        }

        static float EaseOutQuad_(float time, float duration)
        {
            time /= duration;
            return -(time) * (time - 2);
        }

        static float EaseInOutQuad_(float time, float duration)
        {
            time /= (duration * 0.5f);
            if (time < 1) return 0.5f * time * time;
            time -= 1;
            return -0.5f * (time * (time - 2) - 1);
        }

        static float EaseInCubic_(float time, float duration)
        {
            time /= duration;
            return time * time * time;
        }

        static float EaseOutCubic_(float time, float duration)
        {
            time = (time / duration) - 1;
            return (time * time * time) + 1;
        }

        static float EaseInOutCubic_(float time, float duration)
        {
            if ((time /= duration * 0.5f) < 1) return 0.5f * time * time * time;
            return 0.5f * ((time -= 2) * time * time + 2);
        }

        static float EaseInQuart_(float time, float duration)
        {
            return (time /= duration) * time * time * time;
        }

        static float EaseOutQuart_(float time, float duration)
        {
            return -((time = time / duration - 1) * time * time * time - 1);
        }

        static float EaseInOutQuart_(float time, float duration)
        {
            if ((time /= duration * 0.5f) < 1) return 0.5f * time * time * time * time;
            return -0.5f * ((time -= 2) * time * time * time - 2);
        }

        static float EaseInQuint_(float time, float duration)
        {
            return (time /= duration) * time * time * time * time;
        }

        static float EaseOutQuint_(float time, float duration)
        {
            return ((time = time / duration - 1) * time * time * time * time + 1);
        }

        static float EaseInOutQuint_(float time, float duration)
        {
            if ((time /= duration * 0.5f) < 1) return 0.5f * time * time * time * time * time;
            return 0.5f * ((time -= 2) * time * time * time * time + 2);
        }

        static float EaseInExpo_(float time, float duration)
        {
            return (time == 0) ? 0 : (float)Math.Pow(2, 10 * (time / duration - 1));
        }

        static float EaseOutExpo_(float time, float duration)
        {
            if (time == duration) return 1;
            return (-(float)Math.Pow(2, -10 * time / duration) + 1);
        }

        static float EaseInOutExpo_(float time, float duration)
        {
            if (time == 0) return 0;
            if (time == duration) return 1;
            if ((time /= duration * 0.5f) < 1) return 0.5f * (float)Math.Pow(2, 10 * (time - 1));
            return 0.5f * (-(float)Math.Pow(2, -10 * --time) + 2);
        }

        static float EaseInCirc_(float time, float duration)
        {
            return -((float)Math.Sqrt(1 - (time /= duration) * time) - 1);
        }

        static float EaseOutCirc_(float time, float duration)
        {
            return (float)Math.Sqrt(1 - (time = time / duration - 1) * time);
        }

        static float EaseInOutCirc_(float time, float duration)
        {
            if ((time /= duration * 0.5f) < 1) return -0.5f * ((float)Math.Sqrt(1 - time * time) - 1);
            return 0.5f * ((float)Math.Sqrt(1 - (time -= 2) * time) + 1);
        }

        static float EaseInBack_(float time, float duration, float overshoot)
        {
            return (time /= duration) * time * ((overshoot + 1) * time - overshoot);
        }

        static float EaseOutBack_(float time, float duration, float overshoot)
        {
            return ((time = time / duration - 1) * time * ((overshoot + 1) * time + overshoot) + 1);
        }

        static float EaseInOutBack_(float time, float duration, float overshoot)
        {
            if ((time /= duration * 0.5f) < 1) return 0.5f * (time * time * (((overshoot *= (1.525f)) + 1) * time - overshoot));
            return 0.5f * ((time -= 2) * time * (((overshoot *= (1.525f)) + 1) * time + overshoot) + 2);
        }

        static float EaseInElastic_(float time, float duration, float amplitude, float period)
        {
            float s0;
            if (time == 0) return 0;
            if ((time /= duration) == 1) return 1;
            if (period == 0) period = duration * 0.3f;
            if (amplitude < 1)
            {
                amplitude = 1;
                s0 = period / 4;
            }
            else s0 = period / PiMultiply2 * (float)Math.Asin(1 / amplitude);
            return -(amplitude * (float)Math.Pow(2, 10 * (time -= 1)) * (float)Math.Sin((time * duration - s0) * PiMultiply2 / period));
        }

        static float EaseOutElastic_(float time, float duration, float amplitude, float period)
        {
            float s1;
            if (time == 0) return 0;
            if ((time /= duration) == 1) return 1;
            if (period == 0) period = duration * 0.3f;
            if (amplitude < 1)
            {
                amplitude = 1;
                s1 = period / 4;
            }
            else s1 = period / PiMultiply2 * (float)Math.Asin(1 / amplitude);
            return (amplitude * (float)Math.Pow(2, -10 * time) * (float)Math.Sin((time * duration - s1) * PiMultiply2 / period) + 1);
        }

        static float EaseInOutElastic_(float time, float duration, float amplitude, float period)
        {
            float s;
            if (time == 0) return 0;
            if ((time /= duration * 0.5f) == 2) return 1;
            if (period == 0) period = duration * (0.3f * 1.5f);
            if (amplitude < 1)
            {
                amplitude = 1;
                s = period / 4;
            }
            else s = period / PiMultiply2 * (float)Math.Asin(1 / amplitude);
            if (time < 1) return -0.5f * (amplitude * (float)Math.Pow(2, 10 * (time -= 1)) * (float)Math.Sin((time * duration - s) * PiMultiply2 / period));
            return amplitude * (float)Math.Pow(2, -10 * (time -= 1)) * (float)Math.Sin((time * duration - s) * PiMultiply2 / period) * 0.5f + 1;
        }

        static float EaseInBounce_(float time, float duration)
        {
            return 1 - EaseOutBounce_(duration - time, duration);
        }

        static float EaseOutBounce_(float time, float duration)
        {
            time /= duration;
            if (time < (1 / 2.75f))
            {
                return (7.5625f * time * time);
            }
            if (time < (2 / 2.75f))
            {
                return (7.5625f * (time -= (1.5f / 2.75f)) * time + 0.75f);
            }
            if (time < (2.5f / 2.75f))
            {
                return (7.5625f * (time -= (2.25f / 2.75f)) * time + 0.9375f);
            }
            return (7.5625f * (time -= (2.625f / 2.75f)) * time + 0.984375f);
        }

        static float EaseInOutBounce_(float time, float duration)
        {
            if (time < duration * 0.5f)
            {
                return EaseInBounce_(time * 2, duration) * 0.5f;
            }
            return EaseOutBounce_(time * 2 - duration, duration) * 0.5f + 0.5f;
        }
    }
}