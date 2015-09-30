using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Controller;
using Assets.Scripts.Manager;
using Assets.View;
using strange.extensions.context.impl;
using UnityEngine;

namespace Assets.Scripts
{
  public  class MenuContext : SignalContext
    {
      public MenuContext(MonoBehaviour contextView) : base(contextView)
      {
      }

        protected override void mapBindings()
        {
            base.mapBindings();

            commandBinder.Bind<StartSignal>().To<StartCommand>().Once();

            injectionBinder.Bind<ILoadBricksService>().To<LoadBricksService>();

            mediationBinder.Bind<PaddleView>().To<PaddleMediator>();
            mediationBinder.Bind<BallView>().To<BallMediator>();
            mediationBinder.Bind<BrickView>().To<BrickMediator>();
            mediationBinder.Bind<DeadZoneView>().To<DeadZoneMediator>();

            MenuManager menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
            injectionBinder.Bind<IMenuManager>().ToValue(menuManager).ToSingleton().CrossContext();
        }
    }
}
