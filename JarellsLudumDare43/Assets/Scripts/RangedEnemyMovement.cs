using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyMovement : MonoBehaviour {

    public Transform player;
    
    bool trackingPlayer = false;
    bool isAttacking = false;

    RangedEnemyAttack attack;

    Rigidbody2D myRig;
    public float maxKnockBackTime = .75f;
    float knockBackTimer = 0;

    // Use this for initialization
    void Start () {
        attack = GetComponentInParent<RangedEnemyAttack>();
        myRig = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if(trackingPlayer && knockBackTimer == 0)
        {
            Vector3 diff = player.transform.position - transform.position;

            diff.Normalize();

            float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);

            if (knockBackTimer > 0)
            {
                knockBackTimer -= Time.deltaTime;
                if (knockBackTimer < 0)
                    knockBackTimer = 0;
            }
        }
	}

    public void SawPlayer(Transform thePlayer)
    {
        player = thePlayer;
        trackingPlayer = true;

        attack.Attacking();
    }

    public void KnockBack(Vector3 knockBackAmount)
    {
        myRig.velocity = knockBackAmount;

        knockBackTimer = maxKnockBackTime;
    }
}
