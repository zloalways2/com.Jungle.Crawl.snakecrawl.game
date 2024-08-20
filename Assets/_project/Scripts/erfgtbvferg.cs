using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZeroSDK.UIBuilder.AddOns.Button;
using ZeroSDK.UIBuilder.Core;
using ZeroSDK.UIBuilder.Core.UIElements;
using Random = UnityEngine.Random;

namespace _project.Scripts
{
    public sealed class erfgtbvferg : ewfrvve
    {
        [SerializeField] private ButtonView exitButton;
        [SerializeField] private ButtonView settingsButton;
        [SerializeField] private ButtonView upButton;
        [SerializeField] private ButtonView downButton;
        [SerializeField] private ButtonView leftButton;
        [SerializeField] private ButtonView rightButton;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private View gameView;
        [SerializeField] private View winView;
        [SerializeField] private TextMeshProUGUI winScoreText;
        [SerializeField] private TextMeshProUGUI winHeader;
        [SerializeField] private ButtonView nextButton;
        [SerializeField] private ButtonView menuButton;
        [SerializeField] private ButtonView retryButton;
        [SerializeField] private Transform spawnContainer;
        [SerializeField] private Vector2 fieldOffset;

        [SerializeField] Image snakeHeadPrefab;
        [SerializeField] Image snakeBodyPrefab;
        [SerializeField] Image rewardPrefab;
        [SerializeField] Image bombPrefab;
        [SerializeField] Sprite downLeftSprite;
        [SerializeField] Sprite downRightSprite;
        [SerializeField] Sprite downUpSprite;

        private Vector2Int rgtbgfvfedfrgtrh = Vector2Int.right;
        private readonly List<Vector2Int> ergtrhyntbgfrewfregtrbg = new List<Vector2Int>();
        private readonly List<Image> erfgtrhngbgfrergtbgf = new List<Image>();


        private readonly fwefwefwefwe[,] grtfvdfrgt = new fwefwefwefwe[16, 16];
        private Dictionary<Vector2Int, RectTransform> erfgtrbfvdefer = new Dictionary<Vector2Int, RectTransform>();


        private CancellationTokenSource rergtrhynbgrfegtbrg;
        private int erfgththngbgfrregtrgbfh;


        public event Action ewfwefwefwe
        {
            add => exitButton.OnClickEvent += value;
            remove => exitButton.OnClickEvent += value;
        }

        public event Action fwefwefwef
        {
            add => settingsButton.OnClickEvent += value;
            remove => settingsButton.OnClickEvent += value;
        }

        public event Action OnNextButton
        {
            add => nextButton.OnClickEvent += value;
            remove => nextButton.OnClickEvent += value;
        }

        public event Action wfwefwefwf
        {
            add => menuButton.OnClickEvent += value;
            remove => menuButton.OnClickEvent += value;
        }


        public event Action OnRetryButton
        {
            add => retryButton.OnClickEvent += value;
            remove => retryButton.OnClickEvent += value;
        }

        public event Action<LevelData, int> ewfwefwefwef;

        [SerializeField] private bool DEBUG_FINISH;

        private void Start()
        {
            upButton.OnClickEvent += () =>
            {
                if (rgtbgfvfedfrgtrh != Vector2Int.down) rgtbgfvfedfrgtrh = Vector2Int.up;
            };

            downButton.OnClickEvent += () =>
            {
                if (rgtbgfvfedfrgtrh != Vector2Int.up) rgtbgfvfedfrgtrh = Vector2Int.down;
            };

            leftButton.OnClickEvent += () =>
            {
                if (rgtbgfvfedfrgtrh != Vector2Int.right) rgtbgfvfedfrgtrh = Vector2Int.left;
            };
            
            rightButton.OnClickEvent += () =>
            {
                if (rgtbgfvfedfrgtrh != Vector2Int.left) rgtbgfvfedfrgtrh = Vector2Int.right;
            };
        }


