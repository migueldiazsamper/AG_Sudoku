using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BotonContinuar : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI textoNivel;

    string PrimerCero(int numero)
    {
        return numero.ToString().PadLeft(2, '0');
    }

    void Start()
    {
        bool noExisteArchivo = !Config.ExisteArchivo();
        if (noExisteArchivo)
        {
            gameObject.GetComponent<Button>().interactable = false;
            textoTiempo.text = " ";
            textoNivel.text = " ";
        }
        else
        {
            float tiempoTranscurrido = Config.LeerTiempoJuego();
            TimeSpan span = TimeSpan.FromSeconds(tiempoTranscurrido);

            string horas = PrimerCero(span.Hours);
            string minutos = PrimerCero(span.Minutes);
            string segundos = PrimerCero(span.Seconds);

            textoTiempo.text = horas + ":" + minutos + ":" + segundos;
            textoNivel.text = Config.LeerNivelTablero();
        }
    }

    public void EstablecerDatosJuego ()
    {
        Ajustes.Instancia.EstablecerDificultad( Config.LeerNivelTablero() );
    }
}