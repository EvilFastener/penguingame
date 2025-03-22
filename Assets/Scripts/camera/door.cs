using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField]
    private Transform previousroom;

    [SerializeField]
    private Transform nextroom;

    [SerializeField]
    private cameracontroller cam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (other.transform.position.x < transform.position.x)
            {
                cam.Movecamera(nextroom);
            }
            else
            {
                cam.Movecamera(previousroom);
            }
        }
    }
}
