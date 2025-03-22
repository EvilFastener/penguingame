using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    
    private Transform currentCheckpoint;
    private Health playerhealth;
    [SerializeField]
    public fallingscrpt[] platforms;

    private void Awake()
    {
        playerhealth = GetComponent<Health>();
    }
    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        playerhealth.Rrespawn();

        Camera.main.GetComponent<cameracontroller>().Movecamera(currentCheckpoint.parent);
        foreach (var platform in platforms)
        {
            platform.ResetPlatform();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag =="checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
    
}
