using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemySpawned;
    //public Transform spawnPoint;

    public Transform point1;
    public Transform point2;

    public void SpawnEnemy(float enemyDamage)
    {
        GameObject enemy;
        try
        {
            enemy = Instantiate(enemySpawned);
            
        }
        catch (System.NullReferenceException)
        {
            return;
        }

        bool flag = false;
        while (!flag)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            float tmpRandX = Random.Range(point1.transform.position.x, point2.transform.position.x);
            float tmpRandY = Random.Range(point1.transform.position.y, point2.transform.position.y);

            try
            {
                if ((tmpRandX < player.transform.position.x + 10 || tmpRandX < player.transform.position.x - 10) &&
                    (tmpRandY < player.transform.position.y + 10 || tmpRandY < player.transform.position.y - 10))
                {
                    flag = true;
                    enemy.transform.position = new Vector2(tmpRandX, tmpRandY);
                    //enemy.transform.rotation = spawnPoint.rotation;
                    enemy.SetActive(true);

                }
            }
            catch (System.NullReferenceException)
            {
                return;
            }
        }
    }
}
