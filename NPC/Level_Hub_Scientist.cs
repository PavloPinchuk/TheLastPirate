using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Hub_Scientist : MonoBehaviour
{
    public GameManager gm;
    //public ScriptDialogueLevel1 script;
    public PlayerController player;
    public Canvas canvasMain;
    public Canvas canvasDialog1;

    //public Rigidbody2D rb;

    private void Start()
    {
        ScriptDialogueHub1.OnDialogEnd += HandleDialog1End;
    }

    private void OnDisable()
    {
        ScriptDialogueHub1.OnDialogEnd -= HandleDialog1End;
    }

    private void HandleDialog1End(ScriptDialogueHub1 obj)
    {
        canvasDialog1.gameObject.SetActive(false);
        //player.ContinueMove();
        canvasMain.gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                if (gm.EnemyCount <= 0)
                {
                    //GameObject.FindGameObjectWithTag("CanvasDialogueLevel1").SetActive(true);
                    //GameObject.FindGameObjectWithTag("CanvasMain").SetActive(false);
                    canvasMain.gameObject.SetActive(false);
                    player.StopMove();
                    canvasDialog1.gameObject.SetActive(true);
                }
                //else
                //{
                // canves like "Not all enemies defeated" messege
                //}
                break;
        }

    }
}
