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
    CircleCollider2D collider;
    
    //Variables del movimiento
    public float speed = 10;
    public float rotationSpeed = 10;

    //Variable tiempo destrucción laser
    public float laserdestroy;
    
    //Variable del laser
    public GameObject Laser;

    //Variable del Empty desde donde saldra el laser
    public GameObject Trigger;

    public GameObject particulasmuerte;
    bool muerte;



    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
    }

    
    void Update()
    {
        if (muerte)
        {

        }
        else
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
        GameObject temp = Instantiate(particulasmuerte, transform.position, transform.rotation);
        Destroy (temp, 2.5f);

        if (gameManager.instance.vidas <= 0)
        {
            Destroy(gameObject, 1.2f);
        }
        else
        {
            StartCoroutine(Respawn_Coroutine());
        }
        
        
    }

    IEnumerator Respawn_Coroutine()
    {
        muerte = true;
        anim.SetBool("Death", true);
        collider.enabled = false;
        yield return new WaitForSeconds(1.5f);

        gameManager.instance.vidas -= 1;
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);
        anim.SetBool("Death", false);
        muerte = false;
        yield return new WaitForSeconds(2);
        collider.enabled = true;


    }
}
