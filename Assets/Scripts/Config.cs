using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class Config : MonoBehaviour
{
    #if UNITY_ANDROID && ! UNITY_EDITOR
        static string dir = Application.persistentDataPath;
    #else
        static string dir = Directory.GetCurrentDirectory();
    #endif

    static string file = @"\board_data.ini";
    static string path = dir + file;

    public static void EliminarDatosArchivo ()
    {
        File.Delete( path );
    }

    public static void GuardarDatosTablero ( DatosSudoku.DatosSudokuTabla datosTablero , string nivel , int indiceTablero , int numeroError )
    {
        File.WriteAllText( path , string.Empty );
        StreamWriter writer = new StreamWriter( path , false );
        string tiempoActual = "#tiempo:" + Reloj.ConseguirTiempo();
        string nivelTexto = "#nivel:" + nivel;
        string erroresNumerosTexto = "#errores:" + numeroError;
        string indiceTableroTexto = "#indiceTablero:" + indiceTablero.ToString();
        string stringSinResolver = "#sinResolver:";
        string stringResuelto = "#resuelto:";

        foreach ( var datosSinResolver in datosTablero.datosSinResolver )
        {
            stringSinResolver += datosSinResolver.ToString() + ",";
        }

        foreach ( var datosResueltos in datosTablero.datosResueltos )
        {
            stringResuelto += datosResueltos.ToString() + ",";
        }

        writer.WriteLine( tiempoActual );
        writer.WriteLine( nivelTexto );
        writer.WriteLine( erroresNumerosTexto );
        writer.WriteLine( indiceTableroTexto );
        writer.WriteLine( stringSinResolver );
        writer.WriteLine( stringResuelto );
        writer.Close();
    }

    public static string LeerNivelTablero ()
    {
        string linea;
        string nivel = "";
        StreamReader archivo = new StreamReader( path );

        bool encontradaLinea = ( linea = archivo.ReadLine() ) != null;
        while ( encontradaLinea )
        {
            string[] palabra = linea.Split( ':' );
            bool palabraEsNivel = palabra[0] == "#nivel";
            if ( palabraEsNivel )
            {
                nivel = palabra[1];
            }
        }

        archivo.Close();
        return nivel;
    }

    public static DatosSudoku.DatosSudokuTabla LeerDatosTablero ()
    {
        string linea;
        StreamReader archivo = new StreamReader( path );

        int[] datosSinResolver = new int[ 81 ];
        int[] datosResueltos = new int[ 81 ];

        int indiceDatosSinResolver = 0;
        int indiceDatosResueltos = 0;

        bool encontradaLinea = ( linea = archivo.ReadLine() ) != null;
        while ( encontradaLinea )
        {
            string[] palabra = linea.Split( ':' );
            bool palabraEsSinResolver = palabra[ 0 ] == "#sinResolver";
            if ( palabraEsSinResolver )
            {
                string[] subpalabras = Regex.Split( palabra[1] , "," );
                foreach ( var valor in subpalabras )
                {
                    int numeroCuadrado = -1;
                    bool consigoLeer = int.TryParse( valor , out numeroCuadrado );
                    if ( consigoLeer )
                    {
                        datosSinResolver[ indiceDatosSinResolver ] = numeroCuadrado;
                        indiceDatosSinResolver++;
                    }
                }
            }

            bool palabraEsResuelto = palabra[ 0 ] == "#resuelto";
            if ( palabraEsResuelto )
            {
                string[] subpalabras = Regex.Split( palabra[1] , "," );
                foreach ( var valor in subpalabras )
                {
                    int numeroCuadrado = -1;
                    bool consigoLeer = int.TryParse( valor , out numeroCuadrado );
                    if ( consigoLeer )
                    {
                        datosResueltos[ indiceDatosResueltos ] = numeroCuadrado;
                        indiceDatosResueltos++;
                    }
                }
            }
        }

        archivo.Close();
        return new DatosSudoku.DatosSudokuTabla( datosSinResolver , datosResueltos );
    }

    public static int LeerIndiceTablero ()
    {
        int nivel = -1;
        string linea;
        StreamReader archivo = new StreamReader( path );

        bool encontradaLinea = ( linea = archivo.ReadLine() ) != null;
        while ( encontradaLinea )
        {
            string[] palabra = linea.Split( ':' );
            bool palabraEsNivel = palabra[0] == "#indiceTablero";
            if ( palabraEsNivel )
            {
                int.TryParse( palabra[1] , out nivel );
            }
        }

        archivo.Close();
        return nivel;
    }

    public static float LeerTiempoJuego ()
    {
        float tiempo = -1.0f;
        string linea;

        StringReader archivo = new StringReader( path );

        bool encontradaLinea = ( linea = archivo.ReadLine() ) != null;
        while ( encontradaLinea )
        {
            string[] palabra = linea.Split( ':' );
            bool palabraEsNivel = palabra[0] == "#tiempo";
            if ( palabraEsNivel )
            {
                float.TryParse( palabra[1] , out tiempo );
            }
        }

        archivo.Close();
        return tiempo;
    }

    public static int LeerNumeroErrores ()
    {
        int numeroErrores = 0;
        string linea;
        StringReader archivo = new StringReader( path );

        bool encontradaLinea = ( linea = archivo.ReadLine() ) != null;
        while ( encontradaLinea )
        {
            string[] palabra = linea.Split( ':' );
            bool palabraEsNivel = palabra[0] == "#errores";
            if ( palabraEsNivel )
            {
                int.TryParse( palabra[1] , out numeroErrores );
            }
        }

        archivo.Close();
        return numeroErrores;
    }

    public static bool ExisteArchivo ()
    {
        return File.Exists( path );
    }
}