        public async void StartGame(LevelData data)
        {
            gameView.ShowImmediately();
            winView.HideImmediately();

            rergtrhynbgrfegtbrg?.Cancel();
            rergtrhynbgrfegtbrg = new CancellationTokenSource();

            var regfdcedfrg = grtfvdfrgt.GetLength(0);
            var rgtrbgfvefrgt = grtfvdfrgt.GetLength(1);


            for (int i = 0; i < grtfvdfrgt.GetLength(0); i++)
            {
                for (int j = 0; j < grtfvdfrgt.GetLength(1); j++)
                {
                    grtfvdfrgt[i, j] = fwefwefwefwe.bfvdc;
                }
            }


            foreach (var efwefwef in erfgtrbfvdefer)
                Destroy(efwefwef.Value.gameObject);
            erfgtrbfvdefer.Clear();

            foreach (var efwefwefwef in erfgtrhngbgfrergtbgf)
                Destroy(efwefwefwef.gameObject);

            ntrterhergwre(new Vector2Int(0, 0));
            ntrterhergwre(new Vector2Int(regfdcedfrg - 1, 0));
            ntrterhergwre(new Vector2Int(0, rgtrbgfvefrgt - 1));
            ntrterhergwre(new Vector2Int(regfdcedfrg - 1, rgtrbgfvefrgt - 1));


            erfgtrhngbgfrergtbgf.Clear();
            ergtrhyntbgfrewfregtrbg.Clear();


            ewfewfwefw((new Vector2Int(regfdcedfrg / 2, rgtrbgfvefrgt / 2)), snakeHeadPrefab);

            var efewfwef = data.time;
            var fwefwef = 0f;
            var egewgweg = 0f;
            var ggwgergerg = 0f;
            erfgththngbgfrregtrgbfh = 0;

            timeText.text = $"Time: {(int) efewfwef}s";
            scoreText.text = "Score: 0000p";

            while (efewfwef > 0 && DEBUG_FINISH == false)
            {
                await UniTask.Yield(rergtrhynbgrfegtbrg.Token).SuppressCancellationThrow();

                efewfwef -= Time.deltaTime;
                fwefwef += Time.deltaTime;
                egewgweg += Time.deltaTime;
                ggwgergerg += Time.deltaTime;
                timeText.text = $"Time: {(int) efewfwef}s";
                scoreText.text = $"Score: {erfgththngbgfrregtrgbfh:0000}s";


                if (rergtrhynbgrfegtbrg.IsCancellationRequested)
                    return;

                if (fwefwef >= data.tickTime)
                {
                    ewfwefwfwef();
                    fwefwef = 0f;
                }

                if (egewgweg >= data.bombSpawnTime)
                {
                    efwefwefwef(bgfvdcsvwvew());
                    egewgweg = 0f;
                }

                if (ggwgergerg >= data.rewardSpawnTime)
                {
                    ntrterhergwre(bgfvdcsvwvew());
                    ggwgergerg = 0f;
                }
            }

            DEBUG_FINISH = false;

            efwefwefwef(true);
            ewfwefwefwef?.Invoke(data, erfgththngbgfrregtrgbfh);

            gameView.Hide();
        }

        public void efwefwefwef(bool efwefwefwef, bool efwefwefwe = false)
        {
            winHeader.text = efwefwefwef ? "Level complete!" : "Level lose";

            rergtrhynbgrfegtbrg?.Cancel();
            winScoreText.text = $"Score:\n{erfgththngbgfrregtrgbfh:0000}s";

            if (efwefwefwe == false)
            {
                gameView.Hide();
                winView.Show();
            }
        }

        protected override void OnShowStart() =>
            UIManager.I.ewregtrbfhgffwregtbf<ewrfegtrbthgbgfredwfrgtb>().regtryhngfgfefregtbfhn();

        protected override void OnHideStart() =>
            UIManager.I.ewregtrbfhgffwregtbf<ewrfegtrbthgbgfredwfrgtb>().erwegthfnbgfewrfgetfnh();

        private void ewfwefwfwef()
        {
            efwefwefwef();
        }

