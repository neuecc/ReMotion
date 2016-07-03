using System;
using UnityEngine;

namespace ReMotion
{
    public static class TweenSettingsExtensions
    {
        // Double, Float, Int, Long, UInt, ULong, Vector2, Vector3, Vector4, Color, Rect, Bounds, Quaternion

        public static Tween<TObject, float> UseFloatTween<TObject>(this TweenSettings settings, TObject target,
            TweenGetter<TObject, float> getter, TweenSetter<TObject, float> setter,
            EasingFunction easingFunction, float duration, float to, bool isRelative)
            where TObject : class
        {
            return new FloatTween<TObject>(settings, target, getter, setter, easingFunction, duration, to, isRelative);
        }

        class FloatTween<TObject> : Tween<TObject, float>
            where TObject : class
        {
            public FloatTween(TweenSettings settings, TObject target, TweenGetter<TObject, float> getter, TweenSetter<TObject, float> setter, EasingFunction easingFunction, float duration, float to, bool isRelative)
                : base(settings, target, getter, setter, easingFunction, duration, to, isRelative)
            {
            }

            protected override float AddOperator(float left, float right)
            {
                return left + right;
            }

            protected override float GetDifference(float from, float to)
            {
                return to - from;
            }

            protected override void CreateValue(ref float from, ref float difference, ref float ratio, out float value)
            {
                value = from + (difference * ratio);
            }
        }

        public static Tween<TObject, Vector3> UseVector3Tween<TObject>(this TweenSettings settings, TObject target,
            TweenGetter<TObject, Vector3> getter, TweenSetter<TObject, Vector3> setter,
            EasingFunction easingFunction, float duration, Vector3 to, bool isRelative)
            where TObject : class
        {
            return new Vector3Tween<TObject>(settings, target, getter, setter, easingFunction, duration, to, isRelative);
        }

        class Vector3Tween<TObject> : Tween<TObject, Vector3>
            where TObject : class
        {
            public Vector3Tween(TweenSettings settings, TObject target, TweenGetter<TObject, Vector3> getter, TweenSetter<TObject, Vector3> setter, EasingFunction easingFunction, float duration, Vector3 to, bool isRelative)
                : base(settings, target, getter, setter, easingFunction, duration, to, isRelative)
            {
            }

            protected override Vector3 AddOperator(Vector3 left, Vector3 right)
            {
                return left + right;
            }

            protected override Vector3 GetDifference(Vector3 from, Vector3 to)
            {
                return new Vector3(
                   to.x - from.x,
                   to.y - from.y,
                   to.z - from.z
                );
            }

            protected override void CreateValue(ref Vector3 from, ref Vector3 difference, ref float ratio, out Vector3 value)
            {
                value = new Vector3(
                    from.x + (difference.x * ratio),
                    from.y + (difference.y * ratio),
                    from.z + (difference.z * ratio)
                );
            }
        }
    }
}