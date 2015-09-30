using Assets.Scripts.Manager;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.View
{
   public class BrickMediator : Mediator
    {
        [Inject]
        public BrickView View { get; set; }

        [Inject]
        public IGameManager GameManager { get; set; }

        public override void OnRegister()
        {
            View.DestroyBrickSignal.AddListener(DestroyBrick);
        }

       private void DestroyBrick(GameObject brickParticle, Transform transform)
       {
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            GameManager.DestroyBrick();
            Destroy(gameObject);
        }
    }
}
