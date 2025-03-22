using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class cameracontroller : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float currentx;
    private Vector3 velocity =Vector3.zero;

    [SerializeField]
    private Transform player;
    [SerializeField]
    private float aheadDistance;
    [SerializeField]
    private float cameraspeed;

    private float lookAhead;

    [SerializeField]
    private Camera cam;


    public float targetZoom;

    private void Start()
    {
        targetZoom = cam.fieldOfView;
    }

    private void Update()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentx, 
        //transform.position.y,transform.position.z),ref velocity,speed);
        //targetZoom = cam.fieldOfView;
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x),Time.deltaTime* cameraspeed);
    }

    public void Movecamera(Transform _newroom)
    {
        currentx = _newroom.position.x;
    }
}
