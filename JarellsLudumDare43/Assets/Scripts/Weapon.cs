using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public int damage = 1;
    public float hitDelay = 1f;
    public float knockBackStrength = 5f;

    public BoxCollider2D hitBox;

    protected Animator anim;
    protected bool animated;

	// Use this for initialization
	void Start () {
        hitBox = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        if (anim != null)
            animated = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Attack()
    {
        hitBox.enabled = true;
        if(animated)
        {
            anim.SetTrigger("Attack");
        }
    }

    public virtual void StopAttack()
    {
        hitBox.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyHealth>().Damage(damage);

            MeleeEnemyMovement melee = col.GetComponent<MeleeEnemyMovement>();
            RangedEnemyMovement ranged = col.GetComponent<RangedEnemyMovement>();

            if (melee)
            {
                if (transform.parent.transform.rotation.eulerAngles.z == 0)
                {
                    melee.KnockBack(Vector3.up * knockBackStrength);
                }
                else if (transform.parent.transform.rotation.eulerAngles.z == 180)
                {
                    melee.KnockBack(Vector3.down * knockBackStrength);
                }
                else if (transform.parent.transform.rotation.eulerAngles.z == 90)
                {
                    melee.KnockBack(Vector3.left * knockBackStrength);
                }
                else if (transform.parent.transform.rotation.eulerAngles.z == 270)
                {
                    melee.KnockBack(Vector3.right * knockBackStrength);
                }
            }
            else if(ranged)
            {
                if (transform.parent.transform.rotation.eulerAngles.z == 0)
                {
                    ranged.KnockBack(Vector3.up * knockBackStrength);
                }
                else if (transform.parent.transform.rotation.eulerAngles.z == 180)
                {
                    ranged.KnockBack(Vector3.down * knockBackStrength);
                }
                else if (transform.parent.transform.rotation.eulerAngles.z == 90)
                {
                    ranged.KnockBack(Vector3.left * knockBackStrength);
                }
                else if (transform.parent.transform.rotation.eulerAngles.z == 270)
                {
                    ranged.KnockBack(Vector3.right * knockBackStrength);
                }
            }
            
        }
        else if(col.CompareTag("HealthDrop"))
        {
            col.GetComponent<HealthDrop>().Damaged();
        }
    }
}
