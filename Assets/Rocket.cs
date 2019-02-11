using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
