using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    // Variable to hold the LevelManager instance
    public static LevelManager instance;

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

    // This function gets called by the DoorController
    public void OnDoorTriggerEnter(Collider2D other) {
		// Let's Log out a message just so that we can see if this function is
		// being called
		Debug.Log ("LevelManager:OnDoorTriggerEnter");


		theDoor.open ();
			
	}

    // This function gets called by the DoorController
    public void OnDoorTriggerExit(Collider2D other) {
		// Let's Log out a message just so that we can see if this function is
		// being called
		Debug.Log ("LevelManager:OnDoorTriggerExit");

		theDoor.close ();
	}
}
