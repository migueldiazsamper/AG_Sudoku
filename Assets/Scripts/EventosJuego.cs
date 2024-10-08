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
}
