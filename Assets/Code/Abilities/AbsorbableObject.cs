using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Abilities
{
    public class AbsorbableObject : MonoBehaviour
    {
        public Resource resource;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Collision!");
            Stats player = other.GetComponent<Stats>();
            if (player != null)
            {
                player.Pickup(resource);
                GameObject.Destroy(gameObject);
            }    
        }
    }
}
