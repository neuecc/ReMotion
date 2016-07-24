namespace ReMotion
{
    public enum LoopType
    {
        /// <summary>One shot linear tween.</summary>
        None,
        /// <summary>Repeat infinite from start.</summary>
        Restart,
        /// <summary>Repeat infinite cycling loop.</summary>
        Cycle,
        /// <summary>One shot cycle tween.</summary>
        CycleOnce
    }

    public sealed class TweenSettings
    {
        public static TweenSettings Default = new TweenSettings()
        {
        };

        public static readonly TweenSettings Cycle = new TweenSettings
        {
            LoopType = LoopType.Cycle,
        };

        public static readonly TweenSettings Restart = new TweenSettings
        {
            LoopType = LoopType.Restart,
        };

        public static readonly TweenSettings CycleOnce = new TweenSettings
        {
            LoopType = LoopType.CycleOnce,
        };

        public static readonly TweenSettings IgnoreTimeScale = new TweenSettings
        {
            IsIgnoreTimeScale = true,
        };

        public static readonly TweenSettings IgnoreTimeScaleCycle = new TweenSettings
        {
            IsIgnoreTimeScale = true,
            LoopType = LoopType.Cycle
        };

        public static readonly TweenSettings IgnoreTimeScaleRestart = new TweenSettings
        {
            IsIgnoreTimeScale = true,
            LoopType = LoopType.Restart
        };

        public static readonly TweenSettings IgnoreTimeScaleCycleOnce = new TweenSettings
        {
            IsIgnoreTimeScale = true,
            LoopType = LoopType.CycleOnce
        };


        public static void SetDefault(TweenSettings settings)
        {
            TweenSettings.Default = settings;
        }

        public LoopType LoopType { get; private set; }
        public bool IsIgnoreTimeScale { get; private set; }
        public EasingFunction DefaultEasing { get; private set; }

        public TweenSettings(LoopType loopType = LoopType.None, bool ignoreTimeScale = false, EasingFunction defaultEasing = null)
        {
            LoopType = loopType;
            IsIgnoreTimeScale = ignoreTimeScale;
            DefaultEasing = defaultEasing ?? EasingFunctions.EaseOutQuad;
        }
    }
}
