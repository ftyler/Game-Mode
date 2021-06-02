using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(fileName = "Resource", menuName = "ScriptableObjects/Resource")]
    public class Resource : ScriptableObject
    {
        // description, power, bean value, game object
        public string description;
        public Powers.jellyPowers power;
        public int beanValue;
        public GameObject gameObject;
        public Vector3 offset = new Vector3(-0.425f, -0.425f, 0.425f);
    }
}
