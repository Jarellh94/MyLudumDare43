using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float speed = 10f;
    public float knockBackStrength = 2f;

    public bool playerArrow = true;
    bool stopped = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        if(!stopped)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (playerArrow)
        {
            if (col.collider.CompareTag("HealthDrop"))
            {
                col.collider.GetComponent<HealthDrop>().Damaged();
                Destroy(gameObject);
            }

            if (col.collider.CompareTag("Enemy"))
            {
                col.collider.GetComponent<EnemyHealth>().Damage(1);
                Destroy(gameObject);
            }
        }
        else
        {
            if (col.collider.CompareTag("Player"))
            {
                col.collider.GetComponent<PlayerHealth>().Damage(1);
                Destroy(gameObject);
            }
        }

        stopped = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
