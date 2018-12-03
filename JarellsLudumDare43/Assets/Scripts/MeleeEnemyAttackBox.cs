using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttackBox : MonoBehaviour {

    BoxCollider2D hitArea;

	// Use this for initialization
	void Start () {
        hitArea = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit()
    {
        hitArea.enabled = true;
    }

    public void StopHit()
    {
        hitArea.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().Damage(1);
        }
    }
}
