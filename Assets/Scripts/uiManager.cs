using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class uiManager : MonoBehaviour
{
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI vidas;
    public TextMeshProUGUI bombas;
    public GameObject E;
    public GameObject gameOver;
    public int puntos;
    public int vida;
    public int bombs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.instance.vidas <= 0)
        { 
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
        if(gameManager.instance.nbombas > 0)
        {
            E.SetActive(true);
        }
        else
        {
            E.SetActive(false);
        }

        tiempo.text = Time.time.ToString("00.00");
        puntos = gameManager.instance.puntuacion;
        puntuacion.text = puntos.ToString();
        vida = gameManager.instance.vidas;
        vidas.text = vida.ToString();

        bombs = bomb.instance.nbombas;
        bombas.text = bombs.ToString();

    }
}
