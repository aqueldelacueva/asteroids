using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public static bomb instance;
    public int pbomba;
    public int nbombas;
    public int asteroid;
    public int enemy;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pbomba = gameManager.instance.pbomba;

        if (pbomba >= 10000)
        {
            gameManager.instance.pbomba = 0;
            nbombas += 1;
        }

        if (nbombas >= 1 & Input.GetKeyDown(KeyCode.E))
        {
            GameObject[] find = GameObject.FindGameObjectsWithTag("Asteroid");

            foreach (GameObject item in find)
            {
                Destroy(item);
            }
            GameObject[] find2 = GameObject.FindGameObjectsWithTag("enemy");

            foreach (GameObject item in find2)
            {
                Destroy(item);
            }
            nbombas -= 1;

            asteroid = asteroidManager.instance.asteroides * 100;
            enemy = gameManager.instance.nEnemy * 500;
            gameManager.instance.puntuacion = gameManager.instance.puntuacion + asteroid;
            gameManager.instance.puntuacion = gameManager.instance.puntuacion + enemy;
            StartCoroutine(Respawn_Coroutine());
        }
    }

    IEnumerator Respawn_Coroutine()
        {
        yield return new WaitForSeconds(2f);
            asteroidManager.instance.asteroides = 0;
            gameManager.instance.nEnemy = 0;
    }
}
