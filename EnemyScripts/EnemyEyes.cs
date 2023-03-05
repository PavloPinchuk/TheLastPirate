using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyes : MonoBehaviour
{

    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Player":
                enemy.GetComponent<Enemy>().attack(true);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Player":
                enemy.GetComponent<Enemy>().attack(false);
                break;
        }
    }
}
