using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuGameOver : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;

    void Start ()
    {
        textoTiempo.text = Reloj.instancia.ConseguirTextoReloj().text;
    }
}
