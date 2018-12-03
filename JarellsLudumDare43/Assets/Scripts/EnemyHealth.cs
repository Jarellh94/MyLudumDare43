using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int health = 1;

    public float hitTimer = 0;
    public float invincibleTime = .5f;

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(hitTimer > 0)
        {
            hitTimer -= Time.deltaTime;
            if(hitTimer < 0)
            {
                hitTimer = 0;
            }
        }
	}

    public void Damage(int amount)
    {
        if (hitTimer == 0)
        {
            health -= amount;

            if (amount > 0)
                anim.SetTrigger("Hurt");

            if (health <= 0)
                Die();

            hitTimer = invincibleTime;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
