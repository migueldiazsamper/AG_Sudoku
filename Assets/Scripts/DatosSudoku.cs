using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que maneja los datos de Sudoku en modo fácil
public class DatosSudokuFacil : MonoBehaviour
{
    // Método estático para obtener los datos de Sudoku en modo fácil
    public static List< DatosSudoku.DatosSudokuTabla > cogerDatos ()
    {
        // Crear una lista para almacenar los datos de Sudoku
        List< DatosSudoku.DatosSudokuTabla > datos = new List< DatosSudoku.DatosSudokuTabla >();

        // Añadir un nuevo conjunto de datos de Sudoku a la lista
        datos.Add( new DatosSudoku.DatosSudokuTabla( 
            new int[ 81 ] 
            { 
                5, 3, 0, 0, 7, 0, 0, 0, 0,
                6, 0, 0, 1, 9, 5, 0, 0, 0,
                0, 9, 8, 0, 0, 0, 0, 6, 0,
                8, 0, 0, 0, 6, 0, 0, 0, 3,
                4, 0, 0, 8, 0, 3, 0, 0, 1,
                7, 0, 0, 0, 2, 0, 0, 0, 6,
                0, 6, 0, 0, 0, 0, 2, 8, 0,
                0, 0, 0, 4, 1, 9, 0, 0, 5,
                0, 0, 0, 0, 8, 0, 0, 7, 9 
            } ,

            new int[ 81 ]
            {
                5, 3, 4, 6, 7, 8, 9, 1, 2,
                6, 7, 2, 1, 9, 5, 3, 4, 8,
                1, 9, 8, 3, 4, 2, 5, 6, 7,
                8, 5, 9, 7, 6, 1, 4, 2, 3,
                4, 2, 6, 8, 5, 3, 7, 9, 1,
                7, 1, 3, 9, 2, 4, 8, 5, 6,
                9, 6, 1, 5, 3, 7, 2, 8, 4,
                2, 8, 7, 4, 1, 9, 6, 3, 5,
                3, 4, 5, 2, 8, 6, 1, 7, 9
            } ) );

        // Devolver la lista de datos de Sudoku
        return datos;
    }
}

// Clase que maneja los datos de Sudoku en modo medio
public class DatosSudokuMedio : MonoBehaviour
{
    // Método estático para obtener los datos de Sudoku en modo medio
    public static List< DatosSudoku.DatosSudokuTabla > cogerDatos ()
    {
        // Crear una lista para almacenar los datos de Sudoku
        List< DatosSudoku.DatosSudokuTabla > datos = new List< DatosSudoku.DatosSudokuTabla >();

        // Añadir un nuevo conjunto de datos de Sudoku a la lista
        datos.Add( new DatosSudoku.DatosSudokuTabla( 
            new int[ 81 ] 
            { 
                5, 3, 0, 0, 7, 0, 0, 0, 0,
                6, 0, 0, 1, 9, 5, 0, 0, 0,
                0, 9, 8, 0, 0, 0, 0, 6, 0,
                8, 0, 0, 0, 6, 0, 0, 0, 3,
                4, 0, 0, 8, 0, 3, 0, 0, 1,
                7, 0, 0, 0, 2, 0, 0, 0, 6,
                0, 6, 0, 0, 0, 0, 2, 8, 0,
                0, 0, 0, 4, 1, 9, 0, 0, 5,
                0, 0, 0, 0, 8, 0, 0, 7, 9 
            } ,

            new int[ 81 ]
            {
                5, 3, 4, 6, 7, 8, 9, 1, 2,
                6, 7, 2, 1, 9, 5, 3, 4, 8,
                1, 9, 8, 3, 4, 2, 5, 6, 7,
                8, 5, 9, 7, 6, 1, 4, 2, 3,
                4, 2, 6, 8, 5, 3, 7, 9, 1,
                7, 1, 3, 9, 2, 4, 8, 5, 6,
                9, 6, 1, 5, 3, 7, 2, 8, 4,
                2, 8, 7, 4, 1, 9, 6, 3, 5,
                3, 4, 5, 2, 8, 6, 1, 7, 9
            } ) );

        // Devolver la lista de datos de Sudoku
        return datos;
    }
}

