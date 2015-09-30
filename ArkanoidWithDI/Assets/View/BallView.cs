using strange.extensions.signal.impl;
using UnityEngine;

namespace Assets.View
{
   public class BallView : strange.extensions.mediation.impl.View
    {
        public float ballInitialVelocity = 900f;
        public Signal<Transform, Rigidbody,float> ballUpdatedSignal = new Signal<Transform, Rigidbody,float>();


        private Rigidbody rb;
        private bool ballInPlay;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            ballUpdatedSignal.Dispatch(transform,rb,ballInitialVelocity);
        }
    }
}
