using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.context.impl;

namespace Assets.Scripts
{
   public class MenuBootstrap : ContextView
    {
        void Awake()
        {
            this.context = new MenuContext(this);
        }
    }
}
