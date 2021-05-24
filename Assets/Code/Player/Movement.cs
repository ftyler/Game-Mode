using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        public float speed = 3;
        Vector3 position;

        void FixedUpdate()
        {
            // Get current position
            position = transform.localPosition;

            // Get new position based on input
            position.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            position.z += Input.GetAxis("Vertical") * Time.deltaTime * speed;

            // Apply movement
            transform.localPosition = position;
        }
    }
}