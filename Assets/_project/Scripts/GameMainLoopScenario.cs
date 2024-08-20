using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using ZeroSDK.UIBuilder.Core;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace _project.Scripts
{
    [DefaultExecutionOrder(1)]
    public sealed class GameMainLoopScenario : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        [SerializeField] private RocketGameLevelsList rocketGameLevelsList;
        
        private ewfrvve _lastScreenTemp;
        private LevelData lastRocketGameLevel;
        private int _availableLevelsCount = 1;

        private async void Awake()
        {
            if (PlayerPrefs.HasKey("Levels"))
            {
                _availableLevelsCount = Mathf.Max(1, PlayerPrefs.GetInt("Levels"));
            }

            uiManager.Init();
            InitUIWindowsSync();
            
            
            uiManager.ewregtfhnfbewfregtr<rewregtgfnhbfefregbf>();
            await UniTask.WaitForSeconds(2);
            TryShowPopupOrMenu();
        }

        private void InitUIWindowsSync()
        {
            var policyPopupScreen = uiManager.ewregtrbfhgffwregtbf<wfegrbv>();
            policyPopupScreen.wg4wegweg += () =>
            {
                PlayerPrefs.SetInt("PolicySkipped", 1);
                uiManager.regtvfevrb<ewretgrhgnbfrwefregtrhn>();
            };
            policyPopupScreen.geververgerg += () => uiManager.regtvfevrb<rfwgerbve>();


            var ewregtrhngfregtrhnh = uiManager.ewregtrbfhgffwregtbf<ewretgrhgnbfrwefregtrhn>();
            ewregtrhngfregtrhnh.erwegtgfhbgfefrgetrnfh += () => uiManager.regtvfevrb<rfwgerbve>();
            ewregtrhngfregtrhnh.eregtfhnghbgfewfregtfhn += () => uiManager.regtvfevrb<rgtbefrgf>();
            ewregtrhngfregtrhnh.eregtfhnghbgrfewfregtg += () => ShowOptionsScreen(ewregtrhngfregtrhnh);
            ewregtrhngfregtrhnh.eretghfngewrgetfnh += Application.Quit;


            var rwtehrnfgwrgethr = uiManager.ewregtrbfhgffwregtbf<rfwgerbve>();
            rwtehrnfgwrgethr.rewegtrhnggewrgetgf += () =>
            {
                PlayerPrefs.SetInt("PolicySkipped", 1);
                uiManager.regtvfevrb<ewretgrhgnbfrwefregtrhn>();
            };


            var ewrgethfhngfwrgethrn = uiManager.ewregtrbfhgffwregtbf<rwegtrhbewfregtrb>();
            ewrgethfhngfwrgethrn.ewregtegrhtgn += () => uiManager.regtvfevrb(_lastScreenTemp.GetType());


            var wregtrbhfgfwregtrbnh = uiManager.ewregtrbfhgffwregtbf<rgtbefrgf>();
            wregtrbhfgfwregtrbnh.gtryhgbfrefrgtgbfhn(_availableLevelsCount);
            wregtrbhfgfwregtrbnh.rtgrhyynjhnbgvfergtrgb += () => uiManager.regtvfevrb<ewretgrhgnbfrwefregtrhn>();
            wregtrbhfgfwregtrbnh.ergthngbgfregbfhg += level =>
            {
                if(level > _availableLevelsCount-1)
                    return;
                
                var screen = uiManager.regtvfevrb<erfgtbvferg>();

                var wdweefrverg = rocketGameLevelsList.GameRocketLevels[level];
                lastRocketGameLevel = wdweefrverg;
                
                screen.StartGame(wdweefrverg);
            };


            var wefwfwefwefw = uiManager.ewregtrbfhgffwregtbf<erfgtbvferg>();

            wefwfwefwefw.wfwefwefwf += () => uiManager.regtvfevrb<rgtbefrgf>();
            wefwfwefwefw.fwefwefwef += () => ShowOptionsScreen(wefwfwefwefw);

            wefwfwefwefw.ewfwefwefwe += () =>
            {
                uiManager.regtvfevrb<rgtbefrgf>();
                wefwfwefwefw.efwefwefwef(false, true);
            };
            
            wefwfwefwefw.ewfwefwefwef += (data, score) =>
            {
                lastRocketGameLevel = data;
                _availableLevelsCount = Mathf.Clamp(_availableLevelsCount + 1, 0, rocketGameLevelsList.GameRocketLevels.Count);
                
                PlayerPrefs.SetInt("Levels", _availableLevelsCount);
                PlayerPrefs.SetInt($"Score{data.index}", score);
                PlayerPrefs.Save();
                
                wregtrbhfgfwregtrbnh.gtryhgbfrefrgtgbfhn(_availableLevelsCount);
            };

            wefwfwefwefw.OnRetryButton += () =>
            {
                var level = rocketGameLevelsList.GameRocketLevels.First(l => l == lastRocketGameLevel);
                wefwfwefwefw.StartGame(level);
            };

            wefwfwefwefw.OnNextButton += () =>
            {
                for (int i = 0; i < rocketGameLevelsList.GameRocketLevels.Count; i++)
                {
                    if (lastRocketGameLevel == rocketGameLevelsList.GameRocketLevels[i])
                    {
                        var index = Mathf.Clamp(i + 1, 0, rocketGameLevelsList.GameRocketLevels.Count);
                        wefwfwefwefw.StartGame(rocketGameLevelsList.GameRocketLevels[index]);
                        return;
                    }
                }
            };
        }

        private void TryShowPopupOrMenu()
        {
            if (PlayerPrefs.HasKey("PolicySkipped") == false || PlayerPrefs.GetInt("PolicySkipped") == 0)
                uiManager.regtvfevrb<wfegrbv>();
            else
                uiManager.regtvfevrb<ewretgrhgnbfrwefregtrhn>();
        }

        private rwegtrhbewfregtrb ShowOptionsScreen(ewfrvve lastScreen)
        {
            _lastScreenTemp = lastScreen;
            return uiManager.regtvfevrb<rwegtrhbewfregtrb>();
        }
    }
}