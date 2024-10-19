using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
        string tiempoActual = "#tiempo:" + Reloj.ConseguirTextoReloj();
        string nivelTexto = "#nivel:" + nivel;
        string erroresNumerosTexto = "#errores:" + numeroError;
        string indiceTableroTexto = "#indiceTablero:" + indiceTablero.ToString();
        string stringSinResolver = "#sinResolver";
        string stringResuelto = "#resuelto";

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
}
