using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownBomb : MonoBehaviour {

    public float speed = 10f;
    public float knockBackStrength = 2f;
    public float expTime = 2f;
    public float throwDistance = 10f;
    public bool exploding = false;

    CircleCollider2D explosion;

    bool stopped;
    protected Animator anim;

    // Use this for initialization
    void Start () {
        explosion = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if(!stopped && throwDistance > 0)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            throwDistance -= speed * Time.deltaTime;
        }

        if (expTime <= 0)
            Explode();
        else
            expTime -= Time.deltaTime;
	}

    public void Explode()
    {
        exploding = true;
        anim.SetTrigger("Explode");
    }

    public void DestroyExplosion()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D oth)
    {
        if (oth.CompareTag("HealthDrop"))
        {
            oth.GetComponent<HealthDrop>().Damaged();
        }

        if (oth.CompareTag("Enemy"))
        {
            oth.GetComponent<EnemyHealth>().Damage(1);
        }

        else if (oth.CompareTag("Player"))
        {
            oth.GetComponent<PlayerHealth>().Damage(1);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        stopped = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
}
