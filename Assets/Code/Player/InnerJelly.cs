using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abilities;

namespace Player
{
    public class InnerJelly : MonoBehaviour
    {
        // Constants
        private const float MAX_POS = 0.1f;
        private const float MOVE_DELTA = 0.01f;
        private const float BOUNCE_BACK_SPEED_MOD = 2;

        // Parent Jelly vars
        Transform parent;
        Vector3 parentPosition;
        Vector3 parentVelocity;

        // Inner Jelly vars
        float speed = 5;
        Vector3 position;
        GameObject heldResource;

        private void Start()
        {
            // The first Transform returned belongs to this object, so
            // we want to get the 2nd for the parent's transform
            parent = GetComponentsInParent<Transform>()[1];

            // Set starting position and velocity
            parentPosition = parent.localPosition;
            parentVelocity = new Vector3(0, 0, 0);
        }

        void FixedUpdate()
        {
            // Get current position
            position = transform.localPosition;

            // Check for parent's movement
            parentVelocity = parent.localPosition - parentPosition;
            parentPosition = parent.localPosition;

            // Get new position based on parent's motion
            if (Mathf.Abs(parentVelocity.x) <= MOVE_DELTA)
                position.x -= Time.deltaTime * position.x * speed * BOUNCE_BACK_SPEED_MOD;
            else
                position.x -= parentVelocity.x * Time.deltaTime * speed;
            if (Mathf.Abs(parentVelocity.z) <= MOVE_DELTA)
                position.z -= Time.deltaTime * position.z * speed * BOUNCE_BACK_SPEED_MOD;
            else
                position.z -= parentVelocity.z * Time.deltaTime * speed;

            // Fix new position in constrained area
            if (Mathf.Abs(position.x) > MAX_POS)
                position.x = Mathf.Sign(position.x) * MAX_POS;
            if (Mathf.Abs(position.z) > MAX_POS)
                position.z = Mathf.Sign(position.z) * MAX_POS;

            // Apply movement
            transform.localPosition = position;
        }

        public void UpdateAppearance(Resource currResource)
        {
            // Destroy any instance of previously held resource
            if (heldResource != null)
                GameObject.Destroy(heldResource);

            // Show held resource or inner jelly
            if (currResource == null)
            {
                // Show inner jelly
                Renderer renderer = GetComponent<Renderer>();
                renderer.enabled = true;
            }
            else
            {
                // Hide inner jelly
                Renderer renderer = GetComponent<Renderer>();
                renderer.enabled = false;

                // Create new instance of the resource's object
                heldResource = GameObject.Instantiate(currResource.gameObject);
                heldResource.transform.parent = gameObject.transform;
                // Modify scripts for new purpose
                GameObject.Destroy(heldResource.GetComponent<AbsorbableObject>());
                // Set starting position
                heldResource.transform.localPosition = currResource.offset;
            }
        }
    }
}