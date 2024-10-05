using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que representa una cuadrícula de Sudoku en Unity
public class CuadriculaSudoku : MonoBehaviour
{
    // Variables serializadas para configurar la cuadrícula desde el editor de Unity
    [ SerializeField ] int columnas = 0; // Número de columnas en la cuadrícula
    [ SerializeField ] int filas = 0; // Número de filas en la cuadrícula
    [ SerializeField ] float distanciaCuadrados = 0.0f; // Distancia entre los cuadrados de la cuadrícula
    [ SerializeField ] GameObject cuadriculaBase; // Prefab base para cada cuadrado de la cuadrícula
    [ SerializeField ] Vector2 posicionInicial = new Vector2( 0.0f , 0.0f ); // Posición inicial de la cuadrícula
    [ SerializeField ] float escalaCuadrado = 1.0f; // Escala de cada cuadrado en la cuadrícula

    // Lista para almacenar los objetos de la cuadrícula
    List< GameObject > cuadricula = new List< GameObject >();

    int datosSeleccionadosCuadricula = -1; // Número que representa qué dificultad de datos de Sudoku se ha seleccionado

    // Método llamado al inicio del juego
    void Start ()
    {
        CrearCuadricula(); // Crear la cuadrícula
        PonerNumerosEnCuadricula( Ajustes.Instancia.ObtenerDificultad() ); // Poner números en la cuadrícula
    }

    // Método para crear la cuadrícula
    void CrearCuadricula ()
    {
        CrearCuadrados(); // Crear los cuadrados de la cuadrícula
        PosicionarCuadrados(); // Posicionar los cuadrados en la cuadrícula
    }

    // Método para crear los cuadrados de la cuadrícula
    void CrearCuadrados ()
    {
        // Bucle para crear cada cuadrado en la cuadrícula
        for ( int fila = 0 ; fila < filas ; fila++ )
        {
            for ( int columna = 0 ; columna < columnas ; columna++ )
            {
                // Instanciar el prefab del cuadrado y añadirlo a la lista
                cuadricula.Add( Instantiate( cuadriculaBase ) as GameObject );
                // Establecer el padre del cuadrado como el objeto actual
                cuadricula[ cuadricula.Count - 1 ].transform.parent = this.transform;
                // Ajustar la escala del cuadrado
                cuadricula[ cuadricula.Count - 1 ].transform.localScale = new Vector3( escalaCuadrado , escalaCuadrado , escalaCuadrado );
            }
        }
    }

    // Método para posicionar los cuadrados en la cuadrícula
    void PosicionarCuadrados ()
    {
        // Obtener el RectTransform del primer cuadrado
        RectTransform rectTransform = cuadricula[ 0 ].GetComponent< RectTransform >();
        // Calcular la distancia entre los cuadrados
        Vector2 distancia = new Vector2();
        distancia.x = rectTransform.rect.width * rectTransform.transform.localScale.x + distanciaCuadrados;
        distancia.y = rectTransform.rect.height * rectTransform.transform.localScale.y + distanciaCuadrados;

        int numeroColumna = 0; // Contador de columnas
        int numeroFila = 0; // Contador de filas

        // Bucle para posicionar cada cuadrado en la cuadrícula
        foreach ( GameObject cuadrado in cuadricula )
        {
            // Si se ha alcanzado el límite de columnas, reiniciar el contador de columnas y aumentar el contador de filas
            if ( numeroColumna + 1 > columnas )
            {
                numeroColumna = 0;
                numeroFila++;
            }

            // Calcular la posición del cuadrado
            var distanciaX = distancia.x * numeroColumna;
            var distanciaY = distancia.y * numeroFila;
            // Establecer la posición del cuadrado
            cuadrado.GetComponent< RectTransform >().anchoredPosition = new Vector2( posicionInicial.x + distanciaX , posicionInicial.y - distanciaY );
            numeroColumna++; // Incrementar el contador de columnas
        }
    }

    // Método para poner números en los cuadrados de la cuadrícula
    void PonerNumerosEnCuadricula ( string nivel )
    {
        // Bucle para poner un número aleatorio en cada cuadrado
        /* foreach ( GameObject cuadrado in cuadricula )
        {
            cuadrado.GetComponent< CuadriculaBase >().PonerNumero( Random.Range( 0 , 10 ) );
        } */

        datosSeleccionadosCuadricula = Random.Range( 0 , DatosSudoku.Instancia.juegoSudoku[ nivel ].Count ); // Seleccionar un conjunto de datos de Sudoku aleatorio
        var datos = DatosSudoku.Instancia.juegoSudoku[ nivel ][ datosSeleccionadosCuadricula ]; // Obtener los datos de Sudoku seleccionados

        EstablecerDatosEnCuadricula( datos ); // Establecer los datos sin resolver en la cuadrícula
    }

    void EstablecerDatosEnCuadricula ( DatosSudoku.DatosSudokuTabla datos )
    {

        // Bucle para establecer los datos sin resolver en la cuadrícula
        for ( int indice = 0 ; indice < cuadricula.Count ; indice++ )
        {
            cuadricula[ indice ].GetComponent< CuadriculaBase >().PonerNumero( datos.datosSinResolver[ indice ] );
        }
    }
}