using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Victoria : MonoBehaviour
{
    public GameObject victoriaPopPup;
    public TextMeshProUGUI textoReloj; 

    void Start ()
    {
        victoriaPopPup.SetActive( false );
    }

    void MetodoTableroCompletado ()
    {
        victoriaPopPup.SetActive( true );
        textoReloj.text = Reloj.instancia.ConseguirTextoReloj().text;
    }

    void OnEnable ()
    {
        EventosJuego.OnTableroCompletado += MetodoTableroCompletado;
    }

    void OnDisable ()
    {
        EventosJuego.OnTableroCompletado -= MetodoTableroCompletado;
    }
}
