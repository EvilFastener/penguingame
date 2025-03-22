using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingscrpt : MonoBehaviour
{
    private float Falldelay = 1f;
    [SerializeField]
    private Rigidbody2D rb;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        // Zapisanie pocz¹tkowego stanu gruntu
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        rb = GetComponent<Rigidbody2D>();

        
        if (rb != null)
        {
            rb.isKinematic = true;  
        }
    }
    public void ResetPlatform()
    {
        gameObject.SetActive(true);
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        // Resetowanie fizyki, jeœli jest potrzeba
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(Falldelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        gameObject.SetActive(false);
    }
    
}
