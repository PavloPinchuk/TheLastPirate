using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabRoof : MonoBehaviour
{
    public GameObject roof;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            roof.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            roof.SetActive(true);
        }
    }
}
