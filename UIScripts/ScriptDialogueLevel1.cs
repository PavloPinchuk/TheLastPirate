using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptDialogueLevel1 : MonoBehaviour
{
    public Button btnNext;
    public Text _text;
    private int number = 1;
    public Image dialogueImage;
    public Sprite spritePirate;
    public Sprite spriteScientist;

    public static int OnDialog2End { get; internal set; }

    //public Canvas canvasThis;
    //public Canvas canvasMain;

    public static event Action<ScriptDialogueLevel1> OnDialogEnd;

    //public GameObject portal;

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
                    res = "Morty: Who are you?";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 2:
                {
                    res = "Rick: My name is Rick, nice to meet you.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 3:
                {
                    res = "Morty: And I'm Morty. Tell me, where are we?";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 4:
                {
                    res = "Rick: Oh, so you're not from this time either, are you? Interesting. I should have guessed, you are not at all like the other residents.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 5:
                {
                    res = "Morty: What does it mean not from this time? Here I am, standing here.";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 6:
                {
                    res = "Rick: Well, it is so, but tell me, do you remember how you ended up here? And don't these creatures you saw seem strange to you?";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 7:
                {
                    res = "Morty: No, I don't remember, maybe I drank a lot. And I really did not see such creatures, but few creatures living in these waters could crawl ashore.";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 8:
                {
                    res = "Rick: I'm glad you're trying to find a logical explanation, but it's a lot more complicated than you think.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 9:
                {
                    res = "Morty: Explain.";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 10:
                {
                    res = "Rick: Well, you just didn't get mad at me. You see, the reason you are here is related to my research.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 11:
                {
                    res = "Morty: So it's your fault?!! I will strangle you with my bare hands now!!";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 12:
                {
                    res = "Rick: Wait, I'm not on purpose. You see, I ended up here too. Long story short, I was making a machine that allows you to travel through time and space, but the experiment didn't go according to plan, and it seemed to take on a life of its own.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 13:
                {
                    res = "Morty: Time Machine? This cannot be!";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 14:
                {
                    res = "Rick: Well, in your time they haven't thought of that yet, I think you just recently discovered the Americas.. oh, sorry, India. *Mumbles under his breath* I have to be careful with what I say so as not to change the course of history.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 15:
                {
                    res = "Morty: Well, if you are so smart, then fix it all.";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 16:
                {
                    res = "Rick: I'll try, but I need your help.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 17:
                {
                    res = "Morty: Because of you, I ended up here, because of you, my family bottle of rum was stolen, and you still want me to help you??";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 18:
                {
                    res = "Rick: I'm guilty, I admit it. But I definitely won't be able to do it myself, and you, as far as I'm concerned, are made of tough dough. I'll help you get the bottle back and get to your time, and you help me catch that Indohyus.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 19:
                {
                    res = "Morty: Who?";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 20:
                {
                    res = "Rick: Indohyus. Well, the creature that took the bottle from you. They have some element in the body that I need to repair the machine.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 21:
                {
                    res = "Morty: There is a whole bunch of them, take as much as you want.";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 22:
                {
                    res = "Rick: No, I need that one. You saw, he is special, smarter than others.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 23:
                {
                    res = "Morty: Okay, but how do I catch him? That portal has already closed.";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 24:
                {
                    res = "Rick: I predicted that this could happen, my car keeps a history of jumps. Now I'll set everything up, while you get ready, time jumps put a lot of strain on the body.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 25:
                {
                    res = "Morty: Is it really safe?";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 26:
                {
                    res = "Rick: Of course, 20 percent that everything will go well.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            case 27:
                {
                    res = "Morty: And the other 80??";
                    dialogueImage.sprite = spritePirate;
                    break;
                }
            case 28:
                {
                    res = "Rick: Don't think about it, let's jump already, ha ha.";
                    dialogueImage.sprite = spriteScientist;
                    break;
                }
            default:
                {
                    //GameObject.FindGameObjectWithTag("CanvasMain").SetActive(true);
                    //GameObject.FindGameObjectWithTag("CanvasDialogueLevel1").SetActive(false);

                    //canvasMain.gameObject.SetActive(true);   !!!
                    //portal.SetActive(true);
                    //canvasThis.gameObject.SetActive(false);   !!!

                    OnDialogEnd?.Invoke(this);
                    break;
                }
        }
        _text.text = res;
        number++;
    }
}
