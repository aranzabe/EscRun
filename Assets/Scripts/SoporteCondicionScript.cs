using System;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/**
 * Este script es para comprobar si cada cubo está correctamente puesto en su soporte.
 */
public class SoporteCondicionScript : MonoBehaviour
{
    public GameObject soporte;
    private string numeroSoporte;
    public TextMeshProUGUI texto;
    private string[] partesNombreBoton;
    public XRBaseInteractor interactor;

    public TextMeshProUGUI textoAuxiliarGeneral;
    private bool zocaloOcupado = false;
    //public XRSocketInteractor socketInteractor;
    //public XRGrabInteractable interactable;


    private void Start()
    {
        string nombreSoporte = soporte.name;
        string[] partesNombre = nombreSoporte.Split('_');
        numeroSoporte = partesNombre[2];
        texto.text = numeroSoporte;

        // Registrar eventos de interacción
        interactor.selectEntered.AddListener(OnSelectEnter);
        interactor.selectExited.AddListener(OnSelectExit);
    }

    private void OnSelectExit(SelectExitEventArgs arg0)
    {
        zocaloOcupado = false;
        texto.text = "Socket vacio";
        //Parametros.enZocalo[int.Parse(numeroSoporte) - 1] = false;
        Parametros.soportesBienColocados[int.Parse(numeroSoporte) - 1] = false;
    }

    private void OnSelectEnter(SelectEnterEventArgs arg0)
    {
        zocaloOcupado =true;
        texto.text = "Socket con objeto";
        Parametros.enZocalo[int.Parse(numeroSoporte) - 1] = true;

    }



    // Start is called before the first frame update
    //void Start()
    //{
    //    string nombreSoporte = soporte.name;
    //    string[] partesNombre = nombreSoporte.Split('_');
    //    numeroSoporte = partesNombre[2];
    //    texto.text = numeroSoporte;


    //    socketInteractor.onSelectEntered.AddListener(ObjetoEnZocalo);
    //    socketInteractor.onSelectExited.AddListener(ObjetoFueraZocalo);
    //}

    //private void OnDestroy()
    //{
    //    // Desuscribirse de los eventos al destruir el objeto
    //    socketInteractor.onSelectEntered.RemoveListener(ObjetoEnZocalo);
    //    socketInteractor.onSelectExited.RemoveListener(ObjetoFueraZocalo);
    //}

    //private void ObjetoEnZocalo(XRBaseInteractable interactable)
    //{
    //    Parametros.enZocalo[int.Parse(numeroSoporte)] = true;
    //}

    //private void ObjetoFueraZocalo(XRBaseInteractable interactable)
    //{
    //    Parametros.enZocalo[int.Parse(numeroSoporte)] = false;
    //}


    private void OnTriggerEnter(Collider other)
    {
        texto.text = texto.text + "Enter: " + other.tag;
        string interruptorNombre = other.tag;
        partesNombreBoton = interruptorNombre.Split('_');
        texto.text = texto.text + " -- " + partesNombreBoton[2];

        if (numeroSoporte == partesNombreBoton[2])
        {
            Parametros.soportesInterruptoresBienColocados[int.Parse(numeroSoporte) - 1] = true;
        }
        else
        {
            Parametros.soportesInterruptoresBienColocados[int.Parse(numeroSoporte) - 1] = false;
        }

        //Si el botón está bien colocado actualizamos el vector correspondiente (lo haremos viendo el número final que es el índice del vector).
        //if (Parametros.enZocalo[int.Parse(partesNombreBoton[2]) - 1])
        //{
        //    Parametros.soportesInterruptoresBienColocados[int.Parse(partesNombreBoton[2]) - 1] = true;
        //    textoAuxiliarGeneral.text += " en pos correcta";
        //}
        //else
        //{
        //    Parametros.soportesInterruptoresBienColocados[int.Parse(partesNombreBoton[2]) - 1] = false;
        //}


    }

    private void OnTriggerExit(Collider other)
    {
        //if (numeroSoporte == partesNombreBoton[2])
        //{
        //    Parametros.soportesInterruptoresBienColocados[int.Parse(numeroSoporte) - 1] = true;
        //}
        //else
        //{
        //    Parametros.soportesInterruptoresBienColocados[int.Parse(numeroSoporte) - 1] = false;
        //}
        //textoAuxiliarGeneral.text = "";
        //textoAuxiliarGeneral.text = partesNombreBoton[0] + partesNombreBoton[1] + partesNombreBoton[2];
        //if (numeroSoporte == partesNombreInterruptor[2])
        //{
        //    XRGrabInteractable xgrab = other.GetComponent<XRGrabInteractable>();

        //    if (xgrab != null)
        //    {
        //        xgrab.enabled = false;
        //    }
        //}
        if (!zocaloOcupado)
        {
            Parametros.soportesInterruptoresBienColocados[int.Parse(partesNombreBoton[2]) - 1] = false;
        }

        mostrarEstado();

        texto.text = "Soportes bien: ";
        for (int i = 0; i < Parametros.soportesInterruptoresBienColocados.Length; i++)
        {
            if (Parametros.soportesInterruptoresBienColocados[i])
            {
                texto.text += "v ";
            }
            else
            {
                texto.text += "f ";
            }
        }
        //texto.text += "    | En zocalo bien: ";
        //for (int i = 0; i < Parametros.enZocalo.Length; i++)
        //{
        //    if (Parametros.enZocalo[i])
        //    {
        //        texto.text += "v ";
        //    }
        //    else
        //    {
        //        texto.text += "f ";
        //    }
        //}
    }

    //[System.Obsolete]
    //void Update()
    //{
    //    if (interactor != null)
    //    {
    //        XRBaseInteractable interactable = interactor.selectTarget; 
    //        if (interactable != null)
    //        {

    //            Parametros.enZocalo[int.Parse(numeroSoporte) - 1] = true;
    //        }
    //        else
    //        {
    //            Parametros.enZocalo[int.Parse(numeroSoporte) - 1] = false;
    //        }
    //    }

    //}


    private void mostrarEstado()
    {
        textoAuxiliarGeneral.text = "Soportes bien colocados: ";
        for (int i = 0; i < Parametros.soportesInterruptoresBienColocados.Length; i++)
        {
            if (Parametros.soportesInterruptoresBienColocados[i])
            {
                textoAuxiliarGeneral.text += "v ";
            }
            else
            {
                textoAuxiliarGeneral.text += "f ";
            }
        }
        textoAuxiliarGeneral.text += "En zocalo: ";
        for (int i = 0; i < Parametros.enZocalo.Length; i++)
        {
            if (Parametros.enZocalo[i])
            {
                textoAuxiliarGeneral.text += "v ";
            }
            else
            {
                textoAuxiliarGeneral.text += "f ";
            }
        }
        textoAuxiliarGeneral.text += "Pulsados: ";
        for (int i = 0; i < Parametros.botonCondicionPulsado.Length; i++)
        {
            if (Parametros.botonCondicionPulsado[i])
            {
                textoAuxiliarGeneral.text += "v ";
            }
            else
            {
                textoAuxiliarGeneral.text += "f ";
            }
        }
        textoAuxiliarGeneral.text += "Respuesta correcta: ";
        for (int i = 0; i < Parametros.solucionEnigmaCondiciones.Length; i++)
        {
            if (Parametros.solucionEnigmaCondiciones[i])
            {
                textoAuxiliarGeneral.text += "v ";
            }
            else
            {
                textoAuxiliarGeneral.text += "f ";
            }
        }
    }
}
