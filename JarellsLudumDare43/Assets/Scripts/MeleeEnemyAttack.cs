using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttack : MonoBehaviour {
    
    MeleeEnemyMovement movement;
    bool attacking = false;
    float attackTimer = 0f;
    public float attackDelay = 1f;

    MeleeEnemyAttackBox attackBox;
    // Use this for initialization
    void Start ()
    {
        movement = GetComponentInParent<MeleeEnemyMovement>();
        attackBox = GetComponentInChildren<MeleeEnemyAttackBox>();
    }
	
	// Update is called once per frame
	void Update () {
        
		if(attackTimer == attackDelay && attacking)
        {
            attackBox.Hit();
        }

        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                attackTimer = 0;
                attacking = false;
                attackBox.StopHit();
            }
        }


	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (!attacking)
            {
                movement.ReadyToAttack();
                attacking = true;
                attackTimer = attackDelay;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            movement.NotReadyToAttack();
            attacking = false;
        }
    }
}
