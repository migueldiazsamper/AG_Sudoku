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
    [ SerializeField ] TextMeshProUGUI textoNumero;
    int numero = 0; // Número que se mostrará en el cuadrado
    bool seleccionado = false; // Indica si el cuadrado está seleccionado
    int indiceCuadrado = -1; // Índice del cuadrado en la cuadrícula

    public bool EsSeleccionado () // Método para obtener el valor de la variable seleccionado
    {
        return seleccionado;
    }

    public void EstablecerIndiceCuadrado ( int indice ) // Método para asignar el índice del cuadrado
    {
        indiceCuadrado = indice;
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
    }

    void OnDisable ()
    {
        EventosJuego.OnActualizarNumeroCuadrado -= OnEstablecerNumero;
        EventosJuego.OnCuadradoSeleccionado -= OnSeleccionarCuadrado;
    }

    public void OnEstablecerNumero ( int numero )
    {
        if ( seleccionado )
        {
            PonerNumero( numero );
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
}