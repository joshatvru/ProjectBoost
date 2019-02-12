using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

    Rigidbody rigidBody;
    AudioSource rocketSound;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
     
        Thrust();
        Rotate();
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; //take manual control

        float rotationThisFrame = rcsThrust * Time.deltaTime;
        //Left on 'a' key
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame); 

        }
        //Left on 'd' key
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; //resume physics control
    }

    private void Thrust()
    {
        //Thrust on space key
        

        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            if (!rocketSound.isPlaying)
            {
                rocketSound.Play(); //check sound and play if not playing
            }

        }
        else
        {
            rocketSound.Stop(); //stop rocket sound playing
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Friendly"):
               
                break;
            case ("Fuel"):
                break;
            default:
              
                    break;


        }

        
          
    }
}
