using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statue : MonoBehaviour {

    public GameObject toolTip;
    public GameObject instructions;
    Text dialogBox;

    public List<string> enemiesDefeatedDialog;
    public List<string> enemiesNotDefeatedDialog;

    public GameManager manager;

    bool playerInRange = false;
    bool talking = false;
    bool enemiesDefeated = false;
    int dialogIndex = 0;

    PlayerAttack player;

    public SpriteRenderer weaponSprite;

    public DungeonDoor myDoor;

    bool playerFinished = false;

    // Use this for initialization
    void Start () {
        dialogBox = instructions.GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		if(playerInRange && !playerFinished)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (!talking)
                {
                    BeginDialog();
                }
                else
                {
                    dialogIndex++;
                }
            }
        }
        if (talking)
        {
            if (enemiesDefeated)
            {
                if (dialogIndex < enemiesDefeatedDialog.Count)
                    dialogBox.text = enemiesDefeatedDialog[dialogIndex];
                else
                {
                    PlayerCompletedRoom();
                }
            }
            else
            {
                if(dialogIndex < enemiesNotDefeatedDialog.Count)
                    dialogBox.text = enemiesNotDefeatedDialog[dialogIndex];
                else
                {
                    EndDialog();
                }
            }
        }
	}

    public void PlayerCompletedRoom()
    {
        int ranNum;

        if (player.weapons.Count == 1)
            ranNum = 0;
        else
            ranNum = Random.Range(0, 2);

        weaponSprite.sprite = player.RemoveWeapon(ranNum);
        weaponSprite.gameObject.SetActive(true);

        EndDialog();
        playerFinished = true;

        myDoor.OpenDoor();

        manager.LoadNextRoom();
    }

    public void BeginDialog()
    {
        instructions.SetActive(true);
        toolTip.SetActive(false);
        talking = true;

        if (manager.EnemiesDefeated())
        {
            enemiesDefeated = true;
        }
        else
        {
            enemiesDefeated = false;
        }
    }

    public void EndDialog()
    {
        instructions.SetActive(false);
        toolTip.SetActive(true);
        talking = false;
        dialogIndex = 0;
    }

    void OnTriggerEnter2D(Collider2D oth)
    {
        if(oth.CompareTag("Player"))
        {
            player = oth.GetComponent<PlayerAttack>();

            playerInRange = true;
            toolTip.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D oth)
    {
        if (oth.CompareTag("Player"))
        {
            playerInRange = false;
            toolTip.SetActive(false);
            dialogIndex = 0;
        }
    }
}
