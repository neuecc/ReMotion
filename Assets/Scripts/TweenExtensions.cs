using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;
using UnityEngine;

namespace ReMotion.Extensions
{
    public static class TweenExtensions
    {
        public static Tween<Transform, float> TweenPositionX(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? EasingFunctions.Linear;

            var tween = settings.UseFloatTween(transform, x => x.position.x, (Transform t, ref float v) =>
            {
                var p = t.position;
                t.position = new Vector3 { x = v, y = p.y, z = p.z };
            }, easing, duration, to);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        public static IObservable<Unit> TweenPositionXAsync(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null)
        {
            return TweenPositionX(transform, to, duration, easing, settings, false).ToObservable();
        }

        public static Tween<Transform, float> TweenLocalPositionX(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? EasingFunctions.Linear;

            var tween = settings.UseFloatTween(transform, x => x.localPosition.x, (Transform t, ref float v) =>
            {
                var p = t.localPosition;
                t.localPosition = new Vector3 { x = v, y = p.y, z = p.z };
            }, easing, duration, to);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        // uGUI

        public static Tween<UnityEngine.UI.Graphic, float> TweenAlpha(this UnityEngine.UI.Graphic graphic, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? EasingFunctions.Linear;

            var tween = settings.UseFloatTween(graphic, x => x.color.a, (UnityEngine.UI.Graphic g, ref float v) =>
            {
                var c = g.color;
                g.color = new Color { a = v, r = c.r, g = c.g, b = c.b };
            }, easing, duration, to);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        //public static Tween<UnityEngine.UI.Graphic, Color> TweenColor(this UnityEngine.UI.Graphic graphic, Color to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool autoStart = true)
        //{
        //    settings = settings ?? TweenSettings.Default;
        //    easing = easing ?? EasingFunctions.Linear;

        //    var tween = settings.UseFloatTween(graphic, x => x.color.a, (UnityEngine.UI.Graphic g, ref float v) =>
        //    {
        //        var c = g.color;
        //        g.color = new Color { a = v, r = c.r, g = c.g, b = c.b };
        //    }, easing, duration, to);

        //    if (autoStart)
        //    {
        //        tween.Start();
        //    }

        //    return tween;
        //}

        public static Tween<UnityEngine.UI.Image, float> TweenFillAmount(this UnityEngine.UI.Image image, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? EasingFunctions.Linear;

            var tween = settings.UseFloatTween(image, x => x.fillAmount, (UnityEngine.UI.Image img, ref float v) =>
            {
                img.fillAmount = v;
            }, easing, duration, to);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }
    }
}