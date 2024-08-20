using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ZeroSDK.UIBuilder.AddOns.Button;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace _project.Scripts
{
    public sealed class rgtbefrgf : ewfrvve
    {
        [SerializeField] private ButtonView exitButton;
        [SerializeField] private List<ButtonView> levelButtons;
        [SerializeField] private List<TextMeshProUGUI> scores;

        public event Action rtgrhyynjhnbgvfergtrgb
        {
            add => exitButton.OnClickEvent += value;
            remove => exitButton.OnClickEvent += value;
        }

        public event Action<int> ergthngbgfregbfhg;

        protected override void rgrtbfrgtbf()
        {
            for (int i = 0; i < levelButtons.Count; i++)
            {
                var id = i;
                levelButtons[i].OnClickEvent += () => ergthngbgfregbfhg?.Invoke(id);
            }
        }

        public void gtryhgbfrefrgtgbfhn(int levelsCount)
        {
            for (int i = 0; i < Mathf.Min(levelsCount, levelButtons.Count); i++)
            {
                var fadeValue = i <= levelsCount - 1 ? 1 : 0.16f;
                levelButtons[i].CG.alpha = fadeValue;
                scores[i].text = $"Score: {PlayerPrefs.GetInt($"Score{i}"):0000}";
            }
        }
    }
}