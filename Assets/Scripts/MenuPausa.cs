using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuPausa : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;
    
    public void MostrarTiempo ()
    {
        textoTiempo.text = Reloj.instancia.ConseguirTextoReloj().text;
    }
}
