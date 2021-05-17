using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody rigidBody;
    public float speed = 1;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        position = transform.position;  // get curr position
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.localPosition;
        position.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        position.z += Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.localPosition = position;
    }
}
