using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ReMotion.Extensions._______________ // copy and modify this.
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

        /// <summary>Tween transform localPosition.</summary>
        public static Tween<Transform, Vector3> TweenLocalPosition(this Transform transform, Vector3 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseVector3Tween(transform, x => x.localPosition, (Transform target, ref Vector3 value) =>
            {
                
                target.localPosition = value;
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform localPosition.</summary>
        public static IObservable<Unit> TweenLocalPositionAsync(this Transform transform, Vector3 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenLocalPosition(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween transform localPosition(X, Y).</summary>
        public static Tween<Transform, Vector2> TweenLocalPositionXY(this Transform transform, Vector2 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseVector2Tween(transform, x => x.localPosition, (Transform target, ref Vector2 value) =>
            {
                var p = target.localPosition;
                target.localPosition = new Vector3 { x = value.x, y = value.y, z = p.z };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform localPosition(X, Y).</summary>
        public static IObservable<Unit> TweenLocalPositionXYAsync(this Transform transform, Vector2 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenLocalPositionXY(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween transform localPosition(X).</summary>
        public static Tween<Transform, float> TweenLocalPositionX(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseFloatTween(transform, x => x.localPosition.x, (Transform target, ref float value) =>
            {
                var p = target.localPosition;
                target.localPosition = new Vector3 { x = value, y = p.y, z = p.z };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform localPosition(X).</summary>
        public static IObservable<Unit> TweenLocalPositionXAsync(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenLocalPositionX(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween transform localPosition(Y).</summary>
        public static Tween<Transform, float> TweenLocalPositionY(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseFloatTween(transform, x => x.localPosition.y, (Transform target, ref float value) =>
            {
                var p = target.localPosition;
                target.localPosition = new Vector3 { x = p.x, y = value, z = p.z };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform localPosition(Y).</summary>
        public static IObservable<Unit> TweenLocalPositionYAsync(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenLocalPositionY(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween transform localPosition(Z).</summary>
        public static Tween<Transform, float> TweenLocalPositionZ(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseFloatTween(transform, x => x.localPosition.z, (Transform target, ref float value) =>
            {
                var p = target.localPosition;
                target.localPosition = new Vector3 { x = p.x, y = p.y, z = value };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform localPosition(Z).</summary>
        public static IObservable<Unit> TweenLocalPositionZAsync(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenLocalPositionZ(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween transform localScale.</summary>
        public static Tween<Transform, Vector3> TweenLocalScale(this Transform transform, Vector3 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseVector3Tween(transform, x => x.localScale, (Transform target, ref Vector3 value) =>
            {
                
                target.localScale = value;
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform localScale.</summary>
        public static IObservable<Unit> TweenLocalScaleAsync(this Transform transform, Vector3 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenLocalScale(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween transform localScale(X, Y).</summary>
        public static Tween<Transform, Vector2> TweenLocalScaleXY(this Transform transform, Vector2 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseVector2Tween(transform, x => x.localScale, (Transform target, ref Vector2 value) =>
            {
                var p = target.localScale;
                target.localScale = new Vector3 { x = value.x, y = value.y, z = p.z };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform localScale(X, Y).</summary>
        public static IObservable<Unit> TweenLocalScaleXYAsync(this Transform transform, Vector2 to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenLocalScaleXY(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween transform localScale(X).</summary>
        public static Tween<Transform, float> TweenLocalScaleX(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseFloatTween(transform, x => x.localScale.x, (Transform target, ref float value) =>
            {
                var p = target.localScale;
                target.localScale = new Vector3 { x = value, y = p.y, z = p.z };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform localScale(X).</summary>
        public static IObservable<Unit> TweenLocalScaleXAsync(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenLocalScaleX(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween transform localScale(Y).</summary>
        public static Tween<Transform, float> TweenLocalScaleY(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseFloatTween(transform, x => x.localScale.y, (Transform target, ref float value) =>
            {
                var p = target.localScale;
                target.localScale = new Vector3 { x = p.x, y = value, z = p.z };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform localScale(Y).</summary>
        public static IObservable<Unit> TweenLocalScaleYAsync(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenLocalScaleY(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
        }

        /// <summary>Tween transform localScale(Z).</summary>
        public static Tween<Transform, float> TweenLocalScaleZ(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false, bool autoStart = true)
        {
            settings = settings ?? TweenSettings.Default;
            easing = easing ?? settings.DefaultEasing;

            var tween = settings.UseFloatTween(transform, x => x.localScale.z, (Transform target, ref float value) =>
            {
                var p = target.localScale;
                target.localScale = new Vector3 { x = p.x, y = p.y, z = value };
            }, easing, duration, to, isRelativeTo);

            if (autoStart)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>Tween transform localScale(Z).</summary>
        public static IObservable<Unit> TweenLocalScaleZAsync(this Transform transform, float to, float duration, EasingFunction easing = null, TweenSettings settings = null, bool isRelativeTo = false)
        {
            return TweenLocalScaleZ(transform, to, duration, easing, settings, isRelativeTo, autoStart: false).ToObservable();
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

