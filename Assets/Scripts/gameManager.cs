using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public static gameManager instance;
    public int vidas;
    public int puntuacion;


    private void Awake()
    {
        instance = this; 
    }

}
