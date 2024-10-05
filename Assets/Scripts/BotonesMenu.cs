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

    // Método para cargar una escena en modo fácil
    // nombreEscena: Nombre de la escena que se desea cargar
    public void CargarFacil ( string nombreEscena )
    {
        // Establecer la dificultad a fácil
        Ajustes.Instancia.EstablecerDificultad( Ajustes.Dificultad.Facil );
        // Cargar la escena con el nombre proporcionado
        SceneManager.LoadScene( nombreEscena );
    }

    // Método para cargar una escena en modo medio
    // nombreEscena: Nombre de la escena que se desea cargar
    public void CargarMedio ( string nombreEscena )
    {
        // Establecer la dificultad a medio
        Ajustes.Instancia.EstablecerDificultad( Ajustes.Dificultad.Medio );
        // Cargar la escena con el nombre proporcionado
        SceneManager.LoadScene( nombreEscena );
    }

    // Método para cargar una escena en modo difícil
    // nombreEscena: Nombre de la escena que se desea cargar
    public void CargarDificil ( string nombreEscena )
    {
        // Establecer la dificultad a difícil
        Ajustes.Instancia.EstablecerDificultad( Ajustes.Dificultad.Dificil );
        // Cargar la escena con el nombre proporcionado
        SceneManager.LoadScene( nombreEscena );
    }

    // Método para cargar una escena en modo muy difícil
    // nombreEscena: Nombre de la escena que se desea cargar
    public void CargarMuyDificil ( string nombreEscena )
    {
        // Establecer la dificultad a muy difícil
        Ajustes.Instancia.EstablecerDificultad( Ajustes.Dificultad.MuyDificil );
        // Cargar la escena con el nombre proporcionado
        SceneManager.LoadScene( nombreEscena );
    }

    public void ActivarGameObject ( GameObject objeto )
    {
        objeto.SetActive( true );
    }

    public void DesactivarGameObject ( GameObject objeto )
    {
        objeto.SetActive( false );
    }
}