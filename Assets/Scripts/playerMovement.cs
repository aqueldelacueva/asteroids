using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    
    //Variables del movimiento
    public float speed = 10;
    public float rotationSpeed = 10;

    //Variable tiempo destrucción laser
    public float laserdestroy;
    
    //Variable del laser
    public GameObject Laser;

    //Variable del Empty desde donde saldra el laser
    public GameObject Trigger;


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
            GameObject temp = Instantiate(Laser, Trigger.transform.position, transform.rotation);
            Destroy(temp, laserdestroy);
        }
    }

    public void Muerte()
    {
        anim.SetBool("Death", true);
        Destroy(gameObject, 1.2f);
        
    }
}
