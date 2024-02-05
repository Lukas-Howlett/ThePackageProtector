using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroyer : MonoBehaviour
{
   private int counter = 2;
   GameObject crash;
   AudioSource crashSound;

    void Start()
    {
        crash = GameObject.Find("/Sounds/CarCrash");
        crashSound = crash.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(counter == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    { 
        if(other.name == "Player")
        {
            Debug.Log("Player collision, Destroying Vehicle");
            crashSound.Play();
            counter = 0;

        }else if(other.name == "Dog") //Must make sure all dogs in scene are named "Dog"
        {
            Debug.Log("Dog collision, Destroying Dog");
            Destroy(other.gameObject);
        }
    }

    //In order for cars to despawn, must make sure that car enters through and exits through a wall in map
    private void OnTriggerExit(Collider other)
    {  
        if(other.name == "Wall") //Must make sure all boundary walls are named "Wall"
        {
            counter -= 1;
            Debug.Log(counter);
        }
    }

}
