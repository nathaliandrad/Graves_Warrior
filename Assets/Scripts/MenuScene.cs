using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public AudioSource speaker;

    public void Start()
    {
        speaker.Play(1);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Instructions()
    {
        print("quitting game");
        SceneManager.LoadScene(2);
    }

}
