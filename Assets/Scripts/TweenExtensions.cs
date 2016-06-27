using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ReMotion.Extensions
{
    public static class TweenExtensions
    {
        public static void MovePositionX(this Transform transform, float to, float duration, EasingFunction easing = null)
        {
            var settings = new TweenSettings(); // TODO:needs settings
            var p = transform.position;
            easing = easing ?? EasingFunctions.Linear;
            var tween = new Vector3Tween<Transform>(settings, transform, x => x.position, (Transform t, ref Vector3 v) => t.position = v, easing, duration, new Vector3(to, p.y, p.z), AxisConstraints.X);
        }
    }
}
