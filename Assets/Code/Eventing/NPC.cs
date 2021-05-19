using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eventing
{
    public class NPC : MonoBehaviour
    {
        ParticleSystem aura;

        private void Start()
        {
            aura = GetComponentInChildren<ParticleSystem>();
            aura.Stop();
            aura.Clear();
        }
        
        public void AuraOn()
        {
            aura.Play();
        }

        public void AuraOff()
        {
            aura.Stop();
            aura.Clear();
        }
    }
}