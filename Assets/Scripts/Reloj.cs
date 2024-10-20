using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Reloj : MonoBehaviour
{
    int horas = 0;
    int minutos = 0;
    int segundos = 0;
    TextMeshProUGUI textoReloj;
    float tiempoTranscurrido;
    bool relojParado = false;

    public static Reloj instancia;

    void Awake ()
    {
        if ( instancia )
        {
            Destroy( instancia );
        }

        instancia = this;
        textoReloj = GetComponent< TextMeshProUGUI >();

        bool continuarPartida = Ajustes.Instancia.ObtenerContinuarJuegoPrevio();
        if ( continuarPartida )
        {
            tiempoTranscurrido = Config.LeerTiempoJuego();
        }
        else
        {
            tiempoTranscurrido = 0;
        }
    }

    void Start ()
    {
        relojParado = false;
    }

    void Update ()
    {
        bool relojFuncionando = ! Ajustes.Instancia.EstaPausado() && ! relojParado;
        if ( relojFuncionando )
        {
            tiempoTranscurrido += Time.deltaTime;
            TimeSpan tiempo = TimeSpan.FromSeconds( tiempoTranscurrido );
            string hora = FormatearHora( tiempo.Hours );
            string minuto = FormatearHora( tiempo.Minutes );
            string segundo = FormatearHora( tiempo.Seconds );

            textoReloj.text = $"{hora}:{minuto}:{segundo}";
        }
    }

    string FormatearHora ( int tiempo )
    {
        return tiempo.ToString().PadLeft( 2, '0' );
    }

    public void OnGameOver ()
    {
        relojParado = true;
    }

    void OnEnable ()
    {
        EventosJuego.OnGameOver += OnGameOver;
    }

    void OnDisable ()
    {
        EventosJuego.OnGameOver -= OnGameOver;
    }

    public static string ConseguirTiempo ()
    {
        return instancia.tiempoTranscurrido.ToString();
    }

    public TextMeshProUGUI ConseguirTextoReloj ()
    {
        return textoReloj;
    }
}
