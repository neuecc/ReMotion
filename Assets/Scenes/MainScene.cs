using UnityEngine;

using UniRx;
using System.Collections;
using ReMotion.Extensions;
using UnityEngine.UI;

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

        Color[] colors = new Color[300 * 300];
        Texture2D texture;

        void TweenX(Transform t, float ratio)
        {
            var v3 = new Vector3(from + diff * ratio, target.position.y, target.position.z);
            t.position = v3;
        }

        void Start()
        {
            Application.targetFrameRate = -1;

            original = target.transform.position;
            from = original.x;
            to = 2.0f;
            diff = to - from;

            texture = new Texture2D(300, 300, TextureFormat.ARGB32, false);
            graph.texture = texture;
            ResetGraph();
        }

        void ResetGraph()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var i = y * width + x;
                    colors[i] = Color.white;
                }
            }
            texture.SetPixels(colors);
            texture.Apply();
        }

        void DrawGraph(float time, float ratio)
        {
            var x = (int)(width * (time / 1.0f));
            var y = (int)(ratio * height);

            texture.SetPixel(x, y, Color.red);
            texture.Apply();
        }

        void DrawGraphBlue(IObservable<EasingState> sequence)
        {
            sequence.Subscribe(s =>
            {
                var x = (int)(width * (s.Elapsed / 1.0f));
                var y = (int)(s.Ratio * height);

                texture.SetPixel(x, y, Color.blue);
                texture.Apply();
            });
        }

        void MoveStart(IObservable<EasingState> sequence)
        {
            target.position = original;
            ResetGraph();
            sequence.Subscribe(x =>
            {
                DrawGraph(x.Elapsed, x.Ratio);
                TweenX(target, x);
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
            
            // ----

            if (GUILayout.Button("EaseInOutBounce"))
            {
                MoveStart(ObservableEasing.EaseInOutBounce(1.0f));
                DrawGraphBlue(LeanTweenObservable(LeanTweenType.easeInOutBounce));
            }
        }

        // reference:)
        IObservable<EasingState> LeanTweenObservable(LeanTweenType easingType)
        {
            return Observable.Create<EasingState>(observer =>
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.name = "dummy";
                cube.transform.position = new Vector3(0, 0, 0);
                cube.SetActive(false);
                var elapsed = 0f;

                //cube.move
                LeanTween.moveX(cube, 1.0f, 1.0f).setOnUpdate(x =>
                 {
                     observer.OnNext(new EasingState(elapsed += Time.deltaTime, x));
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