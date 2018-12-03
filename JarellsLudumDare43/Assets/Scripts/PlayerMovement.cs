using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5f;
    public float maxKnockBackTime = .75f;
    float knockBackTimer = 0;

    PlayerAttack attack;
    Rigidbody2D myRig;

	// Use this for initialization
	void Start () {
        attack = gameObject.GetComponent<PlayerAttack>();
        myRig = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(knockBackTimer > 0)
        {
            knockBackTimer -= Time.deltaTime;
            if (knockBackTimer < 0)
                knockBackTimer = 0;
        }
    }
    void FixedUpdate()
    {
        if (knockBackTimer == 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                MoveLeft();
            }
            if (Input.GetKey(KeyCode.D))
            {
                MoveRight();
            }
            if (Input.GetKey(KeyCode.S))
            {
                MoveDown();
            }
            if (Input.GetKey(KeyCode.W))
            {
                MoveUp();
            }
        }
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void MoveDown()
    {
        transform.Translate(Vector3.up * -1 * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Euler(0, 0, -180);
    }
    void MoveLeft()
    {
        transform.Translate(Vector3.right * -1 * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }
    void MoveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }

    public void KnockBack(Vector3 knockBackAmount)
    {
        myRig.velocity = knockBackAmount;

        knockBackTimer = maxKnockBackTime;
    }
}
