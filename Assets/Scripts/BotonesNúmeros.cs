using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BotonesNúmeros : Selectable , IPointerClickHandler , ISubmitHandler , IPointerUpHandler , IPointerExitHandler
{
    [ SerializeField ] int valor; // Número que representa el botón

    void Start ()
    {
        
    }

    void Update ()
    {
        
    }

    public void OnPointerClick ( PointerEventData eventData )
    {
        EventosJuego.MetodoActualizarNumeroCuadrado ( valor );
    }

    public void OnSubmit ( BaseEventData eventData )
    {

    }
}
