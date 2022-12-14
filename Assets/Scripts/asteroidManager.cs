using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidManager : MonoBehaviour
{
    //Variables para la velocidad del asteoide y su cantidad
    public static asteroidManager instance;
    public int asteroides;

    public int asteroides_min = 2;
    public int asteroides_max = 8;
    public float limitX = 10;
    public float limitY = 6;
    public GameObject asteroide;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CrearAteroides();
    }


    void Update()
    {
        if(asteroides <= 0)
        {
            asteroides_min += 2;
            asteroides_max += 2;
            CrearAteroides();
        }
    }

    void CrearAteroides()
    {
        int asteroides = Random.Range(asteroides_min, asteroides_max);

        //Hacemos un bucle para la generacion de asteroides
        for (int i = 0; i < asteroides; i++)
        {
            
            Vector3 posicion = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));

            while (Vector3.Distance(posicion, new Vector3(0,0,0)) < 2)
            {
                posicion = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));
            }

            Vector3 rotacion = new Vector3(0, 0, Random.Range(0f, 360f));
            //almacenamos el asteroide generado
            GameObject temp = Instantiate(asteroide, posicion, Quaternion.Euler(rotacion));
            temp.GetComponent<asteroidControler>().manager = this;
        }
    }
}
