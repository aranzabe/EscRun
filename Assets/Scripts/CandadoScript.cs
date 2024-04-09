using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

/**
 * Este script es para ver si la llave que se pone en un candado de un cajón es correcta.
 */
public class CandadoScript : MonoBehaviour
{
    public GameObject cajonAbre;
    public GameObject canvas;
    public TextMeshProUGUI texto;
    public AudioSource audioSource;
   

    private void OnTriggerEnter(Collider other)
    {
        string nombreCajon = cajonAbre.name;

        string[] partesNombreCajon = nombreCajon.Split('_'); 
        string numeroCajon = partesNombreCajon[2]; 

        string nombreLlave = other.tag; 
        string[] partesNombreLlave = nombreLlave.Split('_'); 
        string numeroLlave = partesNombreLlave[2];

        
        if (numeroLlave == numeroCajon) 
        {
            audioSource.Play();

            XRGrabInteractable xgrab = cajonAbre.GetComponent<XRGrabInteractable>();
            xgrab.enabled = true;
            if (partesNombreCajon[1] == "Cajon")
            {
                Parametros.cajonesAbiertos[int.Parse(numeroCajon) -1] = true;
            }
            if (partesNombreCajon[1] == "Armario")
            {
                Parametros.armariosAbiertos[int.Parse(numeroCajon) - 1] = true;
            }

            texto.text = partesNombreCajon[1] +  " " + numeroCajon + " abierto";
        } else
        {
            texto.text = "Esta llave no abre este " + partesNombreCajon[1].ToLower();
        }
        canvas.SetActive(true);
        Invoke("DesactivarCanvas", 1f);
    }

    private void DesactivarCanvas()
    {
        canvas.SetActive(false);
    }
}
