using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public static gameManager instance;
    public int vidas;
    public int puntuacion;
    public int pbomba;
    public int nbombas;
    public int nEnemy;

    private void Awake()
    {
        instance = this; 
    }

    void Update()
    {
        nbombas = bomb.instance.nbombas;
    }
}
