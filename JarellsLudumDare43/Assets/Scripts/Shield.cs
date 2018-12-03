using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Weapon {

    BoxCollider2D regCollider;

	// Use this for initialization
	void Start () {
        regCollider = gameObject.GetComponentsInChildren<BoxCollider2D>()[1];
        hitBox = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        if (anim != null)
            animated = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Attack()
    {
        regCollider.enabled = false;
        hitBox.enabled = true;
        if (animated)
        {
            anim.SetTrigger("Attack");
        }
    }

    public override void StopAttack()
    {
        regCollider.enabled = true;
        hitBox.enabled = false;
    }
}
