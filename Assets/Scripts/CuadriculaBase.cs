using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Clase que representa un cuadrado base en la cuadrícula de Sudoku
public class CuadriculaBase : Selectable , IPointerClickHandler , ISubmitHandler , IPointerUpHandler , IPointerExitHandler
{
    // Variable serializada para configurar el texto del número desde el editor de Unity
    public GameObject textoNumero;
    int numero = 0; // Número que se mostrará en el cuadrado
    bool seleccionado = false; // Indica si el cuadrado está seleccionado
    int indiceCuadrado = -1; // Índice del cuadrado en la cuadrícula
    int numeroCorrecto = 0; // Número correcto que debe tener el cuadrado
    bool tieneNumeroPredeterminado = false; // Indica si el cuadrado tiene un número predeterminado
    bool tieneNumeroIncorrecto = false; // Indica si el cuadrado tiene un número incorrecto

    public int ObtenerNumero () // Método para obtener el número del cuadrado
    {
        return numero;
    }

    public bool TieneNumeroCorrecto () // Método para obtener si el cuadrado tiene un número correcto
    {
        return numero == numeroCorrecto;
    }

    public bool TieneNumeroIncorrecto () // Método para obtener el valor de la variable tieneNumeroIncorrecto
    {
        return tieneNumeroIncorrecto;
    }

    public void EstablecerTieneNumeroPredeterminado ( bool tieneNumero ) // Método para asignar si el cuadrado tiene un número predeterminado
    {
        tieneNumeroPredeterminado = tieneNumero;
    }

    public bool TieneNumeroPredeterminado () // Método para obtener el valor de la variable tieneNumeroPredeterminado
    {
        return tieneNumeroPredeterminado;
    }

    public bool EsSeleccionado () // Método para obtener el valor de la variable seleccionado
    {
        return seleccionado;
    }

    public void EstablecerIndiceCuadrado ( int indice ) // Método para asignar el índice del cuadrado
    {
        indiceCuadrado = indice;
    }

    public void EstablecerNumeroCorrecto ( int numeroPasado ) // Método para asignar el número correcto al cuadrado
    {
        numeroCorrecto = numeroPasado;
        tieneNumeroIncorrecto = false;

        bool numeroIncorrecto = numero != 0 && numero != numeroCorrecto;
        if ( numeroIncorrecto )
        {
            tieneNumeroIncorrecto = true;
            EstablecerColor( Color.red );
        }
    }

    public void EstablecerNumeroCorrecto () // Método para asignar el número correcto al cuadrado
    {
        numero = numeroCorrecto;
        MostrarTexto();
    }

    void Start ()
    {
        seleccionado = false; // Inicializar la variable seleccionado en falso
    }

    // Método para mostrar el texto del número en el cuadrado
    public void MostrarTexto ()
    {
        // Si el número es menor o igual a 0, mostrar un espacio en blanco
        if ( numero <= 0 )
        {
            textoNumero.GetComponent< TextMeshProUGUI >().text = " ";
        }
        else // Si el número es mayor a 0, mostrar el número
        {
            textoNumero.GetComponent< TextMeshProUGUI >().text = numero.ToString();
        }
    }

    // Método para asignar un número al cuadrado y mostrarlo
    public void PonerNumero ( int numeroDado )
    {
        numero = numeroDado; // Asignar el número dado
        MostrarTexto(); // Mostrar el número en el cuadrado
    }

    public void OnPointerClick ( PointerEventData eventData )
    {
        seleccionado = true;
        EventosJuego.MetodoCuadradoSeleccionado( indiceCuadrado );
    }

    public void OnSubmit ( BaseEventData eventData )
    {

    }

    void OnEnable ()
    {
        EventosJuego.OnActualizarNumeroCuadrado += OnEstablecerNumero;
        EventosJuego.OnCuadradoSeleccionado += OnSeleccionarCuadrado;
        EventosJuego.OnBorrarNumero += OnBorrarNumero;
    }

    void OnDisable ()
    {
        EventosJuego.OnActualizarNumeroCuadrado -= OnEstablecerNumero;
        EventosJuego.OnCuadradoSeleccionado -= OnSeleccionarCuadrado;
        EventosJuego.OnBorrarNumero -= OnBorrarNumero;
    }

    public void OnBorrarNumero ()
    {
        if ( seleccionado && ! tieneNumeroPredeterminado )
        {
            numero = 0;
            tieneNumeroIncorrecto = false;
            EstablecerColor( Color.white );
            MostrarTexto();
        }
    }

    public void OnEstablecerNumero ( int numero )
    {
        if ( seleccionado && ! tieneNumeroPredeterminado )
        {
            PonerNumero( numero );

            bool noEsCorrecto = numero != numeroCorrecto; // Verificar si el número es incorrecto
            if ( noEsCorrecto )
            {
                tieneNumeroIncorrecto = true;
                var colores = this.colors;
                colores.normalColor = Color.red;
                this.colors = colores;

                EventosJuego.MetodoNumeroIncorrecto(); // Llamar al evento de número incorrecto
            }
            else
            {
                tieneNumeroIncorrecto = false;
                tieneNumeroPredeterminado = true;
                var colores = this.colors;
                colores.normalColor = Color.white;
                this.colors = colores;
            }
        }
    }

    public void OnSeleccionarCuadrado ( int indice )
    {
        if ( indice == indiceCuadrado )
        {
            seleccionado = true;
        }
        else
        {
            seleccionado = false;
        }
    }

    public void EstablecerColor ( Color color )
    {
        var colores = this.colors;
        colores.normalColor = color;
        this.colors = colores;
    }
}