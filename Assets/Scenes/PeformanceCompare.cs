using DG.Tweening;
using UniRx.Triggers;
using ReMotion.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ReMotion.Sandbox
{
    public class PeformanceCompare : MonoBehaviour
    {
        public Text title;
        public Text initial;
        public Text tweenTime;

        public Button buttonReMotion;
        public Button buttonDoTween;
        public Button buttonLeanTween;
        public Button buttoniTween;
        public Button buttonUween;

        bool startStopwatch = false;
        System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
        List<double> stopList = new List<double>(100000);
        List<GameObject> testObjects = new List<GameObject>(100000);

        void Start()
        {
            MainThreadDispatcher.Initialize();
            Application.targetFrameRate = -1;
            UniRx.MainThreadDispatcher.Initialize();
            LeanTween.init(20000);
            DOTween.Init(null, false, null);

            // Command
            var canExecute = new ReactiveProperty<bool>(true);

            buttonReMotion.BindOnClick(canExecute, _ => RunTween("ReMotion", xxx => xxx.transform.TweenPosition(new Vector3(10, 10, 10), 3.0f, EasingFunctions.Linear)));
            buttonDoTween.BindOnClick(canExecute, _ => RunTween("DOTween", xxx => xxx.transform.DOMove(new Vector3(10, 10, 10), 3f).SetEase(Ease.Linear)));
            buttonLeanTween.BindOnClick(canExecute, _ => RunTween("LeanTween", xxx => LeanTween.move(xxx, new Vector3(10, 10, 10), 3.0f).setEase(LeanTweenType.linear)));
            buttoniTween.BindOnClick(canExecute, _ => RunTween("iTween", xxx => iTween.MoveTo(xxx, new Vector3(10f, 10f, 10f), 3.0f)));
            buttonUween.BindOnClick(canExecute, _ => RunTween("Uween", xxx => Uween.TweenXYZ.Add(xxx, 3.0f, new Vector3(10, 10, 10))));
        }

        IObservable<Unit> RunTween(string label, Action<GameObject> invokeTween)
        {
            InitPerf();
            title.text = label;
            return Observable.TimerFrame(3)
                .Do(____ =>
                {
                    var sw = System.Diagnostics.Stopwatch.StartNew();
                    foreach (var xxx in testObjects)
                    {
                        invokeTween(xxx);
                    }
                    sw.Stop();
                    initial.text = sw.Elapsed.TotalMilliseconds.ToString("0.000") + "ms";
                })
                .DelayFrame(3)
                .Do(___ => startStopwatch = true)
                .Delay(TimeSpan.FromSeconds(5))
                .ForEachAsync(___ =>
                {
                    tweenTime.text = stopList.Where(x => x > 3.0f).Average().ToString("0.000") + "ms";
                });
        }

        void Update()
        {
            sw.Reset();
            sw.Start();
        }

        void LateUpdate()
        {
            sw.Stop();
            if (startStopwatch)
            {
                stopList.Add(sw.Elapsed.TotalMilliseconds);
            }
        }

        void InitPerf()
        {
            initial.text = "";
            tweenTime.text = "";
            startStopwatch = false;
            stopList.Clear();
            foreach (var item in testObjects)
            {
                GameObject.Destroy(item);
            }
            testObjects.Clear();
            for (int i = 0; i < 10000; i++)
            {
                var createEmpty = new GameObject("test" + i);
                testObjects.Add(createEmpty);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}