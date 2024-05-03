using System;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/**
 * Este script es para comprobar si cada cubo está correctamente puesto en su soporte.
 */
public class SoporteDatosScript : MonoBehaviour
{
    public GameObject soporte;
    private string numeroSoporte;
    public TextMeshProUGUI texto;
    public XRBaseInteractor interactor;

    // Start is called before the first frame update
    void Start()
    {
        string nombreSoporte = soporte.name;
        string[] partesNombreCajon = nombreSoporte.Split('_');
        numeroSoporte = partesNombreCajon[2];
        texto.text = numeroSoporte;

        // Registrar eventos de interacción
        interactor.selectEntered.AddListener(OnSelectEnter);
        interactor.selectExited.AddListener(OnSelectExit);
    }


    private void OnSelectExit(SelectExitEventArgs arg0)
    {
        Parametros.soportesBienColocados[int.Parse(numeroSoporte)] = false;
    }

    [Obsolete]
    private void OnSelectEnter(SelectEnterEventArgs arg0)
    {
        //texto.text = texto.text + "Enter: ";
        string cuboNombre = arg0.interactable.gameObject.tag;
        string[] partesNombreCubo = cuboNombre.Split('_');
        //texto.text = texto.text + " -- " + partesNombreCubo[2];
        if (numeroSoporte == partesNombreCubo[2])
        {
            Parametros.soportesBienColocados[int.Parse(numeroSoporte)] = true;
        }
        else
        {
            Parametros.soportesBienColocados[int.Parse(numeroSoporte)] = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        ////texto.text = texto.text + "Enter: ";
        //string cuboNombre = other.tag;
        //string[] partesNombreCubo = cuboNombre.Split('_');
        ////texto.text = texto.text + " -- " + partesNombreCubo[2];
        //if (numeroSoporte == partesNombreCubo[2])
        //{
        //    Parametros.soportesBienColocados[int.Parse(numeroSoporte)] = true;
        //}
        //else
        //{
        //    Parametros.soportesBienColocados[int.Parse(numeroSoporte)] = false;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //texto.text = "Exit";
    }
}
