using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {
    
    float hitTimer = 0;
    float maxHitTime;

    public List<Weapon> weapons;
    public GameObject weapon1Graphic;
    public GameObject weapon2Graphic;
    public GameObject weapon1Mask;
    public GameObject weapon2Mask;

    Weapon currentWeapon;
    int currWeaponIndex = 0;

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SwitchWeapons();
        }

        if (hitTimer > 0)
        {
            hitTimer -= Time.deltaTime;

            if (hitTimer < 0)
            {
                hitTimer = 0;
                currentWeapon.StopAttack();
            }
        }
	}

    public void Attack()
    {
        if (hitTimer == 0)
        {
            hitTimer = currentWeapon.hitDelay;
            currentWeapon.Attack();
        }
    }

    public void SwitchWeapons()
    {
        if (weapons.Count == 1)
            return;

        currentWeapon.gameObject.SetActive(false);

        if(currWeaponIndex == 0)
        {
            currentWeapon = weapons[1];
            currWeaponIndex = 1;

            weapon1Mask.SetActive(true);
            weapon2Mask.SetActive(false);
        }
        else
        {
            currentWeapon = weapons[0];
            currWeaponIndex = 0;
            
            weapon1Mask.SetActive(false);
            weapon2Mask.SetActive(true);
        }

        currentWeapon.gameObject.SetActive(true);
    }

    public Sprite RemoveWeapon(int num)
    {
        Sprite weaponSprite = weapons[num].GetComponent<SpriteRenderer>().sprite;

        if (num == 0)
        {
            currentWeapon = weapons[1];
            currentWeapon.gameObject.SetActive(true);
            currWeaponIndex = 0;
            weapon1Mask.SetActive(false);
            weapon2Mask.SetActive(true);

            Destroy(weapons[0].gameObject);

            weapons[0] = currentWeapon;
            
            weapons.RemoveAt(1);

            weapon1Graphic.GetComponent<Image>().sprite = weapons[0].gameObject.GetComponent<SpriteRenderer>().sprite;
            weapon2Graphic.GetComponent<Image>().sprite = null;

            return weaponSprite;
        }
        else
        {
            currentWeapon = weapons[0];
            currentWeapon.gameObject.SetActive(true);
            currWeaponIndex = 0;

            weapon1Mask.SetActive(false);
            weapon2Mask.SetActive(true);

            Destroy(weapons[1].gameObject);
            weapons.RemoveAt(1);

            weapon1Graphic.GetComponent<Image>().sprite = weapons[0].gameObject.GetComponent<SpriteRenderer>().sprite;
            weapon2Graphic.GetComponent<Image>().sprite = null;

            return weaponSprite;
        }
    }

    public void SetWeapons(GameObject weapon1, GameObject weapon2)
    {
        weapons.Add(weapon1.GetComponent<Weapon>());
        weapons.Add(weapon2.GetComponent<Weapon>());

        currentWeapon = weapons[0];

        weapon1Graphic.GetComponent<Image>().sprite = weapons[0].gameObject.GetComponent<SpriteRenderer>().sprite;
        weapon2Graphic.GetComponent<Image>().sprite = weapons[1].gameObject.GetComponent<SpriteRenderer>().sprite;

        weapon1Graphic.SetActive(true);
        weapon1Mask.SetActive(false);

        weapon2Graphic.SetActive(true);
        weapon2Mask.SetActive(true);
        
        currentWeapon.gameObject.SetActive(true);
    }

    public void NewWeapon(GameObject weapon)
    {
        weapons.Add(weapon.GetComponent<Weapon>());

        weapon2Graphic.GetComponent<Image>().sprite = weapons[1].gameObject.GetComponent<SpriteRenderer>().sprite;

        weapon2Graphic.SetActive(true);
        weapon2Mask.SetActive(true);
    }
}
