using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class Transparency : MonoBehaviour
    {
        // Constants
        private const float HIDE_DISTANCE = 8f;
        private const float TRANSPARENCY_LEVEL = 0.25f;

        Camera cam;
        public float cameraDistance;
        public Renderer[] renderers;

        private void Start()
        {
            // Get reference to main camera
            cam = Camera.main;
            renderers = GetComponentsInChildren<Renderer>();
        }

        void Update()
        {
            // Get current distance from camera
            cameraDistance = (transform.position - cam.transform.position).magnitude;

            // Set transparency of each game object depending on distance
            if (cameraDistance <= HIDE_DISTANCE)
            {
                foreach (Renderer renderer in renderers)
                {
                    Color color = renderer.material.GetColor("_Color");
                    color.a = TRANSPARENCY_LEVEL;
                    renderer.material.SetColor("_Color", color);
                }
            }
            else
            {
                foreach (Renderer renderer in renderers)
                {
                    Color color = renderer.material.GetColor("_Color");
                    color.a = 1;
                    renderer.material.SetColor("_Color", color);
                }
            }
        }
    }
}