using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    public List< GameObject > imagenesDeError;
    public GameObject popupGameOver;
    int vidas = 0;
    int numeroDeError = 0;

    void Start ()
    {
        vidas = imagenesDeError.Count;
        numeroDeError = 0;
    }

    void NumeroIncorrecto ()
    {
        bool cometidoUnError = numeroDeError < imagenesDeError.Count;
        if ( cometidoUnError )
        {
            imagenesDeError[ numeroDeError ].SetActive( true );
            numeroDeError++;
            vidas--;
        }

        ComprobarGameOver();
    }

    void ComprobarGameOver ()
    {
        bool gameOver = vidas <= 0;
        if ( gameOver )
        {
            EventosJuego.MetodoGameOver();
            popupGameOver.SetActive( true );
        }
    }

    void OnEnable ()
    {
        EventosJuego.OnNumeroIncorrecto += NumeroIncorrecto;
    }

    void OnDisable ()
    {
        EventosJuego.OnNumeroIncorrecto -= NumeroIncorrecto;
    }
}
