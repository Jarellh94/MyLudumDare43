using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoor : MonoBehaviour {

    BoxCollider2D myCol;
    public GameObject openDoor;
    
    public GameObject triggerPoint;
    public GameManager manager;

	// Use this for initialization
	void Start () {
        myCol = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenDoor()
    {
        myCol.isTrigger = true;
        openDoor.SetActive(true);
    }

    public void CloseDoor()
    {
        myCol.isTrigger = false;
        openDoor.SetActive(false);

        if(triggerPoint)
            triggerPoint.SetActive(false);
    }

    public void PlayerThroughDoor()
    {
        manager.MovedToNextRoom();

        CloseDoor();
    }
}
