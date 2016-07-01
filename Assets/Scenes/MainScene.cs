using UnityEngine;

using UniRx;
using System.Collections;
using ReMotion.Extensions;
using UnityEngine.UI;
using System.Linq;

namespace ReMotion.Sandbox
{
    public class MainScene : MonoBehaviour
    {
        public Transform target;
        public RawImage graph;

        public Vector3 original;
        public float from;
        public float to;
        public float diff;
        const int width = 300;
        const int height = 300;

        Color[] colors = new Color[600 * 600];
        Texture2D texture;

        void TweenX(Transform t, float ratio)
        {
            var v3 = new Vector3(from + diff * ratio, target.position.y, target.position.z);
            t.position = v3;
        }

        void Start()
        {
            MainThreadDispatcher.Initialize();
            Application.targetFrameRate = -1;

            original = target.transform.position;
            from = original.x;
            to = 2.0f;
            diff = to - from;

            texture = new Texture2D(600, 600, TextureFormat.ARGB32, false);
            graph.texture = texture;
            graph.texture.filterMode = FilterMode.Point;
            ResetGraph();
        }

        void ResetGraph()
        {
            var w = width + 300;
            var h = height + 300;
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    var i = y * w + x;
                    colors[i] = Color.white;
                }
            }
            texture.SetPixels(colors);
            texture.Apply();
        }

        void DrawGraph(ref Vector2 last, float time, float ratio)
        {
            var x = (int)((width) * (time / 1.0f)) + 150;
            var y = (int)(ratio * (height)) + 150;

            var to = new Vector2(x, y);
            var l = last;
            foreach (var v2 in Enumerable.Range(0, 101).Select(i => Vector2.Lerp(l, to, (float)i / 100.0f)).Select(t => new { x = (int)t.x, y = (int)t.y }).Distinct())
            {
                // bold
                texture.SetPixel(v2.x, v2.y, Color.red);
                texture.SetPixel(v2.x + 1, v2.y, Color.red);
                texture.SetPixel(v2.x + 1, v2.y + 1, Color.red);
                texture.SetPixel(v2.x + 1, v2.y - 1, Color.red);
                texture.SetPixel(v2.x - 1, v2.y + 1, Color.red);
                texture.SetPixel(v2.x - 1, v2.y, Color.red);
                texture.SetPixel(v2.x - 1, v2.y - 1, Color.red);
            }
            last = to;
            texture.Apply();
        }

        void DrawGraphBlue(IObservable<float> sequence)
        {
            var last = new Vector2(150, 150);
            var totalSeconds = 0f;
            sequence.FrameTimeInterval().Subscribe(s =>
            {
                totalSeconds += (float)s.Interval.TotalSeconds;
                var x = (int)((width) * (totalSeconds / 1.0f)) + 150;
                var y = (int)(s.Value * (height)) + 150;

                var to = new Vector2(x, y);
                foreach (var v2 in Enumerable.Range(0, 101).Select(i => Vector2.Lerp(last, to, (float)i / 100.0f)).Select(t => new { x = (int)t.x, y = (int)t.y }).Distinct())
                {
                    // bold
                    texture.SetPixel(v2.x, v2.y, Color.blue);
                    texture.SetPixel(v2.x + 1, v2.y, Color.blue);
                    texture.SetPixel(v2.x + 1, v2.y + 1, Color.blue);
                    texture.SetPixel(v2.x + 1, v2.y - 1, Color.blue);
                    texture.SetPixel(v2.x - 1, v2.y + 1, Color.blue);
                    texture.SetPixel(v2.x - 1, v2.y, Color.blue);
                    texture.SetPixel(v2.x - 1, v2.y - 1, Color.blue);
                }
                last = to;
                texture.Apply();
            });
        }

        void MoveStart(IObservable<float> sequence)
        {
            var last = new Vector2(150, 150);
            var totalSeconds = 0f;
            target.position = original;
            ResetGraph();
            sequence.FrameTimeInterval().Subscribe(x =>
            {
                totalSeconds += (float)x.Interval.TotalSeconds;
                DrawGraph(ref last, totalSeconds, x.Value);
                TweenX(target, x.Value);
            });
        }

        void OnGUI()
        {
            if (GUILayout.Button("Linear"))
            {
                MoveStart(ObservableEasing.Linear(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.linear));
            }

            if (GUILayout.Button("EaseInSine"))
            {
                MoveStart(ObservableEasing.EaseInSine(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInSine));
            }

            if (GUILayout.Button("EaseOutSine"))
            {
                MoveStart(ObservableEasing.EaseOutSine(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeOutSine));
            }

            if (GUILayout.Button("EaseInOutSine"))
            {
                MoveStart(ObservableEasing.EaseInOutSine(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInOutSine));
            }

            if (GUILayout.Button("EaseInQuad"))
            {
                MoveStart(ObservableEasing.EaseInQuad(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInQuad));
            }

            if (GUILayout.Button("EaseOutQuad"))
            {
                MoveStart(ObservableEasing.EaseOutQuad(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeOutQuad));
            }

            if (GUILayout.Button("EaseInOutQuad"))
            {
                MoveStart(ObservableEasing.EaseInOutQuad(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInOutQuad));
            }

            if (GUILayout.Button("EaseInCubic"))
            {
                MoveStart(ObservableEasing.EaseInCubic(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInCubic));
            }

            if (GUILayout.Button("EaseOutCubic"))
            {
                MoveStart(ObservableEasing.EaseOutCubic(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeOutCubic));
            }

            if (GUILayout.Button("EaseInOutCubic"))
            {
                MoveStart(ObservableEasing.EaseInOutCubic(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInOutCubic));
            }

            if (GUILayout.Button("EaseInQuart"))
            {
                MoveStart(ObservableEasing.EaseInQuart(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInQuart));
            }

            if (GUILayout.Button("EaseOutQuart"))
            {
                MoveStart(ObservableEasing.EaseOutQuart(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeOutQuart));
            }

            if (GUILayout.Button("EaseInOutQuart"))
            {
                MoveStart(ObservableEasing.EaseInOutQuart(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInOutQuart));
            }

            if (GUILayout.Button("EaseInQuint"))
            {
                MoveStart(ObservableEasing.EaseInQuint(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInQuint));
            }

            if (GUILayout.Button("EaseOutQuint"))
            {
                MoveStart(ObservableEasing.EaseOutQuint(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeOutQuint));
            }

            if (GUILayout.Button("EaseInOutQuint"))
            {
                MoveStart(ObservableEasing.EaseInOutQuint(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInOutQuint));
            }

            if (GUILayout.Button("EaseInExpo"))
            {
                MoveStart(ObservableEasing.EaseInExpo(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInExpo));
            }

            if (GUILayout.Button("EaseOutExpo"))
            {
                MoveStart(ObservableEasing.EaseOutExpo(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeOutExpo));
            }

            if (GUILayout.Button("EaseInOutExpo"))
            {
                MoveStart(ObservableEasing.EaseInOutExpo(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInOutExpo));
            }

            if (GUILayout.Button("EaseInCirc"))
            {
                MoveStart(ObservableEasing.EaseInCirc(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInCirc));
            }

            if (GUILayout.Button("EaseOutCirc"))
            {
                MoveStart(ObservableEasing.EaseOutCirc(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeOutCirc));
            }

            if (GUILayout.Button("EaseInOutCirc"))
            {
                MoveStart(ObservableEasing.EaseInOutCirc(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInOutCirc));
            }

            if (GUILayout.Button("EaseInBack"))
            {
                MoveStart(ObservableEasing.EaseInBack(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInBack));
            }

            if (GUILayout.Button("EaseOutBack"))
            {
                MoveStart(ObservableEasing.EaseOutBack(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeOutBack));
            }

            if (GUILayout.Button("EaseInOutBack"))
            {
                MoveStart(ObservableEasing.EaseInOutBack(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInOutBack));
            }

            if (GUILayout.Button("EaseInElastic"))
            {
                MoveStart(ObservableEasing.EaseInElastic(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInElastic));
            }

            if (GUILayout.Button("EaseOutElastic"))
            {
                MoveStart(ObservableEasing.EaseOutElastic(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeOutElastic));
            }

            if (GUILayout.Button("EaseInOutElastic"))
            {
                MoveStart(ObservableEasing.EaseInOutElastic(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInOutElastic));
            }

            if (GUILayout.Button("EaseInBounce"))
            {
                MoveStart(ObservableEasing.EaseInBounce(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInBounce));
            }

            if (GUILayout.Button("EaseOutBounce"))
            {
                MoveStart(ObservableEasing.EaseOutBounce(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeOutBounce));
            }

            if (GUILayout.Button("EaseInOutBounce"))
            {
                MoveStart(ObservableEasing.EaseInOutBounce(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInOutBounce));
            }
        }

        // reference:)
        IObservable<float> LeanTweenObservable(LeanTweenType easingType)
        {
            const float DefaultOvershoot = 1.70158f;
            const float DefaultPeriod = 0.3f;

            return Observable.Create<float>(observer =>
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.name = "dummy";
                cube.transform.position = new Vector3(0, 0, 0);
                cube.SetActive(false);

                //cube.move
                LeanTween.moveX(cube, 1.0f, 1.0f)
                .setOvershoot(DefaultOvershoot)
                .setPeriod(DefaultPeriod)
                .setOnUpdate(x =>
                 {
                     observer.OnNext(x);
                 })
                .setOnComplete(() =>
                {
                    observer.OnCompleted();
                })
                .setEase(easingType);
                return Disposable.Empty;
            });
        }
    }
}