using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalLevel1 : MonoBehaviour
{ 
    public string destination = "LvlHub";
    public static event Action<PortalLevel1> OnPlayerGoThroughPortal;
    public AudioSource audio;
    public SaveManager sm;
    public GameManager gm;

    private async Task OnTriggerEnter2D(Collider2D collision)
    {
        //if (destination == "GameOver" && collision.tag == "Player")
        //{
        //    collision.gameObject.GetComponent<PlayerStats>().GetDamage(9999);
        //}

        if (collision.tag == "Player" && gm.EnemyCount <= 0)
        {
            audio.Play();
            sm.currentLevel = 1;
            sm.Save();
            await
                Task.Delay(TimeSpan.FromSeconds(0.3));
            OnPlayerGoThroughPortal?.Invoke(this);
            SceneManager.LoadScene(destination);
        }
    }
}
