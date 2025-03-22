using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullscreenscript : MonoBehaviour
{
    public void Changescreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("dziala");
    }
}
