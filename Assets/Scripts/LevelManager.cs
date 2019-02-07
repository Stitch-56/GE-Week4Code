using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    // Variable to hold the LevelManager instance
    public static LevelManager instance;

    public CoinController theCoin;

    // The SwitchController
    public SwitchController theSwitch;

    // The VaseController
    public GameObject theVase;

    [Header("Configurable properties")]
    [Tooltip("The force applied to the vase")]
    public Vector2 vasePushForce;

    // Variables to store the state of various game objects in the scene
    [Header("Useful debug info")]
    public bool switchEnabled = false;
    public bool switchOn = false;
    public bool vaseOnLedge = true;


    // We need a reference to various script components attached to various 
    // game objects so that we can call functions on them.
    public DoorController theDoor;

	// Variables to track the state of various game objects in the
	// level. NOTE: I would generally make these private but I am
	// making them public so that we can see them change in the inspector.
	public bool doorOpen = false;

    private void Awake()
    {
        instance = this;
    }

    public void flipTheSwitch()
    {
        if (switchEnabled == true)
        {

            if (switchOn == false)
            {
                theSwitch.turnOn();
                switchOn = true;
            }
            else
            {
                theSwitch.turnOff();
                switchOn = false;
            }

        }
    }

    public void onSwitchTriggerEnter(Collider2D other)
    {

        // Just to demonstrate how we can use the LevelManager to "control" what happens in the Level, I
        // am only allowing the switch to be enabled by the Hero (by walking into the trigger box of the
        // Switch) once 5 seconds have elapsed since the start of the game. The Time.fixedTime property 
        // contains the number of seconds have elapsed since the start of the game. 
        //
        // In a "real game" this if statement might be something like "if the Hero has collected the
        // potion" then enable the switch.
        if (Time.fixedTime > 5.0f)
        {
            switchEnabled = true;
        }
    }

    public void onSwitchTriggerExit(Collider2D other)
    {
        switchEnabled = false;
    }

    // This function gets called by the DoorController
    public void OnDoorTriggerEnter(Collider2D other) {
		// Let's Log out a message just so that we can see if this function is
		// being called
		Debug.Log ("LevelManager:OnDoorTriggerEnter");

        if (theCoin.Coin == true)
        {
            theDoor.open();
        }
		
			
	}

    // This function gets called by the DoorController
    public void OnDoorTriggerExit(Collider2D other) {
		// Let's Log out a message just so that we can see if this function is
		// being called
		Debug.Log ("LevelManager:OnDoorTriggerExit");

		theDoor.close ();
	}
}
