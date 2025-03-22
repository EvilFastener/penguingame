//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class movement : MonoBehaviour
//{
//    [SerializeField]
//    private float speed;
//    private Rigidbody2D body;
//    //private Animator a;
//    private bool grounded;

//    private void Awake()
//    {
//        body = GetComponent<Rigidbody2D>();
//        //a = GetComponent<Animator>();
//    }
//    private void Update()
//    {
//        float Horizontal = Input.GetAxis("Horizontal");
//        body.velocity = new Vector2(Horizontal * speed,body.velocity.y);

//        if (Horizontal > 0.01f)
//            transform.localScale =  Vector3.one;
//        if (Horizontal < -0.01f)
//            transform.localScale = new Vector3(-1,1,1);

//        if (Input.GetKey(KeyCode.Space)&& grounded == true)
//            Jump();

//        //a.SetBool("run", Horizontal != 0);
//        //a.SetBool("hump", grounded);
//    }
//    private void Jump()
//    {
//        body.velocity = new Vector2(body.velocity.x, 5);
//       // a.SetTrigger("jump");
//        grounded = false;
//    }
//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.tag == "ground")
//            grounded = true;
//    }
//}
