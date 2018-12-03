using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon {

    public GameObject arrowPrefab;
    public Transform firePoint;
    
    public override void Attack()
    {
        Instantiate(arrowPrefab, firePoint.position, transform.rotation);
    }

    public override void StopAttack()
    {

    }
}
