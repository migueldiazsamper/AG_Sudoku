using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Clase que representa un cuadrado base en la cuadrícula de Sudoku
public class CuadriculaBase : Selectable
{
    // Variable serializada para configurar el texto del número desde el editor de Unity
    [ SerializeField ] TextMeshProUGUI textoNumero;
    int numero = 0; // Número que se mostrará en el cuadrado

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
}