        private void efwefwefwef()
        {
            var wefwefwef = grtfvdfrgt.GetLength(0);
            var efwefwefw = grtfvdfrgt.GetLength(1);

            var fefwfwefwefwe = ergtrhyntbgfrewfregtrbg[0] + rgtbgfvfedfrgtrh;

            if (fefwfwefwefwe.x < 0) fefwfwefwefwe.x = wefwefwef - 1;
            if (fefwfwefwefwe.y < 0) fefwfwefwefwe.y = efwefwefw - 1;
            if (fefwfwefwefwe.x >= wefwefwef) fefwfwefwefwe.x = 0;
            if (fefwfwefwefwe.y >= efwefwefw) fefwfwefwefwe.y = 0;

            switch (grtfvdfrgt[fefwfwefwefwe.x, fefwfwefwefwe.y])
            {
                case fwefwefwefwe.ewfwefwefw:
                    Destroy(erfgtrbfvdefer[fefwfwefwefwe].gameObject);
                    erfgtrbfvdefer.Remove(fefwfwefwefwe);
                    ewfewfwefw(fefwfwefwefwe, snakeBodyPrefab);
                    erfgththngbgfrregtrgbfh += 100;
                    break;
                case fwefwefwefwe.efwefwefwe:
                    Destroy(erfgtrbfvdefer[fefwfwefwefwe].gameObject);
                    erfgtrbfvdefer.Remove(fefwfwefwefwe);
                    efwefwefwef(false);
                    break;
                case fwefwefwefwe.fwefwefw:
                    efwefwefwef(false);
                    return;
            }

            var fwefwfeewfwe = ergtrhyntbgfrewfregtrbg[ergtrhyntbgfrewfregtrbg.Count - 1];
            grtfvdfrgt[fwefwfeewfwe.x, fwefwfeewfwe.y] = fwefwefwefwe.bfvdc;
            grtfvdfrgt[fefwfwefwefwe.x, fefwfwefwefwe.y] = fwefwefwefwe.fwefwefw;

            for (int i = ergtrhyntbgfrewfregtrbg.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    ergtrhyntbgfrewfregtrbg[i] = fefwfwefwefwe;
                    continue;
                }

                ergtrhyntbgfrewfregtrbg[i] = ergtrhyntbgfrewfregtrbg[i - 1];
            }

            var efwefewf = snakeHeadPrefab.GetComponent<RectTransform>();
            for (int i = 0; i < ergtrhyntbgfrewfregtrbg.Count; i++)
            {
                (erfgtrhngbgfrergtbgf[i].transform as RectTransform).anchoredPosition = ergtrhyntbgfrewfregtrbg[i] * efwefewf.sizeDelta + fieldOffset;
            }

            for (int i = 0; i < ergtrhyntbgfrewfregtrbg.Count; i++)
            {
                if (i == 0)
                {
                    var efwefewfwe = new Vector3();
                    if (rgtbgfvfedfrgtrh == Vector2Int.up) efwefewfwe.z = 90;
                    else if (rgtbgfvfedfrgtrh == Vector2Int.right) efwefewfwe.z = 0;
                    else if (rgtbgfvfedfrgtrh == Vector2Int.down) efwefewfwe.z = -90;
                    else if (rgtbgfvfedfrgtrh == Vector2Int.left) efwefewfwe.z = 180;
                    erfgtrhngbgfrergtbgf[i].transform.eulerAngles = efwefewfwe;
                    continue;
                }

                var efwe = ergtrhyntbgfrewfregtrbg[i - 1];
                var efwefwef = ergtrhyntbgfrewfregtrbg[i];

                if (i == ergtrhyntbgfrewfregtrbg.Count - 1)
                {
                    if (efwefwef.x == efwe.x)
                    {
                        // vertical
                        erfgtrhngbgfrergtbgf[i].sprite = downUpSprite;
                        erfgtrhngbgfrergtbgf[i].transform.eulerAngles = new Vector3();
                    }
                    else
                    {
                        // horizontal
                        erfgtrhngbgfrergtbgf[i].sprite = downUpSprite;
                        erfgtrhngbgfrergtbgf[i].transform.eulerAngles = new Vector3(0, 0, 90);
                    }

                    continue;
                }

                var fwefw = ergtrhyntbgfrewfregtrbg[i + 1];

                var htrgefed = efwe.x == fwefw.x;
                var juhygtbfvdrfs = efwe.y == fwefw.y;

                if (htrgefed == false && juhygtbfvdrfs == false)
                {
                    // diagonal

                    var pX = efwe.x;
                    var nX = fwefw.x;
                    var pY = efwe.y;
                    var nY = fwefw.y;


                    var juthygtdf = efwe.y > efwefwef.y;
                    var hbgfvdfcsd = efwe.x > efwefwef.x;
                    var yrhtgerf = efwe.y < efwefwef.y;
                    var yhrtgdfds = efwe.x < efwefwef.x;

                    var thybtrgvdf = downUpSprite;
                    var nbgdvf = new Vector3();


                    if (juthygtdf && pX < nX && pY > nY)
                    {
                        thybtrgvdf = downRightSprite;
                        nbgdvf = new Vector3(0, 0, 90);
                    }

                    else if (hbgfvdfcsd && pX > nX && pY < nY)
                    {
                        thybtrgvdf = downRightSprite;
                        nbgdvf = new Vector3(0, 0, 90);
                    }


                    else if (yhrtgdfds && pX < nX && pY < nY)
                    {
                        thybtrgvdf = downLeftSprite;
                        nbgdvf = new Vector3(0, 0, -90);
                    }

                    else if (juthygtdf && pX > nX && pY > nY)
                    {
                        thybtrgvdf = downLeftSprite;
                        nbgdvf = new Vector3(0, 0, -90);
                    }


                    else if (yhrtgdfds && pX < nX && pY > nY)
                    {
                        thybtrgvdf = downLeftSprite;
                        nbgdvf = new Vector3(0, 0, 0);
                    }

                    else if (yrhtgerf && pX > nX && pY < nY)
                    {
                        thybtrgvdf = downLeftSprite;
                        nbgdvf = new Vector3(0, 0, 0);
                    }


                    else if (yrhtgerf && pX < nX && pY < nY)
                    {
                        thybtrgvdf = downRightSprite;
                        nbgdvf = new Vector3(0, 0, 0);
                    }

                    else if (hbgfvdfcsd && pX > nX && pY > nY)
                    {
                        thybtrgvdf = downRightSprite;
                        nbgdvf = new Vector3(0, 0, 0);
                    }


                    erfgtrhngbgfrergtbgf[i].sprite = thybtrgvdf;
                    erfgtrhngbgfrergtbgf[i].transform.eulerAngles = nbgdvf;
                }
                else if (htrgefed)
                {
                    // vertical
                    erfgtrhngbgfrergtbgf[i].sprite = downUpSprite;
                    erfgtrhngbgfrergtbgf[i].transform.eulerAngles = new Vector3();
                }
                else
                {
                    // horizontal
                    erfgtrhngbgfrergtbgf[i].sprite = downUpSprite;
                    erfgtrhngbgfrergtbgf[i].transform.eulerAngles = new Vector3(0, 0, 90);
                }
            }
        }

