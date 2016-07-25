using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ReMotion.Extensions
{
    public static class TweenExtensions
    {

        /// <summary>Tween transform position.</summary>
        public static Tween<Transform, Vector3> TweenPosition(this Transform transform, Vector3 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseVector3Tween(transform, x => x.position, (Transform target, ref Vector3 value) =>
            {

                target.position = value;
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform position.</summary>
        public static IObservable<Unit> TweenPositionAsync(this Transform transform, Vector3 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenPosition(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween transform position(X, Y).</summary>
        public static Tween<Transform, Vector2> TweenPositionXY(this Transform transform, Vector2 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseVector2Tween(transform, x => x.position, (Transform target, ref Vector2 value) =>
            {
                var p = target.position;
                target.position = new Vector3 { x = value.x, y = value.y, z = p.z };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform position(X, Y).</summary>
        public static IObservable<Unit> TweenPositionXYAsync(this Transform transform, Vector2 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenPositionXY(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween transform position(X).</summary>
        public static Tween<Transform, float> TweenPositionX(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseFloatTween(transform, x => x.position.x, (Transform target, ref float value) =>
            {
                var p = target.position;
                target.position = new Vector3 { x = value, y = p.y, z = p.z };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform position(X).</summary>
        public static IObservable<Unit> TweenPositionXAsync(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenPositionX(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween transform position(Y).</summary>
        public static Tween<Transform, float> TweenPositionY(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseFloatTween(transform, x => x.position.y, (Transform target, ref float value) =>
            {
                var p = target.position;
                target.position = new Vector3 { x = p.x, y = value, z = p.z };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform position(Y).</summary>
        public static IObservable<Unit> TweenPositionYAsync(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenPositionY(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween transform position(Z).</summary>
        public static Tween<Transform, float> TweenPositionZ(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseFloatTween(transform, x => x.position.z, (Transform target, ref float value) =>
            {
                var p = target.position;
                target.position = new Vector3 { x = p.x, y = p.y, z = value };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform position(Z).</summary>
        public static IObservable<Unit> TweenPositionZAsync(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenPositionZ(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween color alpha.</summary>
        public static Tween<Graphic, float> TweenAlpha(this Graphic graphic, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseFloatTween(graphic, x => x.color.a, (Graphic target, ref float value) =>
            {
                var x = target.color;
                target.color = new Color { r = x.r, g = x.g, b = x.b, a = value };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween color alpha.</summary>
        public static IObservable<Unit> TweenAlphaAsync(this Graphic graphic, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenAlpha(graphic, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween color.</summary>
        public static Tween<Graphic, Color> TweenColor(this Graphic graphic, Color to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseColorTween(graphic, x => x.color, (Graphic target, ref Color value) =>
            {

                target.color = value;
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween color.</summary>
        public static IObservable<Unit> TweenColorAsync(this Graphic graphic, Color to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenColor(graphic, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

    }
}

