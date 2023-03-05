using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    public static event Action<MedKit> OnMedKitLooted;
    public AudioSource medkitSound;
    public Transform publicPoint1;
    public Transform publicPoint2;
    public bool arenaMode = false;

    float x1, x2, y1, y2;

    private void Start()
    {
        gameObject.SetActive(true);

        x1 = publicPoint1.position.x;
        x2 = publicPoint2.position.x;

        y1 = publicPoint1.position.y;
        y2 = publicPoint2.position.y;
    }

    private async void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                other.gameObject.GetComponent<PlayerStats>().addHealth(20);
                if (other.gameObject.GetComponent<PlayerStats>().getHealth() > 100)
                {
                    other.gameObject.GetComponent<PlayerStats>().setHealth(100);
                }
                medkitSound.Play();
                await
                    Task.Delay(TimeSpan.FromSeconds(0.4));
                gameObject.SetActive(false);
                OnMedKitLooted?.Invoke(this);
                if (arenaMode)
                {
                    SpawnMedKit();
                }
                break;
        }
    }

    private void SpawnMedKit()
    {
        transform.position = new Vector2(UnityEngine.Random.Range(x1, x2), UnityEngine.Random.Range(y1, y2));
        gameObject.SetActive(true);
    }

}
