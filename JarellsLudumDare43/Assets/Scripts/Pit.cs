using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour {

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
            oth.GetComponent<PlayerHealth>().Die("Fall");
        }
        else if(oth.CompareTag("Enemy"))
        {
            oth.GetComponent<EnemyHealth>().Die();
        }
        else if(oth.CompareTag("Bomb"))
        {
            if (!oth.GetComponent<ThrownBomb>().exploding)
            {
                Destroy(oth.gameObject);
                Debug.Log("Distroyed It!");
            }
        }
    }
}
