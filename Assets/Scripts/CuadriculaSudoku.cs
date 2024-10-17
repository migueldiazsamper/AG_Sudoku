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
    [ SerializeField ] float huecoCasilla = 0.1f; // Hueco entre las casillas de la cuadrícula

    // Lista para almacenar los objetos de la cuadrícula
    List< GameObject > cuadricula = new List< GameObject >();

    int datosSeleccionadosCuadricula = -1; // Número que representa qué dificultad de datos de Sudoku se ha seleccionado

    public Color colorResaltado = Color.blue; // Color para resaltar los cuadrados seleccionados

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
        int indiceCuadrados = 0; // Índice de los cuadrados en la cuadrícula
        // Bucle para crear cada cuadrado en la cuadrícula
        for ( int fila = 0 ; fila < filas ; fila++ )
        {
            for ( int columna = 0 ; columna < columnas ; columna++ )
            {
                // Instanciar el prefab del cuadrado y añadirlo a la lista
                cuadricula.Add( Instantiate( cuadriculaBase ) as GameObject );
                // Establecer el índice del cuadrado en la cuadrícula
                cuadricula[ cuadricula.Count - 1 ].GetComponent< CuadriculaBase >().EstablecerIndiceCuadrado( indiceCuadrados );
                // Establecer el padre del cuadrado como el objeto actual
                cuadricula[ cuadricula.Count - 1 ].transform.parent = this.transform;
                // Ajustar la escala del cuadrado
                cuadricula[ cuadricula.Count - 1 ].transform.localScale = new Vector3( escalaCuadrado , escalaCuadrado , escalaCuadrado );

                indiceCuadrados++; // Incrementar el índice de los cuadrados
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
        Vector2 numeroHuecoCasilla = new Vector2( 0.0f , 0.0f );
        bool filaMovida = false;
        distancia.x = rectTransform.rect.width * rectTransform.transform.localScale.x + distanciaCuadrados;
        distancia.y = rectTransform.rect.height * rectTransform.transform.localScale.y + distanciaCuadrados;

        int numeroColumna = 0; // Contador de columnas
        int numeroFila = 0; // Contador de filas

        // Bucle para posicionar cada cuadrado en la cuadrícula
        foreach ( GameObject cuadrado in cuadricula )
        {
            // Si se ha alcanzado el límite de columnas, reiniciar el contador de columnas y aumentar el contador de filas
            bool finColumnas = numeroColumna + 1 > columnas;
            if ( finColumnas )
            {
                numeroFila++;
                numeroColumna = 0;
                numeroHuecoCasilla.x = 0;
                filaMovida = false;
            }

            // Calcular la posición del cuadrado
            var distanciaX = distancia.x * numeroColumna + ( numeroHuecoCasilla.x * huecoCasilla );
            var distanciaY = distancia.y * numeroFila + ( numeroHuecoCasilla.y * huecoCasilla );

            bool llegadoATercerCuadradoX = numeroColumna > 0 && numeroColumna % 3 == 0;
            if ( llegadoATercerCuadradoX )
            {
                numeroHuecoCasilla.x++;
                distanciaX += huecoCasilla;
            }

            bool llegadoATercerCuadradoY = numeroFila > 0 && numeroFila % 3 == 0 && ! filaMovida;
            if ( llegadoATercerCuadradoY )
            {
                filaMovida = true;
                numeroHuecoCasilla.y++;
                distanciaY += huecoCasilla;
            }

            // Establecer la posición del cuadrado
            cuadrado.GetComponent< RectTransform >().anchoredPosition = new Vector2( posicionInicial.x + distanciaX , posicionInicial.y - distanciaY );
            numeroColumna++; // Incrementar el contador de columnas
        }
    }

    // Método para poner números en los cuadrados de la cuadrícula
    void PonerNumerosEnCuadricula ( string nivel )
    {
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
            cuadricula[ indice ].GetComponent< CuadriculaBase >().EstablecerNumeroCorrecto( datos.datosResueltos[ indice ] );
            cuadricula[ indice ].GetComponent< CuadriculaBase >().EstablecerTieneNumeroPredeterminado( datos.datosSinResolver[ indice ] != 0 && datos.datosSinResolver[ indice ] == datos.datosResueltos[ indice ] );
        }
    }

    void OnEnable ()
    {
        EventosJuego.OnCuadradoSeleccionado += OnCuadradoSeleccionado;
    }

    void OnDisable ()
    {
        EventosJuego.OnCuadradoSeleccionado -= OnCuadradoSeleccionado;
    }

    void EstablecerColoresCuadrados ( int[] datos , Color color )
    {
        foreach ( var indice in datos )
        {
            var componente = cuadricula[ indice ].GetComponent< CuadriculaBase >();
            bool noEstaSeleccionado = ! componente.TieneNumeroIncorrecto() && ! componente.EsSeleccionado();
            if ( noEstaSeleccionado )
            {
                componente.EstablecerColor( color );
            }
        }
    }

    public void OnCuadradoSeleccionado ( int indiceCuadrado )
    {
        var lineaHorizontal = IndicadorLinea.Instancia.ObtenerFila( indiceCuadrado );
        var lineaVertical = IndicadorLinea.Instancia.ObtenerColumna( indiceCuadrado );
        var cuadrado = IndicadorLinea.Instancia.ObtenerCuadrado( indiceCuadrado );

        EstablecerColoresCuadrados( IndicadorLinea.Instancia.ObtenerTodosIndicesCuadrados() , Color.white );
        EstablecerColoresCuadrados( lineaHorizontal , colorResaltado );
        EstablecerColoresCuadrados( lineaVertical , colorResaltado );
        EstablecerColoresCuadrados( cuadrado , colorResaltado );
    }
}