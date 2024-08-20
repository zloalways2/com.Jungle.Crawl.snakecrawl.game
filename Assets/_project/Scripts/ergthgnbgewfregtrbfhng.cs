using UnityEngine;
using ZeroSDK.Utility.Singleton;

namespace _project.Scripts
{
    public sealed class ergthgnbgewfregtrbfhng : SingleScript<ergthgnbgewfregtrbfhng>
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource coinSource;
        [SerializeField] private AudioSource pressSource;

        public override void Awake()
        {
            base.Awake();
            if (PlayerPrefs.HasKey("Music")) rwegtrbfdvfregtrbf(PlayerPrefs.GetFloat("Music"));
            if (PlayerPrefs.HasKey("Effects")) wregtrbhfgfregtbfh(PlayerPrefs.GetFloat("Effects"));
        }

        public void rwegtrbfdvfregtrbf(float v)
        {
            musicSource.volume = v;
        }

        public void wregtrbhfgfregtbfh(float v)
        {
            coinSource.volume = v;
            pressSource.volume = v;
        }

        public override void OnDestroy()
        {
            PlayerPrefs.SetFloat("Music", musicSource.volume);
            PlayerPrefs.SetFloat("Effects", coinSource.volume);

            PlayerPrefs.Save();
        }

        public void PlayPressSoundSync()
        {
            pressSource.Play();
        }
    }
}