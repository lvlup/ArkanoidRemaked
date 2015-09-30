using strange.extensions.signal.impl;
using UnityEngine;

namespace Assets.View
{
  public  class PaddleView : strange.extensions.mediation.impl.View
    {
        public float paddleSpeed = 1f;
        public Signal<Transform, float> paddleUpdated = new Signal<Transform,float>();

        public void Update()
        {
            paddleUpdated.Dispatch(transform,paddleSpeed);
        }

    }
   
}
