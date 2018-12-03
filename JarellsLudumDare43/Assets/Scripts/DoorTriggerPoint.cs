using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerPoint : MonoBehaviour {

    public DungeonDoor myDoor;

	// Use this for initialization
	void Start () {
        myDoor = gameObject.GetComponentInParent<DungeonDoor>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            myDoor.PlayerThroughDoor();
        }
    }
}
