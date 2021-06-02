using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class Transparency : MonoBehaviour
    {
        // Constants
        private const float LR_HIDE_DISTANCE = 3f;
        private const float FB_HIDE_DISTANCE = 6f;
        private const float TRANSPARENCY_LEVEL = 0.25f;

        Camera cam;
        public Vector2 cameraDistance;
        public Renderer[] renderers;
        public float width;

        private void Start()
        {
            // Get reference to main camera
            cam = Camera.main;
            cameraDistance = new Vector2();
            renderers = GetComponentsInChildren<Renderer>();
        }

        void Update()
        {
            // Get current distance from camera
            cameraDistance.x = transform.position.x - cam.transform.position.x;
            cameraDistance.x = Mathf.Abs(cameraDistance.x) + (width/2 * Mathf.Sign(cameraDistance.x));
            cameraDistance.y = Mathf.Abs(transform.position.z - cam.transform.position.z);

            // Set transparency of each game object depending on distance
            if (cameraDistance.x <= LR_HIDE_DISTANCE && cameraDistance.y <= FB_HIDE_DISTANCE)
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