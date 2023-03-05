using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{

    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Wall":
//                enemy.GetComponent<Enemy>().moveRight();
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Wall":
 //               enemy.GetComponent<Enemy>().moveRight(false);
                break;
        }
    }
}
