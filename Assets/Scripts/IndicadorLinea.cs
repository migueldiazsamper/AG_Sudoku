using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadorLinea : MonoBehaviour
{
    public static IndicadorLinea Instancia;

    int[,] datosLinea = new int[ 9 , 9 ]
    {
        {  0 ,  1 ,  2 ,     3 ,  4 ,  5 ,      6 ,  7 ,  8 } ,
        {  9 , 10 , 11 ,    12 , 13 , 14 ,     15 , 16 , 17 } ,
        { 18 , 19 , 20 ,    21 , 22 , 23 ,     24 , 25 , 26 } ,

        { 27 , 28 , 29 ,    30 , 31 , 32 ,     33 , 34 , 35 } ,
        { 36 , 37 , 38 ,    39 , 40 , 41 ,     42 , 43 , 44 } ,
        { 45 , 46 , 47 ,    48 , 49 , 50 ,     51 , 52 , 53 } ,

        { 54 , 55 , 56 ,    57 , 58 , 59 ,     60 , 61 , 62 } ,
        { 63 , 64 , 65 ,    66 , 67 , 68 ,     69 , 70 , 71 } ,
        { 72 , 73 , 74 ,    75 , 76 , 77 ,     78 , 79 , 80 }
    };

    int[] datosLineaEnteros = new int[ 81 ]
    {
         0 ,  1 ,  2 ,     3 ,  4 ,  5 ,      6 ,  7 ,  8 ,
         9 , 10 , 11 ,    12 , 13 , 14 ,     15 , 16 , 17 ,
        18 , 19 , 20 ,    21 , 22 , 23 ,     24 , 25 , 26 ,

        27 , 28 , 29 ,    30 , 31 , 32 ,     33 , 34 , 35 ,
        36 , 37 , 38 ,    39 , 40 , 41 ,     42 , 43 , 44 ,
        45 , 46 , 47 ,    48 , 49 , 50 ,     51 , 52 , 53 ,

        54 , 55 , 56 ,    57 , 58 , 59 ,     60 , 61 , 62 ,
        63 , 64 , 65 ,    66 , 67 , 68 ,     69 , 70 , 71 ,
        72 , 73 , 74 ,    75 , 76 , 77 ,     78 , 79 , 80
    };

    int[,] datosCuadrado = new int[ 9 , 9 ]
    {
        { 0 , 1 , 2 , 9 , 10 , 11 , 18 , 19 , 20 } ,
        { 3 , 4 , 5 , 12 , 13 , 14 , 21 , 22 , 23 } ,
        { 6 , 7 , 8 , 15 , 16 , 17 , 24 , 25 , 26 } ,
        { 27 , 28 , 29 , 36 , 37 , 38 , 45 , 46 , 47 } ,
        { 30 , 31 , 32 , 39 , 40 , 41 , 48 , 49 , 50 } ,
        { 33 , 34 , 35 , 42 , 43 , 44 , 51 , 52 , 53 } ,
        { 54 , 55 , 56 , 63 , 64 , 65 , 72 , 73 , 74 } ,
        { 57 , 58 , 59 , 66 , 67 , 68 , 75 , 76 , 77 } ,
        { 60 , 61 , 62 , 69 , 70 , 71 , 78 , 79 , 80 }
    };

    void Awake ()
    {
        if ( Instancia )
        {
            Destroy( Instancia );
        }

        Instancia = this;
    }

    ( int , int ) ObtenerPosicionCuadrado ( int indiceCuadrado )
    {
        int posicionFila = -1;
        int posicionColumna = -1;

        for ( int fila = 0 ; fila < 9 ; fila++ )
        {
            for ( int columna = 0 ; columna < 9 ; columna++ )
            {
                bool cuadradoEncontrado = datosLinea[ fila , columna ] == indiceCuadrado;
                if ( cuadradoEncontrado )
                {
                    posicionFila = fila;
                    posicionColumna = columna;
                    break;
                }
            }
        }

        return ( posicionFila , posicionColumna );
    }

    public int[] ObtenerFila ( int indiceCuadrado )
    {
        int[] linea = new int[ 9 ];
        var posicionCuadradoFila = ObtenerPosicionCuadrado( indiceCuadrado ).Item1;

        for ( int indice = 0 ; indice < 9 ; indice++ )
        {
            linea[ indice ] = datosLinea[ posicionCuadradoFila , indice ];
        }

        return linea;
    }

    public int[] ObtenerColumna ( int indiceCuadrado )
    {
        int[] linea = new int[ 9 ];
        var posicionCuadradoColumna = ObtenerPosicionCuadrado( indiceCuadrado ).Item2;

        for ( int indice = 0 ; indice < 9 ; indice++ )
        {
            linea[ indice ] = datosLinea[ indice , posicionCuadradoColumna ];
        }

        return linea;
    }

    public int[] ObtenerCuadrado ( int indiceCuadrado )
    {
        int[] linea = new int[ 9 ];
        int posicionFila = -1;

        for ( int fila = 0 ; fila < 9 ; fila++ )
        {
            for ( int columna = 0 ; columna < 9 ; columna++ )
            {
                bool cuadradoEncontrado = datosCuadrado[ fila , columna ] == indiceCuadrado;
                if ( cuadradoEncontrado )
                {
                    posicionFila = fila;
                    break;
                }
            }
        }

        for ( int indice = 0 ; indice < 9 ; indice++ )
        {
            linea[ indice ] = datosCuadrado[ posicionFila , indice ];
        }

        return linea;
    }

    public int[] ObtenerTodosIndicesCuadrados ()
    {
        return datosLineaEnteros;
    }
}
