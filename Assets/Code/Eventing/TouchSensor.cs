using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Eventing
{
    public class TouchSensor : MonoBehaviour
    {
        NPC parent;

        private void Start()
        {
            parent = GetComponentInParent<NPC>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Movement player = other.GetComponent<Movement>();
            if (player != null)
                parent.AuraOn();
        }

        private void OnTriggerExit(Collider other)
        {
            Movement player = other.GetComponent<Movement>();
            if (player != null)
                parent.AuraOff();
        }
    }
}
