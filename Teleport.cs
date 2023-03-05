using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //public Transform target;
    public Transform point1;
    public Transform point2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Enemy")
        {
            float tmpRandX = Random.Range(-5.6f, 2f);
            float tmpRandY = Random.Range(6.3f, 1.5f);
            collision.transform.position = new Vector2(tmpRandX, tmpRandY);
        }
    }
}
