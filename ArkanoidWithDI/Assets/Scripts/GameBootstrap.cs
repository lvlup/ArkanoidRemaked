using strange.extensions.context.impl;

namespace Assets.Scripts
{
   public class GameBootstrap : ContextView
    {
        void Awake()
        {
            this.context = new GameContext(this);
        }
    }
}
