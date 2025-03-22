using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class play : MonoBehaviour
{


    public void Startgame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Mainmenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1f;
    }
    public void Options()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void Options2()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void Playlvl1()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Playlvl2()
    {
        SceneManager.LoadSceneAsync(3);
    }
    
    public void Quitgg()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
