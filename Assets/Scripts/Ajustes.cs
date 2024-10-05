using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que maneja los ajustes del juego
public class Ajustes : MonoBehaviour
{
    // Enumeración que define los niveles de dificultad
    public enum Dificultad
    { 
        NO_ESTABLECIDO , 
        Facil , 
        Medio , 
        Dificil , 
        MuyDificil 
    }

    public static Ajustes Instancia; // Instancia estática de la clase Ajustes

    // Método llamado al despertar el objeto
    void Awake ()
    {
        // Si no hay una instancia, asignar esta instancia y no destruirla al cargar una nueva escena
        if ( Instancia == null )
        {
            DontDestroyOnLoad( this );
            Instancia = this;
        }
        else // Si ya hay una instancia, destruir esta instancia
        {
            Destroy( this );
        }
    }

    Dificultad dificultad; // Variable para almacenar la dificultad actual

    // Método llamado al inicio del juego
    void Start ()
    {
        dificultad = Dificultad.NO_ESTABLECIDO; // Establecer la dificultad inicial como no establecida
    }

    // Método para establecer la dificultad usando la enumeración Dificultad
    public void EstablecerDificultad ( Dificultad dificultadElegida )
    {
        dificultad = dificultadElegida; // Asignar la dificultad elegida
    }

    // Método para establecer la dificultad usando una cadena de texto
    public void EstablecerDificultad ( string dificultadElegida )
    {
        // Asignar la dificultad según la cadena de texto proporcionada
        switch ( dificultadElegida )
        {
            case "Facil":
                dificultad = Dificultad.Facil;
                break;
            case "Medio":
                dificultad = Dificultad.Medio;
                break;
            case "Dificil":
                dificultad = Dificultad.Dificil;
                break;
            case "MuyDificil":
                dificultad = Dificultad.MuyDificil;
                break;
            default:
                dificultad = Dificultad.NO_ESTABLECIDO;
                break;
        }
    }

    // Método para obtener la dificultad actual como una cadena de texto
    public string ObtenerDificultad ()
    {
        // Devolver la dificultad actual como una cadena de texto
        switch ( dificultad )
        {
            case Dificultad.Facil:
                return "Facil";
            case Dificultad.Medio:
                return "Medio";
            case Dificultad.Dificil:
                return "Dificil";
            case Dificultad.MuyDificil:
                return "MuyDificil";
            default:
                return "NO_ESTABLECIDO";
        }
    }
}