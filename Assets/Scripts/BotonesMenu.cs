using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase que maneja los botones del menú
public class BotonesMenu : MonoBehaviour
{
    // Método para cargar una escena específica
    // nombreEscena: Nombre de la escena que se desea cargar
    public void CargarEscena ( string nombreEscena )
    {
        // Cargar la escena con el nombre proporcionado
        SceneManager.LoadScene( nombreEscena );
    }
}