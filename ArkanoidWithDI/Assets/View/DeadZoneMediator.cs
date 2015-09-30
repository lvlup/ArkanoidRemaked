using Assets.Scripts.Manager;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.View
{
   public class DeadZoneMediator : Mediator
    {
        [Inject]
        public DeadZoneView View { get; set; }

        [Inject]
        public  IGameManager GameManager { get; set; }

        public override void OnRegister()
        {
            View.LoseLifeSignal.AddListener(LoseLife);
        }

       private void LoseLife(Collider collider)
       {
            GameManager.LoseLife();
            //Destroy(collider.gameObject);
        }

    }
}