// Clase que maneja los datos de Sudoku en modo difícil
public class DatosSudokuDificil : MonoBehaviour
{
    // Método estático para obtener los datos de Sudoku en modo difícil
    public static List< DatosSudoku.DatosSudokuTabla > cogerDatos ()
    {
        // Crear una lista para almacenar los datos de Sudoku
        List< DatosSudoku.DatosSudokuTabla > datos = new List< DatosSudoku.DatosSudokuTabla >();

        // Añadir un nuevo conjunto de datos de Sudoku a la lista
        datos.Add( new DatosSudoku.DatosSudokuTabla( 
            new int[ 81 ] 
            { 
                5, 3, 0, 0, 7, 0, 0, 0, 0,
                6, 0, 0, 1, 9, 5, 0, 0, 0,
                0, 9, 8, 0, 0, 0, 0, 6, 0,
                8, 0, 0, 0, 6, 0, 0, 0, 3,
                4, 0, 0, 8, 0, 3, 0, 0, 1,
                7, 0, 0, 0, 2, 0, 0, 0, 6,
                0, 6, 0, 0, 0, 0, 2, 8, 0,
                0, 0, 0, 4, 1, 9, 0, 0, 5,
                0, 0, 0, 0, 8, 0, 0, 7, 9 
            } ,

            new int[ 81 ]
            {
                5, 3, 4, 6, 7, 8, 9, 1, 2,
                6, 7, 2, 1, 9, 5, 3, 4, 8,
                1, 9, 8, 3, 4, 2, 5, 6, 7,
                8, 5, 9, 7, 6, 1, 4, 2, 3,
                4, 2, 6, 8, 5, 3, 7, 9, 1,
                7, 1, 3, 9, 2, 4, 8, 5, 6,
                9, 6, 1, 5, 3, 7, 2, 8, 4,
                2, 8, 7, 4, 1, 9, 6, 3, 5,
                3, 4, 5, 2, 8, 6, 1, 7, 9
            } ) );

        // Devolver la lista de datos de Sudoku
        return datos;
    }
}

// Clase que maneja los datos de Sudoku en modo muy difícil
public class DatosSudokuMuyDificil : MonoBehaviour
{
    // Método estático para obtener los datos de Sudoku en modo muy difícil
    public static List< DatosSudoku.DatosSudokuTabla > cogerDatos ()
    {
        // Crear una lista para almacenar los datos de Sudoku
        List< DatosSudoku.DatosSudokuTabla > datos = new List< DatosSudoku.DatosSudokuTabla >();

        // Añadir un nuevo conjunto de datos de Sudoku a la lista
        datos.Add( new DatosSudoku.DatosSudokuTabla( 
            new int[ 81 ] 
            { 
                5, 3, 0, 0, 7, 0, 0, 0, 0,
                6, 0, 0, 1, 9, 5, 0, 0, 0,
                0, 9, 8, 0, 0, 0, 0, 6, 0,
                8, 0, 0, 0, 6, 0, 0, 0, 3,
                4, 0, 0, 8, 0, 3, 0, 0, 1,
                7, 0, 0, 0, 2, 0, 0, 0, 6,
                0, 6, 0, 0, 0, 0, 2, 8, 0,
                0, 0, 0, 4, 1, 9, 0, 0, 5,
                0, 0, 0, 0, 8, 0, 0, 7, 9 
            } ,

            new int[ 81 ]
            {
                5, 3, 4, 6, 7, 8, 9, 1, 2,
                6, 7, 2, 1, 9, 5, 3, 4, 8,
                1, 9, 8, 3, 4, 2, 5, 6, 7,
                8, 5, 9, 7, 6, 1, 4, 2, 3,
                4, 2, 6, 8, 5, 3, 7, 9, 1,
                7, 1, 3, 9, 2, 4, 8, 5, 6,
                9, 6, 1, 5, 3, 7, 2, 8, 4,
                2, 8, 7, 4, 1, 9, 6, 3, 5,
                3, 4, 5, 2, 8, 6, 1, 7, 9
            } ) );

        // Devolver la lista de datos de Sudoku
        return datos;
    }
}

// Clase principal que maneja los datos de Sudoku
public class DatosSudoku : MonoBehaviour
{
    public static DatosSudoku Instancia; // Instancia estática de la clase DatosSudoku

    // Estructura que contiene los datos de una tabla de Sudoku
    public struct DatosSudokuTabla
    {
        public int[] datosSinResolver; // Datos sin resolver del Sudoku
        public int[] datosResueltos; // Datos resueltos del Sudoku

        // Constructor de la estructura DatosSudokuTabla
        public DatosSudokuTabla( int[] sinResolver , int[] resueltos ) : this()
        {
            this.datosSinResolver = sinResolver; // Asignar datos sin resolver
            this.datosResueltos = resueltos; // Asignar datos resueltos
        }
    };

    // Diccionario que almacena las listas de datos de Sudoku por dificultad
    public Dictionary< string , List< DatosSudokuTabla > > juegoSudoku = new Dictionary< string , List< DatosSudokuTabla > >();

    // Método llamado al despertar el objeto
    void Awake()
    {
        // Si no hay una instancia, asignar esta instancia
        if ( Instancia == null )
        {
            Instancia = this;
        }
        else // Si ya hay una instancia, destruir esta instancia
        {
            Destroy( this );
        }
    }

    // Método llamado al inicio del juego
    void Start()
    {
        // Añadir los datos de Sudoku por dificultad al diccionario
        juegoSudoku.Add( "Fácil" , DatosSudokuFacil.cogerDatos() );
        juegoSudoku.Add( "Medio" , DatosSudokuMedio.cogerDatos() );
        juegoSudoku.Add( "Difícil" , DatosSudokuDificil.cogerDatos() );
        juegoSudoku.Add( "MuyDifícil" , DatosSudokuMuyDificil.cogerDatos() );
    }
}