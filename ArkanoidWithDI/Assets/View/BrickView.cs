using strange.extensions.signal.impl;
using UnityEngine;

namespace Assets.View
{
  public  class BrickView : strange.extensions.mediation.impl.View
    {
        public GameObject brickParticle;

        public Signal<GameObject,Transform> DestroyBrickSignal = new Signal<GameObject, Transform>(); 

        void OnCollisionEnter(Collision other)
        {
            DestroyBrickSignal.Dispatch(brickParticle,transform);
        }
    }
}
