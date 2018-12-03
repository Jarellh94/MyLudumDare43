using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour {

    MeleeEnemyMovement movement;

	// Use this for initialization
	void Start () {
        movement = GetComponentInParent<MeleeEnemyMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            movement.SawPlayer(col.transform);
        }
    }
}
