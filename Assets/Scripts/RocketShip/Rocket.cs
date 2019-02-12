using UnityEngine;
using UnityEngine.SceneManagement;


public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip explodeShip;
    [SerializeField] AudioClip finishLevel;
    [SerializeField] float levelLoadDelay = 2f;


    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem explodeShipParticles;
    [SerializeField] ParticleSystem finishLevelParticles;


    enum State {Alive, Dead, Transcending};
    State state = State.Alive;

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
        
        if (state == State.Alive)
        {
           

            RespondToThrustInput();
        RespondToRotateInput();
        }
    }

    private void RespondToRotateInput()
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

    private void RespondToThrustInput()
    {
        //Thrust on space key

        
            if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
            
           
        }
        else
        {
            rocketSound.Stop(); //stop rocket sound playing
            mainEngineParticles.Stop();

        }

    }

    



    private void ApplyThrust()
    {
        
        rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!rocketSound.isPlaying)
        {
            rocketSound.PlayOneShot(mainEngine); //check sound and play if not playing
        }
        mainEngineParticles.Play();

    }

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case ("Friendly"):
               
                break;
            case ("Finish"):
                StartSuccessSequence();
                break;
            default:
                StartDeathSequence();

                break;


        }

        
          
    }

    private void StartDeathSequence()
    {

        rocketSound.Stop();
        rocketSound.PlayOneShot(explodeShip);
        explodeShipParticles.Play();
        state = State.Dead;
    
        Invoke("LoadRestart", levelLoadDelay);
    }

    private void StartSuccessSequence()
    {
        rocketSound.Stop();
        rocketSound.PlayOneShot(finishLevel);
        finishLevelParticles.Play();
       
        state = State.Transcending;
        Invoke("LoadNextScene", levelLoadDelay); //Paramatise this time. 
    }

    private void LoadRestart()
    {
        state = State.Alive;
        SceneManager.LoadScene(0);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1); //Allow for more then 2 levels
    }
}
