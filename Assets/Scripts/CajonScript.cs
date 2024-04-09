using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/**
 * Este script es para decir si un cajón está cerrado o no. Si está cerrado deshabilita la propiedad de grab.
 */
public class CajonScript : MonoBehaviour
{
    public GameObject cajon;
    public GameObject canvas;
    //public TextMeshProUGUI texto;
    private string numeroCajon;
    private string[] partesNombreCajon;
    // Start is called before the first frame update
    void Start()
    {
        string nombreCajon = cajon.name;
        partesNombreCajon = nombreCajon.Split('_');
        numeroCajon = partesNombreCajon[2];

        

        if (partesNombreCajon[1] == "Cajon")
        {
            if (!Parametros.cajonesAbiertos[int.Parse(numeroCajon) - 1])
            {
                Debug.Log("Deshabilitando cajon");
                XRGrabInteractable xgrab = cajon.GetComponent<XRGrabInteractable>();
                xgrab.enabled = false;
            }
        }
        if (partesNombreCajon[1] == "Armario")
        {
            if (!Parametros.armariosAbiertos[int.Parse(numeroCajon) - 1])
            {
                Debug.Log("Deshabilitando cajon");
                XRGrabInteractable xgrab = cajon.GetComponent<XRGrabInteractable>();
                xgrab.enabled = false;
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        ////---Borrar
        //texto.text = Parametros.armariosAbiertos.ToString();
        //canvas.SetActive(true);
        ////---Borrar
        if (partesNombreCajon[1] == "Cajon")
        {
            if (!Parametros.cajonesAbiertos[int.Parse(numeroCajon) - 1])
            {
                canvas.SetActive(true);
            }
        }
        if (partesNombreCajon[1] == "Armario")
        {
            if (!Parametros.armariosAbiertos[int.Parse(numeroCajon) - 1])
            {
                canvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
    }
}
