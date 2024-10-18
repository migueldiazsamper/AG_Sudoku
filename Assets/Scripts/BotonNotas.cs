using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BotonNotas : Selectable , IPointerClickHandler
{
    public Sprite onImagen;
    public Sprite offImagen;
    bool activo;

    void Start ()
    {
        activo = false;
    }

    public void OnPointerClick ( PointerEventData eventData )
    {
        activo = ! activo;
        if ( activo )
        {
            GetComponent< Image >().sprite = onImagen;
        }
        else
        {
            GetComponent< Image >().sprite = offImagen;
        }

        EventosJuego.MetodoNotasActivas ( activo );
    }
}
