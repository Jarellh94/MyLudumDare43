using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Weapon {

    public GameObject bombPrefab;
    public Transform firePoint;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Attack()
    {
        Instantiate(bombPrefab, firePoint.position, transform.rotation);
    }

    public override void StopAttack()
    {
    }
}
