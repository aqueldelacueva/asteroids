using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletController : MonoBehaviour
{

    public float speed = 300;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.up * speed);
    }


    void Update()
    {

    }

    //Detectamos si algo entra en colision con el asteroide
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<asteroidControler>().Muerte();
            Destroy(gameObject);
        }
        if (collision.tag == "Ship")
        {
            collision.gameObject.GetComponent<playerMovement>().Muerte();
            Destroy(gameObject);
        }
    }
}
