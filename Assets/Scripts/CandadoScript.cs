using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class CandadoScript : MonoBehaviour
{
    public GameObject cajonAbre;
    public GameObject canvas;
    public TextMeshProUGUI texto;

   

    private void OnTriggerEnter(Collider other)
    {
        string nombreCajon = cajonAbre.name;

        string[] partesNombreCajon = nombreCajon.Split('_'); 
        string numeroCajon = partesNombreCajon[1]; 

        string nombreLlave = other.tag; 
        string[] partesNombreLlave = nombreLlave.Split('_'); 
        string numeroLlave = partesNombreLlave[2];

        
        if (numeroLlave == numeroCajon && partesNombreLlave[1] == "Cajon") 
        {

            Debug.Log("Cajón " + numeroCajon + " abierto");

            XRGrabInteractable xgrab = cajonAbre.GetComponent<XRGrabInteractable>();
            xgrab.enabled = true;

            Parametros.cajonesAbiertos[int.Parse(numeroCajon) -1] = true;
            texto.text = "Cajón " + numeroCajon + " abierto";
        } else
        {
            texto.text = "Esta llave no abre este cajón";
        }
        canvas.SetActive(true);
        Invoke("DesactivarCanvas", 1f);
    }

    private void DesactivarCanvas()
    {
        canvas.SetActive(false);
    }
}
