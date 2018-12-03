using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour {

    public GameObject droppedItem;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damaged()
    {
        Instantiate(droppedItem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