        private void ewfewfwefw(Vector2Int nhbgfvdc, Image hbvcsd)
        {
            ergtrhyntbgfrewfregtrbg.Add(nhbgfvdc);

            var htbdfvscd = Instantiate(hbvcsd, spawnContainer);
            erfgtrhngbgfrergtbgf.Add(htbdfvscd);
        }

        private void ntrterhergwre(Vector2Int ggegergreg)
        {
            grtfvdfrgt[ggegergreg.x, ggegergreg.y] = fwefwefwefwe.ewfwefwefw;

            var ntbfvd = Instantiate(rewardPrefab, spawnContainer);
            var nhbfgvdfd = ntbfvd.transform as RectTransform;
            var headRect = snakeHeadPrefab.GetComponent<RectTransform>();
            nhbfgvdfd.anchoredPosition = ggegergreg * headRect.sizeDelta + fieldOffset;
            erfgtrbfvdefer[ggegergreg] = nhbfgvdfd;
        }

        private void efwefwefwef(Vector2Int h3regergew)
        {
            grtfvdfrgt[h3regergew.x, h3regergew.y] = fwefwefwefwe.efwefwefwe;

            var fewfwefwef = Instantiate(bombPrefab, spawnContainer);
            var egwegwegw = fewfwefwef.transform as RectTransform;
            var headRect = snakeHeadPrefab.GetComponent<RectTransform>();
            egwegwegw.anchoredPosition = h3regergew * headRect.sizeDelta + fieldOffset;
            erfgtrbfvdefer[h3regergew] = egwegwegw;
        }

        private Vector2Int bgfvdcsvwvew()
        {
            Vector2Int output;
            var x = grtfvdfrgt.GetLength(0);
            var y = grtfvdfrgt.GetLength(1);

            do
            {
                output = new Vector2Int(Random.Range(0, x - 1), Random.Range(0, y - 1));
            } while (grtfvdfrgt[output.x, output.y] != fwefwefwefwe.bfvdc);

            return output;
        }

        private enum fwefwefwefwe
        {
            bfvdc,
            fwefwefw,
            efwefwefwe,
            ewfwefwefw
        }
    }
}