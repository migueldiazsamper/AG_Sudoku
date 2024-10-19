using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosJuego : MonoBehaviour
{
    public delegate void ActualizarNumeroCuadrado ( int numero );
    public static event ActualizarNumeroCuadrado OnActualizarNumeroCuadrado;

    public static void MetodoActualizarNumeroCuadrado ( int numero )
    {
        bool noEsNulo = OnActualizarNumeroCuadrado != null;

        if ( noEsNulo )
        {
            OnActualizarNumeroCuadrado ( numero );
        }
    }

    public delegate void CuadradoSeleccionado ( int indiceCuadrado );
    public static event CuadradoSeleccionado OnCuadradoSeleccionado;

    public static void MetodoCuadradoSeleccionado ( int indiceCuadrado )
    {
        bool noEsNulo = OnCuadradoSeleccionado != null;

        if ( noEsNulo )
        {
            OnCuadradoSeleccionado ( indiceCuadrado );
        }
    }

    public delegate void NumeroIncorrecto ();
    public static event NumeroIncorrecto OnNumeroIncorrecto;

    public static void MetodoNumeroIncorrecto ()
    {
        bool noEsNulo = OnNumeroIncorrecto != null;
        if ( noEsNulo )
        {
            OnNumeroIncorrecto();
        }
    }

    public delegate void GameOver ();
    public static event GameOver OnGameOver;

    public static void MetodoGameOver ()
    {
        bool noEsNulo = OnGameOver != null;
        if ( noEsNulo )
        {
            OnGameOver();
        }
    }

    public delegate void BorrarNumero ();
    public static event BorrarNumero OnBorrarNumero;

    public static void MetodoBorrarNumero ()
    {
        bool noEsNulo = OnBorrarNumero != null;
        if ( noEsNulo )
        {
            OnBorrarNumero();
        }
    }
}
