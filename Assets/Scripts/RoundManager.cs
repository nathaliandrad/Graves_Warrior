using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    int num;
    int numBoss;
    public GameObject boss;
    public AudioSource speaker;
    public AudioClip bossSpawn;
    public AudioClip winSound;

    public void Start()
    {
        num = 0;
        numBoss = 0;
    }


    public void EnemyCount()
    {
        
        num++;
        print("num:" + num);
        if (num == 15)
        {
            speaker.PlayOneShot(bossSpawn, 0.5f);
            boss.SetActive(true);
        }

    }

    public GameObject winCanvas;
    public void BossCount()
    {
        numBoss++;
        if (numBoss == 2)
        {
            speaker.PlayOneShot(winSound, 0.5f);
            StartCoroutine("YouWin");
           // print("Congrats, you win!");
        }
    }

    public IEnumerator YouWin()
    {
        yield return new WaitForSeconds(1f);
        winCanvas.SetActive(true);
        yield return new WaitForSeconds(5f);
        winCanvas.SetActive(false);
        SceneManager.LoadScene(0);
    }

   
}
