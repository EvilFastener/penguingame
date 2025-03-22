using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class mosv2 : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D body;
    private Animator a;
    private BoxCollider2D bc;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private LayerMask wallLayer;
    private void Awake()
    {
        body=GetComponent<Rigidbody2D>();
        a = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && isgrounded())
            Jump();
        Flipiinyo();
        a.SetBool("walk", horizontalinput != 0);
        a.SetBool("grounded", isgrounded());
        onwall();
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, 12);
        //grounded = false;
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "ground")
           // grounded = true;
    }*/
    private void Flipiinyo()
    {
        bool playerismoving = Mathf.Abs(body.velocity.x) > 0;
        if(playerismoving )
        {
            transform.localScale = new Vector2(Mathf.Sign(body.velocity.x)* 0.3F, 0.3F);
        }
    }
     private bool isgrounded()
     {
         RaycastHit2D rc = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0, Vector2.down, 0.1F, groundLayer);
         return rc.collider != null;
     }
     private bool onwall()
     {
         RaycastHit2D rc = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1F, wallLayer);
         return rc.collider != null;
     }
}
