using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{

    public GameObject spawner;
    public float timer = 2f;
    public float time = 0;
    private float limitX = 9;
    private float limitY = 5;
    Rigidbody2D rb;
    public float speed;
    public int rotacion = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= timer)
        {
            Vector3 posicion = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));
            Vector3 rotacion = new Vector3(0, 0, 0);
            GameObject temp = Instantiate(spawner, posicion, Quaternion.Euler(rotacion));
            time = 0;

        }
    }
}
