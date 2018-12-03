using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> rooms;
    public List<GameObject> roomEnemies;

    public List<GameObject> weapons;
    public PlayerAttack player;

    public GameObject winScreen;

    int roomIndex = 0;

    // Use this for initialization
    void Start () {
		
	}

    void Awake()
    {
        int wep1 = Random.Range(0, weapons.Count);

        GameObject weapon1 = weapons[wep1];
        weapons.RemoveAt(wep1);

        int wep2 = Random.Range(0, weapons.Count);

        player.SetWeapons(weapon1, weapons[wep2]);

        weapons.RemoveAt(wep2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool EnemiesDefeated()
    {
        if (roomEnemies[roomIndex].transform.childCount == 0)
        {
            return true;
        }
        else
            return false;
    }

    public void LoadNextRoom()
    {
        rooms[roomIndex + 1].SetActive(true);
    }

    public void MovedToNextRoom()
    {
        rooms[roomIndex].SetActive(false);

        roomIndex++;

        if(roomIndex > rooms.Count)
        {
            winScreen.SetActive(true);
            winScreen.GetComponent<Animator>().SetTrigger("GameOver");
        }
        else
            SetNewWeapon();
    }

    public void SetNewWeapon()
    {
        if (weapons.Count == 1)
        {
            int wepInd = 0;

            player.NewWeapon(weapons[wepInd]);

            weapons.RemoveAt(wepInd);
        }
        else if (weapons.Count == 0)
        {
            return;
        }
        else
        {
            int wepInd = Random.Range(0, weapons.Count);

            player.NewWeapon(weapons[wepInd]);

            weapons.RemoveAt(wepInd);
        }
    }
}
