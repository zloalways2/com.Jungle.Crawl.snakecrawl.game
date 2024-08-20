﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZeroSDK.UIBuilder.AddOns;


namespace ZeroSDK.UIBuilder.Core.UIElements
{
    public class ewfrvve : View
    {
        [SerializeField] public bool Ignore = false;
        [SerializeField] public bool ShowOnInit = false;

        [SerializeField] protected List<DisplayableStack> stacks = new List<DisplayableStack>();


        protected virtual void TestShow()
        {
        }

        protected override void rgrtbfrgtbf()
        {
            base.rgrtbfrgtbf();
            OnShowStartEvent += () =>
            {
                foreach (var stack in stacks.Where(s => s != null))
                {
                    stack.ShowStack();
                }
            };
        }
    }
}