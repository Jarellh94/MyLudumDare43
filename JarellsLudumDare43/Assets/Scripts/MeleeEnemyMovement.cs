using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyMovement : MonoBehaviour {

    public float speed = 3f;

    public Transform player;
    
    public bool armed = false;

    bool trackingPlayer = false;
    bool isAttacking = false;

    public float knockBackStrength = 2f;
    int knockBackDir = 0; //0 - Up, 1 - Down, 2 - Left, 3 - Right

    Rigidbody2D myRig;
    public float maxKnockBackTime = .75f;
    float knockBackTimer = 0;

    // Use this for initialization
    void Start () {
        myRig = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (knockBackTimer > 0)
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
            if (!armed)
            {
                if (trackingPlayer)
                {
                    if (transform.position.y < player.position.y - .2 || transform.position.y > player.position.y + .2)
                    {
                        if (player.position.y > transform.position.y)
                        {
                            MoveUp();
                        }
                        if (player.position.y < transform.position.y)
                        {
                            MoveDown();
                        }
                    }
                    if (transform.position.x < player.position.x - .2 || transform.position.x > player.position.x + .2)
                    {
                        if (player.position.x > transform.position.x)
                        {
                            MoveRight();
                        }
                        if (player.position.x < transform.position.x)
                        {
                            MoveLeft();
                        }
                    }
                }
            }

            else
            {
                if (trackingPlayer && !isAttacking)
                {
                    if (transform.position.y < player.position.y - .2 || transform.position.y > player.position.y + .2)
                    {
                        if (player.position.y > transform.position.y)
                        {
                            MoveUp();
                        }
                        if (player.position.y < transform.position.y)
                        {
                            MoveDown();
                        }
                    }
                    if (transform.position.x < player.position.x - .2 || transform.position.x > player.position.x + .2)
                    {
                        if (player.position.x > transform.position.x)
                        {
                            MoveRight();
                        }
                        if (player.position.x < transform.position.x)
                        {
                            MoveLeft();
                        }
                    }
                }
            }
        }
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        knockBackDir = 0;
    }
    void MoveDown()
    {
        transform.Translate(Vector3.up * -1 * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Euler(0, 0, -180);
        knockBackDir = 1;
    }
    void MoveLeft()
    {
        transform.Translate(Vector3.right * -1 * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Euler(0, 0, 90);
        knockBackDir = 2;
    }
    void MoveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Euler(0, 0, -90);
        knockBackDir = 3;
    }

    public void SawPlayer(Transform thePlayer)
    {
        player = thePlayer.transform;
        trackingPlayer = true;
    }

    public void ReadyToAttack()
    {
        isAttacking = true;
    }

    public void NotReadyToAttack()
    {
        isAttacking = false;
    }

    public void KnockBack(Vector3 knockBackAmount)
    {
        myRig.velocity = knockBackAmount;

        knockBackTimer = maxKnockBackTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            col.collider.GetComponent<PlayerHealth>().Damage(1);
            
            switch (knockBackDir)
            {
                case 0:
                    col.collider.GetComponent<PlayerMovement>().KnockBack(Vector3.up * knockBackStrength);
                    break;
                case 1:
                    col.collider.GetComponent<PlayerMovement>().KnockBack(Vector3.down * knockBackStrength);
                    break;
                case 2:
                    col.collider.GetComponent<PlayerMovement>().KnockBack(Vector3.left * knockBackStrength);
                    break;
                case 3:
                    col.collider.GetComponent<PlayerMovement>().KnockBack(Vector3.right * knockBackStrength);
                    break;
                default:
                    col.collider.GetComponent<PlayerMovement>().KnockBack(Vector3.up * knockBackStrength);
                    break;

            }
        }
    }
}
