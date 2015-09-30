using System.Linq;
using Assets.Controller;
using Assets.Scripts.Manager;
using Assets.View;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameContext : SignalContext
    {

        /**
         * Constructor
         */
        public GameContext(MonoBehaviour contextView) : base(contextView)
        {
           
        }

        protected override void mapBindings()
        {
            base.mapBindings();

            commandBinder.Bind<StartSignal>().To<StartCommand>().Once();

            //injectionBinder.Bind<ILoadBricksService>().To<LoadBricksService>();

            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            injectionBinder.Bind<IGameManager>().ToValue(gameManager).ToSingleton().CrossContext();
        }

    }
}
