
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.View
{
  public  class BallMediator : Mediator
    {
        [Inject]
        public BallView view { get; set; }

        private bool ballInPlay;

        public override void OnRegister()
        {
            view.ballUpdatedSignal.AddListener(StartBall);
        }

      private void StartBall(Transform transf, Rigidbody rb,float ballInitialVelocity)
      {
          if (Input.GetButtonDown("Fire1") && ballInPlay == false)
          {
              transform.parent = null;
              ballInPlay = true;
              rb.isKinematic = false;
              rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
          }
      }
    }
}
