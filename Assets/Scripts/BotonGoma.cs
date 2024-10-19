using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BotonGoma : Selectable , IPointerClickHandler
{
    public void OnPointerClick ( PointerEventData eventData )
    {
        EventosJuego.MetodoBorrarNumero();
    }
}
