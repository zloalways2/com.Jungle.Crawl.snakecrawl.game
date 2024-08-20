using System;
using UnityEngine;
using UnityEngine.UI;
using ZeroSDK.UIBuilder.AddOns.Button;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace _project.Scripts
{
    public sealed class rwegtrhbewfregtrb : ewfrvve
    {
        [SerializeField] private ButtonView exitButton;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundSlider;

        public event Action ewregtegrhtgn
        {
            add => exitButton.OnClickEvent += value;
            remove => exitButton.OnClickEvent += value;
        }

        protected override void rgrtbfrgtbf()
        {
            if (PlayerPrefs.HasKey("Music")) musicSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("Music"));
            if (PlayerPrefs.HasKey("Effects")) soundSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("Effects"));

            musicSlider.onValueChanged.AddListener(v => ergthgnbgewfregtrbfhng.I.rwegtrbfdvfregtrbf(v));
            soundSlider.onValueChanged.AddListener(v => ergthgnbgewfregtrbfhng.I.wregtrbhfgfregtbfh(v));
        }
    }
}