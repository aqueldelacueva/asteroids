using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidControler : MonoBehaviour
{
    //Velocidad del asteroide
    public float speed_min;
    public float speed_max;
    Rigidbody2D rb;
    public asteroidManager manager;
    
    void Start()
    {
        //Seleccionamos el RigidBody del ateroide y le aplicamos velocidades y posiciones aleatorias
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direccion = direccion * Random.Range(speed_min, speed_max);
        rb.AddForce(direccion);
    }

    
    void Update()
    {
        
    }

    //Creamos la separacion de asteroides al dispararles
    public void Muerte()
    {
        if (transform.localScale.x > 0.25f)
        {
            //Al disparale, instanciamos otro asteroide y dividimos su tamaño entre 2
            GameObject temp1 = Instantiate(manager.asteroide, transform.position, transform.rotation);
            temp1.GetComponent<asteroidControler>().manager = manager;
            temp1.transform.localScale = transform.localScale * 0.5f;

            GameObject temp2 = Instantiate(manager.asteroide, transform.position, transform.rotation);
            temp2.GetComponent<asteroidControler>().manager = manager;
            temp2.transform.localScale = transform.localScale * 0.5f;
        }

        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ship")
        {
            collision.gameObject.GetComponent<playerMovement>().Muerte();
        }
    }
}
