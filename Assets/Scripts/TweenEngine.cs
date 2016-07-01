using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ReMotion
{
    internal class TweenEngine
    {
        internal static TweenEngine Instance = new TweenEngine();

        const int InitialSize = 16;

        readonly object runningAndQueueLock = new object();
        readonly object arrayLock = new object();
        readonly Action<Exception> unhandledExceptionCallback;

        int tail = 0;
        bool running = false;
        ITween[] tweens = new ITween[InitialSize];
        Queue<ITween> waitQueue = new Queue<ITween>();

        private TweenEngine()
        {
            this.unhandledExceptionCallback = ex => Debug.LogException(ex);
            MainThreadDispatcher.StartUpdateMicroCoroutine(RunEveryFrame());
        }

        public static void AddTween(ITween tween)
        {
            Instance.Add(tween);
        }

        IEnumerator RunEveryFrame()
        {
            while (true)
            {
                yield return null;
                Instance.Run(Time.deltaTime, Time.unscaledDeltaTime);
            }
        }

        public void Add(ITween tween)
        {
            lock (runningAndQueueLock)
            {
                if (running)
                {
                    waitQueue.Enqueue(tween);
                    return;
                }
            }

            // worst case at multi threading, wait lock until finish Run() but it is super rarely.

            lock (arrayLock)
            {
                // Ensure Capacity
                if (tweens.Length == tail)
                {
                    Array.Resize(ref tweens, checked(tail * 2));
                }
                tweens[tail++] = tween;
            }
        }

        public void Run(float deltaTime, float unscaledDeltaTime)
        {
            lock (runningAndQueueLock)
            {
                running = true;
            }

            lock (arrayLock)
            {
                var j = tail - 1;

                // eliminate array-bound check for i
                for (int i = 0; i < tweens.Length; i++)
                {
                    var tween = tweens[i];
                    if (tween != null)
                    {
                        try
                        {
                            if (!tween.MoveNext(ref deltaTime, ref unscaledDeltaTime))
                            {
                                tweens[i] = null;
                            }
                            else
                            {
                                continue; // next i 
                            }
                        }
                        catch (Exception ex)
                        {
                            tweens[i] = null;
                            try
                            {
                                unhandledExceptionCallback(ex);
                            }
                            catch { }
                        }
                    }

                    // find null, loop from tail
                    while (i < j)
                    {
                        var fromTail = tweens[j];
                        if (fromTail != null)
                        {
                            try
                            {
                                if (!fromTail.MoveNext(ref deltaTime, ref unscaledDeltaTime))
                                {
                                    tweens[j] = null;
                                    j--;
                                    continue; // next j
                                }
                                else
                                {
                                    // swap
                                    tweens[i] = fromTail;
                                    tweens[j] = null;
                                    j--;
                                    goto NEXT_LOOP; // next i
                                }
                            }
                            catch (Exception ex)
                            {
                                tweens[j] = null;
                                j--;
                                try
                                {
                                    unhandledExceptionCallback(ex);
                                }
                                catch { }
                                continue; // next j
                            }
                        }
                        else
                        {
                            j--;
                        }
                    }

                    tail = i; // loop end
                    break; // LOOP END

                    NEXT_LOOP:
                    continue;
                }


                lock (runningAndQueueLock)
                {
                    running = false;
                    while (waitQueue.Count != 0)
                    {
                        if (tweens.Length == tail)
                        {
                            Array.Resize(ref tweens, checked(tail * 2));
                        }
                        tweens[tail++] = waitQueue.Dequeue();
                    }
                }
            }
        }
    }
}