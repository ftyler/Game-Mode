using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abilities;

namespace Player
{
    public class Stats : MonoBehaviour
    {
        public int beans;
        public Powers.jellyPowers currPower;
        public Resource currResource;

        private InnerJelly innerJelly;

        private void Start()
        {
            // Get a reference to the inner jelly attached to the player
            innerJelly = GetComponentInChildren<InnerJelly>();
        }

        public void Pickup(Resource resource)
        {
            // Update held resource and related power
            currResource = resource;
            currPower = resource.power;

            // Call update of rendered appearance based on these changes
            innerJelly.UpdateAppearance(currResource);
            // TODO: Update appearance of overall jelly based on power
        }
    }
}
