using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShip : MonoBehaviour
{
    public float timer = 0.5f;
    public float time = 0;
    public float speed = 10;
    public GameObject Laser;
    public GameObject Trigger;
    public float laserdestroy;
    public float speed_min;
    public float speed_max;
    Rigidbody2D rb;
    Animator anim;
    CapsuleCollider2D collider;



    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        Vector2 direccion = new Vector2(Random.Range(-1f, 1f), 0);
        direccion = direccion * Random.Range(speed_min, speed_max);
        rb.AddForce(direccion);
    }




    void Update()
    {
        //Temporizador, si llega a los segundos indicados en "Timer" dispara aleatoriamente
        time += Time.deltaTime;
        if (time >= timer)
        {
            Vector3 rotacion = new Vector3(0, 0, Random.Range(0f, 360f));
            GameObject temp = Instantiate(Laser, Trigger.transform.position, Quaternion.Euler(rotacion));
            Destroy(temp, laserdestroy);
            time = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ship")
        {
            collision.gameObject.GetComponent<playerMovement>().Muerte();
        }
    }
    public void Muerte()
    {
        collider.enabled = false;
        gameManager.instance.puntuacion += 500;
        gameManager.instance.pbomba += 500;
        anim.SetBool("Death", true);
        Destroy(gameObject, 1f);
    }
}
