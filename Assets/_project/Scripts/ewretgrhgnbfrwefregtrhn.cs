using System;
using UnityEngine;
using ZeroSDK.UIBuilder.AddOns.Button;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace _project.Scripts
{
    public sealed class ewretgrhgnbfrwefregtrhn : ewfrvve
    {
        [SerializeField] private ButtonView policyButton;
        [SerializeField] private ButtonView playButton;
        [SerializeField] private ButtonView optionsButton;
        [SerializeField] private ButtonView exitButton;
        
        public event Action eregtfhnghbgfewfregtfhn
        {
            add => playButton.OnClickEvent += value;
            remove => playButton.OnClickEvent += value;
        }
        
        public event Action eregtfhnghbgrfewfregtg
        {
            add => optionsButton.OnClickEvent += value;
            remove => optionsButton.OnClickEvent += value;
        }
        
        public event Action eretghfngewrgetfnh
        {
            add => exitButton.OnClickEvent += value;
            remove => exitButton.OnClickEvent += value;
        }
        
        public event Action erwegtgfhbgfefrgetrnfh
        {
            add => policyButton.OnClickEvent += value;
            remove => policyButton.OnClickEvent += value;
        }
        
    }
}