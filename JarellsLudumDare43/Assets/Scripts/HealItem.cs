using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D oth)
    {
        if(oth.CompareTag("Player"))
        {
            oth.GetComponent<PlayerHealth>().Heal(1);
            Destroy(gameObject);
        }
    }
}
