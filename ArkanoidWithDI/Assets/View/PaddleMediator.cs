using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.View
{
   public class PaddleMediator : Mediator
    {
        [Inject]
        public PaddleView view { get; set; }

        public override void OnRegister()
        {
            view.paddleUpdated.AddListener(MovePaddle);
        }

       private void MovePaddle(Transform transf, float paddleSpeed)
       {
            float xPos = transf.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
            var playerPos = new Vector3(Mathf.Clamp(xPos, -5f, 5f), transf.position.y, 0f);
            transf.position = playerPos;
        }
    }
}
