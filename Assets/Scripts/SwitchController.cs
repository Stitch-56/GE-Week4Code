using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour
{
    // switchAnimator will hold the gameobjects Animator
    private Animator switchAnimator;

    // The Awake function of each class is called before the Start function. It is
    // here you should initialise class properties/variables like those above.
    void Awake()
    {
        // Get the Animator off the game object this script is attached to as
        // we'll need it later
        switchAnimator = gameObject.GetComponent<Animator>();

        // Let's turn off the switch to start with
        turnOff();
    }

    // The Level Manager can call this if it want to turn On the switch
    public void turnOn()
    {
        switchAnimator.SetBool("SwitchOff", false);
    }

    // The Level Manager can call this if it want to turn Off the switch
    public void turnOff()
    {
        switchAnimator.SetBool("SwitchOff", true);
    }

    // Unity will call this when a gameobject enters this collider
    public void OnTriggerEnter2D(Collider2D other)
    {

        // Unity has passed us a Collider2D object called 'other' which contains information
        // about the other collider involved in the collision. Let's notify the LevelManager
        // that the Switches trigger has been entered by calling the onSwitchTriggerEnter function
        // on the LevelManager and let's also pass that function the 'other' Collider2D object.
        LevelManager.instance.onSwitchTriggerEnter(other);
    }

    // Unity will call this when a gameobject exits this collider
    public void OnTriggerExit2D(Collider2D other)
    {
        LevelManager.instance.onSwitchTriggerExit(other);
    }
}