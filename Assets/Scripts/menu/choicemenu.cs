using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choicemenu : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Level2()
    {
        SceneManager.LoadSceneAsync(3);
    }
    
}
