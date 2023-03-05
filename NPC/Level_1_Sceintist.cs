using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_Sceintist : MonoBehaviour
{
    public GameManager gm;
    //public ScriptDialogueLevel1 script;
    public PlayerController player;
    public Canvas canvasMain;
    public Canvas canvasDialog1;
    public Canvas canvasDialog2;

    //public Rigidbody2D rb;

    private void Start()
    {

        ScriptDialogueLevel1.OnDialogEnd += HandleDialog1End;
        ScriptDialogueLevel1_2.OnDialogEnd += HandleDialog2End;
    }

    private void OnDisable()
    {
        ScriptDialogueLevel1.OnDialogEnd -= HandleDialog1End;
        ScriptDialogueLevel1_2.OnDialogEnd -= HandleDialog2End;
    }

    private void HandleDialog1End(ScriptDialogueLevel1 obj)
    {
        canvasDialog1.gameObject.SetActive(false);
        //player.ContinueMove();
        canvasMain.gameObject.SetActive(true);
    }

    private void HandleDialog2End(ScriptDialogueLevel1_2 obj)
    {
        canvasDialog2.gameObject.SetActive(false);
        //player.ContinueMove();
        //Debug.Log("canvasDialog2.gameObject.SetActive(false);");
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
