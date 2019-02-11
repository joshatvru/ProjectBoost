using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessUpdate();
    }

    private void ProcessUpdate()
    {
        //Thrust on space key
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);

        }
        //Left on 'a' key
        if (Input.GetKey(KeyCode.A))
        {

        }
        //Left on 'd' key
        else if (Input.GetKey(KeyCode.D))
        {

        }
    }
}
