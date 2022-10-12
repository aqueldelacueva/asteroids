using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    
    //Variables del movimiento
    public float speed = 10;
    public float rotationSpeed = 10;
    
    //Variable del laser
    public GameObject Laser;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        //Movimiento de la nave
        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            Vector3 movimiento = new Vector3(0, vertical);
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("Impulsing", true);
        }
        else
        {
            //Parar animación cuando no hay movimiento
            anim.SetBool("Impulsing", false);
        }

        //Rotación de la nave (Usamos Euler Angles para utilizar de 0 a 365)
        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles += new Vector3(0, 0, horizontal * rotationSpeed * Time.deltaTime);

        //Disparo del laser
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(Laser);
        }
    }
}
