using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReMotion
{
    /// <summary>
    /// Calculate ratio(return float between 0.0f ~ 1.0f)
    /// </summary>
    public delegate float EasingFunction(float time, float duration);
    public delegate TProperty TweenGetter<TObject, TProperty>(TObject obj);
    public delegate void TweenSetter<TObject, TProperty>(TObject obj, ref TProperty newValue);
}
