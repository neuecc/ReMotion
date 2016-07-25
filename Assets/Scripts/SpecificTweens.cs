using System;
using UnityEngine;

namespace ReMotion
{
    public static class TweenSettingsExtensions
    {
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

        public static Tween<TObject, Vector2> UseVector2Tween<TObject>(this TweenSettings settings, TObject target,
            TweenGetter<TObject, Vector2> getter, TweenSetter<TObject, Vector2> setter,
            EasingFunction easingFunction, float duration, Vector2 to, bool isRelative)
            where TObject : class
        {
            return new Vector2Tween<TObject>(settings, target, getter, setter, easingFunction, duration, to, isRelative);
        }

        class Vector2Tween<TObject> : Tween<TObject, Vector2>
            where TObject : class
        {
            public Vector2Tween(TweenSettings settings, TObject target, TweenGetter<TObject, Vector2> getter, TweenSetter<TObject, Vector2> setter, EasingFunction easingFunction, float duration, Vector2 to, bool isRelative)
                : base(settings, target, getter, setter, easingFunction, duration, to, isRelative)
            {
            }

            protected override Vector2 AddOperator(Vector2 left, Vector2 right)
            {
                return left + right;
            }

            protected override Vector2 GetDifference(Vector2 from, Vector2 to)
            {
                return new Vector2(
                   to.x - from.x,
                   to.y - from.y
                );
            }

            protected override void CreateValue(ref Vector2 from, ref Vector2 difference, ref float ratio, out Vector2 value)
            {
                value = new Vector2(
                    from.x + (difference.x * ratio),
                    from.y + (difference.y * ratio)
                );
            }
        }

        public static Tween<TObject, Vector4> UseVector4Tween<TObject>(this TweenSettings settings, TObject target,
            TweenGetter<TObject, Vector4> getter, TweenSetter<TObject, Vector4> setter,
            EasingFunction easingFunction, float duration, Vector4 to, bool isRelative)
            where TObject : class
        {
            return new Vector4Tween<TObject>(settings, target, getter, setter, easingFunction, duration, to, isRelative);
        }

        class Vector4Tween<TObject> : Tween<TObject, Vector4>
            where TObject : class
        {
            public Vector4Tween(TweenSettings settings, TObject target, TweenGetter<TObject, Vector4> getter, TweenSetter<TObject, Vector4> setter, EasingFunction easingFunction, float duration, Vector4 to, bool isRelative)
                : base(settings, target, getter, setter, easingFunction, duration, to, isRelative)
            {
            }

            protected override Vector4 AddOperator(Vector4 left, Vector4 right)
            {
                return left + right;
            }

            protected override Vector4 GetDifference(Vector4 from, Vector4 to)
            {
                return new Vector4(
                   to.x - from.x,
                   to.y - from.y,
                   to.z - from.z,
                   to.w = from.w
                );
            }

            protected override void CreateValue(ref Vector4 from, ref Vector4 difference, ref float ratio, out Vector4 value)
            {
                value = new Vector4(
                    from.x + (difference.x * ratio),
                    from.y + (difference.y * ratio),
                    from.z + (difference.z * ratio),
                    from.w + (difference.w * ratio)
                );
            }
        }

        public static Tween<TObject, Double> UseDoubleTween<TObject>(this TweenSettings settings, TObject target,
            TweenGetter<TObject, Double> getter, TweenSetter<TObject, Double> setter,
            EasingFunction easingFunction, float duration, Double to, bool isRelative)
            where TObject : class
        {
            return new DoubleTween<TObject>(settings, target, getter, setter, easingFunction, duration, to, isRelative);
        }

        class DoubleTween<TObject> : Tween<TObject, Double>
            where TObject : class
        {
            public DoubleTween(TweenSettings settings, TObject target, TweenGetter<TObject, Double> getter, TweenSetter<TObject, Double> setter, EasingFunction easingFunction, float duration, Double to, bool isRelative)
                : base(settings, target, getter, setter, easingFunction, duration, to, isRelative)
            {
            }

            protected override Double AddOperator(Double left, Double right)
            {
                return left + right;
            }

            protected override Double GetDifference(Double from, Double to)
            {
                return to - from;
            }

            protected override void CreateValue(ref Double from, ref Double difference, ref float ratio, out Double value)
            {
                value = from + (difference * ratio);
            }
        }

        public static Tween<TObject, Int32> UseInt32Tween<TObject>(this TweenSettings settings, TObject target,
            TweenGetter<TObject, Int32> getter, TweenSetter<TObject, Int32> setter,
            EasingFunction easingFunction, float duration, Int32 to, bool isRelative)
            where TObject : class
        {
            return new Int32Tween<TObject>(settings, target, getter, setter, easingFunction, duration, to, isRelative);
        }

        class Int32Tween<TObject> : Tween<TObject, Int32>
            where TObject : class
        {
            public Int32Tween(TweenSettings settings, TObject target, TweenGetter<TObject, Int32> getter, TweenSetter<TObject, Int32> setter, EasingFunction easingFunction, float duration, Int32 to, bool isRelative)
                : base(settings, target, getter, setter, easingFunction, duration, to, isRelative)
            {
            }

            protected override Int32 AddOperator(Int32 left, Int32 right)
            {
                return left + right;
            }

            protected override Int32 GetDifference(Int32 from, Int32 to)
            {
                return to - from;
            }

            protected override void CreateValue(ref Int32 from, ref Int32 difference, ref float ratio, out Int32 value)
            {
                value = (int)(from + (difference * ratio));
            }
        }

