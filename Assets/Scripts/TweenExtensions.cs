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
        // Position

        /// <summary>
        /// Tween transfrom position.
        /// </summary>
        public static Tween<Transform, Vector3> TweenPosition(this Transform transform, Vector3 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseVector3Tween(transform, x => x.position, (Transform t, ref Vector3 v) =>
            {
                t.position = v;
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>
        /// Tween transfrom position.
        /// </summary>
        public static IObservable<Unit> TweenPositionAsync(this Transform transform, Vector3 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenPosition(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>
        /// Tween transfrom position(X, Y).
        /// </summary>
        public static Tween<Transform, Vector2> TweenPositionXY(this Transform transform, Vector2 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseVector2Tween(transform, x => x.position, (Transform t, ref Vector2 v) =>
            {
                var p = t.position;
                t.position = new Vector3 { x = v.x, y = v.y, z = p.z };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        public static Tween<Transform, float> TweenPositionX(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseFloatTween(transform, x => x.position.x, (Transform t, ref float v) =>
            {
                var p = t.position;
                t.position = new Vector3 { x = v, y = p.y, z = p.z };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        public static IObservable<Unit> TweenPositionXAsync(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenPositionX(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        public static Tween<Transform, float> TweenPositionY(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseFloatTween(transform, x => x.position.y, (Transform t, ref float v) =>
            {
                var p = t.position;
                t.position = new Vector3 { x = p.x, y = v, z = p.z };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        public static IObservable<Unit> TweenPositionYAsync(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenPositionY(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        public static Tween<Transform, float> TweenPositionZ(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseFloatTween(transform, x => x.position.z, (Transform t, ref float v) =>
            {
                var p = t.position;
                t.position = new Vector3 { x = p.x, y = p.y, z = v };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        public static IObservable<Unit> TweenPositionZAsync(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenPositionZ(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        // LocalPositionX, Y, Z

        // Scale



        /// <summary>Tween transfrom scale(X, Y).</summary>
        public static Tween<Transform, Vector2> TweenLocalScaleXY(this Transform transform, Vector2 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseVector2Tween(transform, x => x.localScale, (Transform t, ref Vector2 v) =>
            {
                var p = t.localScale;
                t.localScale = new Vector3 { x = v.x, y = v.y, z = p.z };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }






        //public static Tween<Transform, float> TweenLocalPositionX(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool autoStart = true)
        //{
        //    settings = settings ?? TweenSettings.Default;
        //    easing = easing ?? settings.DefaultEasing;

        //    var tween = settings.UseFloatTween(transform, x => x.localPosition.x, (Transform t, ref float v) =>
        //    {
        //        var p = t.localPosition;
        //        t.localPosition = new Vector3 { x = v, y = p.y, z = p.z };
        //    }, easing, duration, to);

        //    if (autoStart)
        //    {
        //        tween.Start();
        //    }

        //    return tween;
        //}

        //// uGUI

        //public static Tween<UnityEngine.UI.Graphic, float> TweenAlpha(this UnityEngine.UI.Graphic graphic, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool autoStart = true)
        //{
        //    settings = settings ?? TweenSettings.Default;
        //    easing = easing ?? settings.DefaultEasing;

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

        ////public static Tween<UnityEngine.UI.Graphic, Color> TweenColor(this UnityEngine.UI.Graphic graphic, Color to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool autoStart = true)
        ////{
        ////    settings = settings ?? TweenSettings.Default;
        ////    easing = easing ?? settings.DefaultEasing;

        ////    var tween = settings.UseFloatTween(graphic, x => x.color.a, (UnityEngine.UI.Graphic g, ref float v) =>
        ////    {
        ////        var c = g.color;
        ////        g.color = new Color { a = v, r = c.r, g = c.g, b = c.b };
        ////    }, easing, duration, to);

        ////    if (autoStart)
        ////    {
        ////        tween.Start();
        ////    }

        ////    return tween;
        ////}

        //public static Tween<UnityEngine.UI.Image, float> TweenFillAmount(this UnityEngine.UI.Image image, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool autoStart = true)
        //{
        //    settings = settings ?? TweenSettings.Default;
        //    easing = easing ?? settings.DefaultEasing;

        //    var tween = settings.UseFloatTween(image, x => x.fillAmount, (UnityEngine.UI.Image img, ref float v) =>
        //    {
        //        img.fillAmount = v;
        //    }, easing, duration, to);

        //    if (autoStart)
        //    {
        //        tween.Start();
        //    }

        //    return tween;
        //}
    }
}