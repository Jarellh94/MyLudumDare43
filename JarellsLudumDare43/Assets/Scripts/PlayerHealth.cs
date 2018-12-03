using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 3;
    public int currentHealth;
    public List<GameObject> hearts;
    public List<GameObject> lostHearts;
    public GameObject gameOverPanel;

    Animator anim;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;

        if(amount > 0)
            anim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die("Health");
        }

        hearts[currentHealth].SetActive(false);
        lostHearts[currentHealth].SetActive(true);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth >= 3)
        {
            currentHealth = 3;
        }

        hearts[currentHealth-1].SetActive(true);
        lostHearts[currentHealth-1].SetActive(false);
    }

    public void Die(string how)
    {
        if(how == "Fall")
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        gameOverPanel.SetActive(true);
        gameOverPanel.GetComponent<Animator>().SetTrigger("GameOver");
    }
}