        public static Tween<TObject, Int64> UseInt64Tween<TObject>(this TweenSettings settings, TObject target,
            TweenGetter<TObject, Int64> getter, TweenSetter<TObject, Int64> setter,
            EasingFunction easingFunction, float duration, Int64 to, bool isRelative)
            where TObject : class
        {
            return new Int64Tween<TObject>(settings, target, getter, setter, easingFunction, duration, to, isRelative);
        }

        class Int64Tween<TObject> : Tween<TObject, Int64>
            where TObject : class
        {
            public Int64Tween(TweenSettings settings, TObject target, TweenGetter<TObject, Int64> getter, TweenSetter<TObject, Int64> setter, EasingFunction easingFunction, float duration, Int64 to, bool isRelative)
                : base(settings, target, getter, setter, easingFunction, duration, to, isRelative)
            {
            }

            protected override Int64 AddOperator(Int64 left, Int64 right)
            {
                return left + right;
            }

            protected override Int64 GetDifference(Int64 from, Int64 to)
            {
                return to - from;
            }

            protected override void CreateValue(ref Int64 from, ref Int64 difference, ref float ratio, out Int64 value)
            {
                value = (long)(from + (difference * ratio));
            }
        }

        public static Tween<TObject, UInt32> UseUInt32Tween<TObject>(this TweenSettings settings, TObject target,
            TweenGetter<TObject, UInt32> getter, TweenSetter<TObject, UInt32> setter,
            EasingFunction easingFunction, float duration, UInt32 to, bool isRelative)
            where TObject : class
        {
            return new UInt32Tween<TObject>(settings, target, getter, setter, easingFunction, duration, to, isRelative);
        }

        class UInt32Tween<TObject> : Tween<TObject, UInt32>
            where TObject : class
        {
            public UInt32Tween(TweenSettings settings, TObject target, TweenGetter<TObject, UInt32> getter, TweenSetter<TObject, UInt32> setter, EasingFunction easingFunction, float duration, UInt32 to, bool isRelative)
                : base(settings, target, getter, setter, easingFunction, duration, to, isRelative)
            {
            }

            protected override UInt32 AddOperator(UInt32 left, UInt32 right)
            {
                return left + right;
            }

            protected override UInt32 GetDifference(UInt32 from, UInt32 to)
            {
                return to - from;
            }

            protected override void CreateValue(ref UInt32 from, ref UInt32 difference, ref float ratio, out UInt32 value)
            {
                value = (UInt32)(from + (difference * ratio));
            }
        }

        public static Tween<TObject, UInt64> UseUInt64Tween<TObject>(this TweenSettings settings, TObject target,
            TweenGetter<TObject, UInt64> getter, TweenSetter<TObject, UInt64> setter,
            EasingFunction easingFunction, float duration, UInt64 to, bool isRelative)
            where TObject : class
        {
            return new UInt64Tween<TObject>(settings, target, getter, setter, easingFunction, duration, to, isRelative);
        }

        class UInt64Tween<TObject> : Tween<TObject, UInt64>
            where TObject : class
        {
            public UInt64Tween(TweenSettings settings, TObject target, TweenGetter<TObject, UInt64> getter, TweenSetter<TObject, UInt64> setter, EasingFunction easingFunction, float duration, UInt64 to, bool isRelative)
                : base(settings, target, getter, setter, easingFunction, duration, to, isRelative)
            {
            }

            protected override UInt64 AddOperator(UInt64 left, UInt64 right)
            {
                return left + right;
            }

            protected override UInt64 GetDifference(UInt64 from, UInt64 to)
            {
                return to - from;
            }

            protected override void CreateValue(ref UInt64 from, ref UInt64 difference, ref float ratio, out UInt64 value)
            {
                value = (UInt64)(from + (difference * ratio));
            }
        }

        public static Tween<TObject, Color> UseColorTween<TObject>(this TweenSettings settings, TObject target,
            TweenGetter<TObject, Color> getter, TweenSetter<TObject, Color> setter,
            EasingFunction easingFunction, float duration, Color to, bool isRelative)
            where TObject : class
        {
            return new ColorTween<TObject>(settings, target, getter, setter, easingFunction, duration, to, isRelative);
        }

        class ColorTween<TObject> : Tween<TObject, Color>
            where TObject : class
        {
            public ColorTween(TweenSettings settings, TObject target, TweenGetter<TObject, Color> getter, TweenSetter<TObject, Color> setter, EasingFunction easingFunction, float duration, Color to, bool isRelative)
                : base(settings, target, getter, setter, easingFunction, duration, to, isRelative)
            {
            }

            protected override Color AddOperator(Color left, Color right)
            {
                return left + right;
            }

            protected override Color GetDifference(Color from, Color to)
            {
                return new Color(
                   to.a - from.a,
                   to.r - from.r,
                   to.g - from.g,
                   to.b - from.b
                );
            }

            protected override void CreateValue(ref Color from, ref Color difference, ref float ratio, out Color value)
            {
                value = new Color(
                    from.a + (difference.a * ratio),
                    from.r + (difference.r * ratio),
                    from.g + (difference.g * ratio),
                    from.b + (difference.b * ratio)
                );
            }
        }
    }
}