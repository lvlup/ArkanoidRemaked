using strange.extensions.signal.impl;
using UnityEngine;

namespace Assets.View
{
   public class DeadZoneView : strange.extensions.mediation.impl.View
    {
        public Signal<Collider> LoseLifeSignal = new Signal<Collider>();

        void OnTriggerEnter(Collider col)
        {
            LoseLifeSignal.Dispatch(col);
        }
    }
}
