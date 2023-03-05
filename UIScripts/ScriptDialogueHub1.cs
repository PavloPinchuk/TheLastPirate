using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptDialogueHub1 : MonoBehaviour
{
    public Button btnNext;
    public Text _text;
    private int number = 1;
    public Image dialogueImage;
    public Sprite spritePirate;
    public Sprite spriteScientist;

    public static event Action<ScriptDialogueHub1> OnDialogEnd;


    void Start()
    {
        btnNext.onClick.AddListener(Next);
    }

    void Next()
    {
        var res = "";
        switch(number)
        {
            case 1:
                {
                    res = "Rick: Welcome to my lab. This is where I create my inventions.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 2:
                {
                    res = "Morty: It looks very strange, never seen anything like it. You swear, this isn't some kind of magic?";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 3:
                {
                    res = "Rick: No, my friend, this is science! And now you can go to the portal.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 4:
                {
                    res = "Morty: Let`s go!.";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            
            default:
                {
                    OnDialogEnd?.Invoke(this);
                    break;
                }
        }
        _text.text = res;
        number++;
    }
}

