using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ReMotion
{
    public class FloatTween<TObject> : Tween<TObject, float>
        where TObject : class
    {
        public FloatTween(TweenSettings settings, TObject target, TweenGetter<TObject, float> getter, TweenSetter<TObject, float> setter, EasingFunction easingFunction, float duration, float to) : base(settings, target, getter, setter, easingFunction, duration, to)
        {
        }

        protected override void CreateValue(ref float ratio, out float value)
        {
            value = from + changeValue * ratio;
        }

        protected override float GetChangeValue(float from, float to)
        {
            return from - to;
        }
    }



    public class Vector3Tween<TObject> : Tween<TObject, Vector3>
        where TObject : class
    {
        AxisConstraints constraints;

        public Vector3Tween(TweenSettings settings, TObject target, TweenGetter<TObject, Vector3> getter, TweenSetter<TObject, Vector3> setter, EasingFunction easingFunction, float duration, Vector3 to, AxisConstraints constraints)
            : base(settings, target, getter, setter, easingFunction, duration, to)
        {
        }

        protected override void CreateValue(ref float ratio, out Vector3 value)
        {
            value = new Vector3();

            // TODO:use constraints?
            if ((constraints & AxisConstraints.X) == AxisConstraints.X)
            {
                value.x = from.x + changeValue.x * ratio;
            }
            else
            {
                value.x = from.x;
            }


            value = new Vector3
            {
                x = from.x + changeValue.x * ratio,
                y = from.y + changeValue.y * ratio,
                z = from.z + changeValue.z * ratio
            };
        }

        protected override Vector3 GetChangeValue(Vector3 from, Vector3 to)
        {
            return new Vector3
            {
                x = from.x - to.x,
                y = from.y - to.y,
                z = from.z - to.z
            };
        }
    }


}
