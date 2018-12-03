using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour {
    
    public float shootTimer;
    public float shootDelay;

    public GameObject arrowPrefab;
    public Transform firePoint;

    bool attacking;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (shootTimer == shootDelay && attacking)
        {
            Shoot();
        }

        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;

            if (shootTimer <= 0)
            {
                shootTimer = shootDelay;
            }
        }
    }

    public void Shoot()
    {
        GameObject arr = Instantiate(arrowPrefab, firePoint.position, transform.rotation);

        arr.GetComponent<Arrow>().playerArrow = false;
    }

    public void Attacking()
    {
        attacking = true;
        shootTimer = shootDelay - 0.5f;
    }
}
