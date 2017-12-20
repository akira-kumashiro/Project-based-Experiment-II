using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        collision.rigidbody.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        collision.transform.Rotate(new Vector3(0.0f, 0.0f, 0.0f));
        collision.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        collision.rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {

    }
}