using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Clase que representa un cuadrado base en la cuadrícula de Sudoku
public class CuadriculaBase : Selectable , IPointerClickHandler , ISubmitHandler , IPointerUpHandler , IPointerExitHandler
{
    // Variable serializada para configurar el texto del número desde el editor de Unity
    [ SerializeField ] GameObject textoNumero;
    public List< GameObject > notasDeLosNumeros; // Índices de los cuadrados incorrectos en la cuadrícula
    int numero = 0; // Número que se mostrará en el cuadrado
    bool seleccionado = false; // Indica si el cuadrado está seleccionado
    int indiceCuadrado = -1; // Índice del cuadrado en la cuadrícula
    int numeroCorrecto = 0; // Número correcto que debe tener el cuadrado
    bool tieneNumeroPredeterminado = false; // Indica si el cuadrado tiene un número predeterminado
    bool tieneNumeroIncorrecto = false; // Indica si el cuadrado tiene un número incorrecto
    bool notaActiva;

    public bool TieneNumeroIncorrecto () // Método para obtener el valor de la variable tieneNumeroIncorrecto
    {
        return tieneNumeroIncorrecto;
    }

    public void EstablecerTieneNumeroPredeterminado ( bool tieneNumero ) // Método para asignar si el cuadrado tiene un número predeterminado
    {
        tieneNumeroPredeterminado = tieneNumero;
    }

    public bool TieneNumeroPredeterminado () // Método para obtener el valor de la variable tieneNumeroPredeterminado
    {
        return tieneNumeroPredeterminado;
    }

    public bool EsSeleccionado () // Método para obtener el valor de la variable seleccionado
    {
        return seleccionado;
    }

    public void EstablecerIndiceCuadrado ( int indice ) // Método para asignar el índice del cuadrado
    {
        indiceCuadrado = indice;
    }

    public void EstablecerNumeroCorrecto ( int numero ) // Método para asignar el número correcto al cuadrado
    {
        numeroCorrecto = numero;
        tieneNumeroIncorrecto = false;
    }

    void Start ()
    {
        seleccionado = false; // Inicializar la variable seleccionado en falso
        notaActiva = false;

        EstablecerValorNumeroNotas( 0 );
    }

    public List< string > ObtenerNotaCuadrado ()
    {
        List< string > notas = new List< string >();
        foreach ( var numero in notasDeLosNumeros )
        {
            notas.Add( numero.GetComponent< TextMeshProUGUI >().text );
        }

        return notas;
    }

    void EstablecerNotasCuadradoVacias ()
    {
        foreach ( var numero in notasDeLosNumeros )
        {
            bool tieneQueEstarVacio = numero.GetComponent< TextMeshProUGUI >().text == "0";
            if ( tieneQueEstarVacio )
            {
                numero.GetComponent< TextMeshProUGUI >().text = " "; 
            }
        }
    }

    void EstablecerValorNumeroNotas ( int valor )
    {
        foreach ( var numero in notasDeLosNumeros )
        {
            bool tieneQueEstarVacio = valor <= 0;
            if ( tieneQueEstarVacio )
            {
                numero.GetComponent< TextMeshProUGUI >().text = " ";
            }
            else
            {
                numero.GetComponent< TextMeshProUGUI >().text = valor.ToString();
            }
        }
    }

    void EstablecerNotaNumeroConcreto ( int valor , bool forzarActualizacion = false )
    {
        if ( ! notaActiva || ! forzarActualizacion )
        {
            return;
        }

        bool tieneQueEstarVacio = valor <= 0;
        if ( tieneQueEstarVacio )
        {
            notasDeLosNumeros[ valor - 1 ].GetComponent< TextMeshProUGUI >().text = " ";
        }
        else
        {
            bool tieneNumero = notasDeLosNumeros[ valor - 1 ].GetComponent< TextMeshProUGUI >().text != " " || forzarActualizacion;
            if ( tieneNumero )
            {
                notasDeLosNumeros[ valor - 1 ].GetComponent< TextMeshProUGUI >().text = valor.ToString();
            }
            else
            {
                notasDeLosNumeros[ valor - 1 ].GetComponent< TextMeshProUGUI >().text = " ";
            }
        }
    }

    public void EstablecerNotasCuadricula ( List< int > notas )
    {
        foreach ( var nota in notas )
        {
            EstablecerNotaNumeroConcreto( nota , true );
        }
    }

    public void OnNotasActivas ( bool activar )
    {
        notaActiva = activar;
    }

    // Método para mostrar el texto del número en el cuadrado
    public void MostrarTexto ()
    {
        // Si el número es menor o igual a 0, mostrar un espacio en blanco
        if ( numero <= 0 )
        {
            textoNumero.GetComponent< TextMeshProUGUI >().text = " ";
        }
        else // Si el número es mayor a 0, mostrar el número
        {
            textoNumero.GetComponent< TextMeshProUGUI >().text = numero.ToString();
        }
    }

    // Método para asignar un número al cuadrado y mostrarlo
    public void PonerNumero ( int numeroDado )
    {
        numero = numeroDado; // Asignar el número dado
        MostrarTexto(); // Mostrar el número en el cuadrado
    }

    public void OnPointerClick ( PointerEventData eventData )
    {
        seleccionado = true;
        EventosJuego.MetodoCuadradoSeleccionado( indiceCuadrado );
    }

    public void OnSubmit ( BaseEventData eventData )
    {

    }

    void OnEnable ()
    {
        EventosJuego.OnActualizarNumeroCuadrado += OnEstablecerNumero;
        EventosJuego.OnCuadradoSeleccionado += OnSeleccionarCuadrado;
        EventosJuego.OnNotasActivas += OnNotasActivas;
    }

    void OnDisable ()
    {
        EventosJuego.OnActualizarNumeroCuadrado -= OnEstablecerNumero;
        EventosJuego.OnCuadradoSeleccionado -= OnSeleccionarCuadrado;
        EventosJuego.OnNotasActivas -= OnNotasActivas;
    }

    public void OnEstablecerNumero ( int numero )
    {
        if ( seleccionado && ! tieneNumeroPredeterminado )
        {
            bool hayQuePonerNota = notaActiva && ! tieneNumeroIncorrecto;
            if ( hayQuePonerNota )
            {
                EstablecerNotaNumeroConcreto( numero );
            }
            else if ( ! notaActiva )
            {
                PonerNumero( numero );

                bool noEsCorrecto = numero != numeroCorrecto; // Verificar si el número es incorrecto
                if ( noEsCorrecto )
                {
                    tieneNumeroIncorrecto = true;
                    var colores = this.colors;
                    colores.normalColor = Color.red;
                    this.colors = colores;

                    EventosJuego.MetodoNumeroIncorrecto(); // Llamar al evento de número incorrecto
                }
                else
                {
                    tieneNumeroIncorrecto = false;
                    tieneNumeroPredeterminado = true;
                    var colores = this.colors;
                    colores.normalColor = Color.white;
                    this.colors = colores;
                }
            }
        }
    }

    public void OnSeleccionarCuadrado ( int indice )
    {
        if ( indice == indiceCuadrado )
        {
            seleccionado = true;
        }
        else
        {
            seleccionado = false;
        }
    }

    public void EstablecerColor ( Color color )
    {
        var colores = this.colors;
        colores.normalColor = color;
        this.colors = colores;
    }
}