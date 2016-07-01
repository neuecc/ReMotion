using UnityEngine;

namespace ReMotion
{
    public static class TweenSettingsExtensions
    {
        // Double, Float, Int, Long, UInt, ULong, Vector2, Vector3, Vector4, Color, Rect, Bounds, Quaternion

        public static Tween<TObject, float> UseFloatTween<TObject>(this TweenSettings settings, TObject target, 
            TweenGetter<TObject, float> getter, TweenSetter<TObject, float> setter,
            EasingFunction easingFunction, float duration, float to)
            where TObject : class
        {
            return new FloatTween<TObject>(settings, target, getter, setter, easingFunction, duration, to);
        }

        class FloatTween<TObject> : Tween<TObject, float>
            where TObject : class
        {
            public FloatTween(TweenSettings settings, TObject target, TweenGetter<TObject, float> getter, TweenSetter<TObject, float> setter, EasingFunction easingFunction, float duration, float to)
                : base(settings, target, getter, setter, easingFunction, duration, to)
            {
            }

            protected override float GetDifference(float from, float to)
            {
                return from - to;
            }

            protected override void CreateValue(ref float from, ref float difference, ref float ratio, out float value)
            {
                value = from + (difference * ratio);
            }
        }

        class Vector3Tween<TObject> : Tween<TObject, Vector3>
            where TObject : class
        {
            public Vector3Tween(TweenSettings settings, TObject target, TweenGetter<TObject, Vector3> getter, TweenSetter<TObject, Vector3> setter, EasingFunction easingFunction, float duration, Vector3 to)
                : base(settings, target, getter, setter, easingFunction, duration, to)
            {
            }

            protected override Vector3 GetDifference(Vector3 from, Vector3 to)
            {
                return new Vector3(
                    from.x - to.x,
                    from.y - to.y,
                    from.z - to.z
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