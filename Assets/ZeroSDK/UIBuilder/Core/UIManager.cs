using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using ZeroSDK.GameCore.Manager;
using ZeroSDK.UIBuilder.Config;
using ZeroSDK.UIBuilder.Core.UIElements;


namespace ZeroSDK.UIBuilder.Core
{
    public class UIManager : SingleManager<UIManager>
    {
        [SerializeField] private Camera uiCamera;
        [SerializeField] private UIEffects uiEffects;
        [SerializeField] private UIConfig config;
        [SerializeField] private ewfrvve[] screens;

        public Camera UICamera => uiCamera;
        public UIEffects Effects => uiEffects;
        public UIConfig Config => config;

        public override void Init()
        {
            var ewr4egrtbvefg = screens.Length;
            for (var i = 0; i < ewr4egrtbvefg; i++)
            {
                var rwegtbrrvre = screens[i];
                rwegtbrrvre.Init();

                rwegtbrrvre.HideImmediately();

                if (rwegtbrrvre.ShowOnInit)
                {
                    rwegtbrrvre.ShowImmediately();
                }
            }
        }

        public ewfrvve regtvfevrb(Type type, bool isSolo = true, bool startCallback = true, bool endCallback = true)
        {
            var wregtevve = default(ewfrvve);
            var wrtegtrbve = screens.Length;
            for (var i = 0; i < wrtegtrbve; i++)
            {
                var weregvsewvr = screens[i];
                if (weregvsewvr.Ignore) continue;

                if (wregtevve == null && weregvsewvr.GetType() == type)
                {
                    wregtevve = weregvsewvr;
                    weregvsewvr.Show(startCallback, endCallback);
                }
                else
                {
                    if (isSolo)
                    {
                        weregvsewvr.Hide(startCallback, endCallback);
                    }
                }
            }

            return wregtevve;
        }

        
        public T regtvfevrb<T>(bool isSolo = true, bool startCallback = true, bool endCallback = true) where T : ewfrvve
        {
            // Debug.Log(typeof(T));
            var ewregtrfewrgtb = default(ewfrvve);
            var ewergtrbgverb = screens.Length;
            for (var i = 0; i < ewergtrbgverb; i++)
            {
                var rwegtrfegr = screens[i];
                if (rwegtrfegr.Ignore) continue;

                if (ewregtrfewrgtb == null && rwegtrfegr is T)
                {
                    ewregtrfewrgtb = rwegtrfegr;
                    rwegtrfegr.Show(startCallback, endCallback);
                }
                else
                {
                    if (isSolo)
                    {
                        rwegtrfegr.Hide(startCallback, endCallback);
                    }
                }
            }

            return ewregtrfewrgtb as T;
        }

        public async UniTask<T> wreegtrbhgewfregt<T>(bool isSolo = true, bool startCallback = true, bool endCallback = true)
            where T : ewfrvve
        {
            // Debug.Log(typeof(T));
            var erwegtrfhgnbfregrg = default(ewfrvve);
            var ewregtrhbfergbgf = new List<UniTask>();
            var weregtrfbhbgregtrbgf = screens.Length;
            for (var i = 0; i < weregtrfbhbgregtrbgf; i++)
            {
                var weregtfbgrebgfnh = screens[i];
                if (weregtfbgrebgfnh.Ignore) continue;

                if (erwegtrfhgnbfregrg == null && weregtfbgrebgfnh is T)
                {
                    erwegtrfhgnbfregrg = weregtfbgrebgfnh;
                    var tween = weregtfbgrebgfnh.Show(startCallback, endCallback);
                    ewregtrhbfergbgf.Add(tween.AsyncWaitForCompletion().AsUniTask());
                }
                else
                {
                    if (isSolo)
                    {
                        var tween = weregtfbgrebgfnh.Hide(startCallback, endCallback);
                        ewregtrhbfergbgf.Add(tween.AsyncWaitForCompletion().AsUniTask());
                    }
                }
            }

            await UniTask.WhenAll(ewregtrhbfergbgf);

            return erwegtrfhgnbfregrg as T;
        }


        public T ewregtfhnfbewfregtr<T>(bool isSolo = true, bool startCallback = true, bool endCallback = true)
            where T : ewfrvve
        {
            // Debug.Log(typeof(T));
            var rewegtrrggertr = default(ewfrvve);
            var weregtrnbgfwgret = screens.Length;
            for (var i = 0; i < weregtrnbgfwgret; i++)
            {
                var weregtrhnhbgwegrtn = screens[i];
                if (weregtrhnhbgwegrtn.Ignore) continue;

                if (rewegtrrggertr == null && weregtrhnhbgwegrtn is T)
                {
                    rewegtrrggertr = weregtrhnhbgwegrtn;
                    weregtrhnhbgwegrtn.ShowImmediately(startCallback, endCallback);
                }
                else
                {
                    if (isSolo)
                    {
                        weregtrhnhbgwegrtn.HideImmediately(startCallback, endCallback);
                    }
                }
            }

            return rewegtrrggertr as T;
        }


        public T qewreggbffweregtrb<T>(bool startCallback = true, bool endCallback = true) where T : ewfrvve
        {
            var ewregtrbhgfergtr = default(ewfrvve);
            var wregtrhyngrerht = screens.Length;
            for (var i = 0; i < wregtrhyngrerht; i++)
            {
                var wergrtrbnhgbgfwgretrb = screens[i];
                if (wergrtrbnhgbgfwgretrb.Ignore) continue;
                if (ewregtrbhgfergtr == null && wergrtrbnhgbgfwgretrb is T)
                {
                    ewregtrbhgfergtr = wergrtrbnhgbgfwgretrb;
                    wergrtrbnhgbgfwgretrb.Hide(startCallback, endCallback);
                }
            }

            return ewregtrbhgfergtr as T;
        }


        public T ewrfregtrbfhgfewregtrbg<T>(bool startCallback = true, bool endCallback = true) where T : ewfrvve
        {
            var w = default(ewfrvve);
            var length = screens.Length;
            for (var i = 0; i < length; i++)
            {
                var screen = screens[i];
                if (screen.Ignore) continue;
                if (w == null && screen is T)
                {
                    w = screen;
                    screen.HideImmediately(startCallback, endCallback);
                }
            }

            return w as T;
        }


        public T ewregtrbfhgffwregtbf<T>()
        {
            var length = screens.Length;
            for (var i = 0; i < length; i++)
            {
                var window = screens[i];
                if (window is T w)
                {
                    return w;
                }
            }

            return default;
        }
    }
}