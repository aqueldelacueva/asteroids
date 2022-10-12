using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidControler : MonoBehaviour
{
    //Velocidad del asteroide
    public float speed_min;
    public float speed_max;
    Rigidbody2D rb;
    
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
}
