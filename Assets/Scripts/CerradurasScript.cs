using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

/**
 * Este script es para ver si la llave que se pone en un candado de un caj�n es correcta. Antoguo 'CandadoScript'.
 */
public class CerradurasScript : MonoBehaviour
{
    public GameObject cerraduraAbre;
    public GameObject canvas;
    public TextMeshProUGUI texto;
    public AudioSource audioSource;
   

    private void OnTriggerEnter(Collider other)
    {
        string nombreCerradura = cerraduraAbre.name;

        string[] partesNombreCerradura = nombreCerradura.Split('_'); 
        string numeroElemento = partesNombreCerradura[2]; 

        string nombreLlave = other.tag; 
        string[] partesNombreLlave = nombreLlave.Split('_'); 
        string numeroLlave = partesNombreLlave[2];

        
        if (numeroLlave == numeroElemento) 
        {
            if (partesNombreCerradura[1] == "Cajon" && partesNombreLlave[1] == "Cajon")
            {
                audioSource.Play();

                XRGrabInteractable xgrab = cerraduraAbre.GetComponent<XRGrabInteractable>();
                xgrab.enabled = true;
                Parametros.cajonesAbiertos[int.Parse(numeroElemento) -1] = true;
                texto.text = partesNombreCerradura[1] + " " + numeroElemento + " abierto";
            }
            if (partesNombreCerradura[1] == "Armario" && partesNombreLlave[1] == "Armario")
            {
                audioSource.Play();

                Parametros.armariosAbiertos[int.Parse(numeroElemento) - 1] = true;
                texto.text = partesNombreCerradura[1] + " " + numeroElemento + " abierto";
            }
            if (partesNombreCerradura[1] == "Puerta" && partesNombreLlave[1] == "Puerta")
            {
                audioSource.Play();

                Parametros.puertasAbiertas[int.Parse(numeroElemento) - 1] = true;
                texto.text = partesNombreCerradura[1] + " " + numeroElemento + " abierta";
               
                if (partesNombreLlave[1] == "Puerta" && partesNombreLlave[2] == "1") //Es la puerta que va de la clase a la habitaci�n y tiene que desaparecer.
                {
                    canvas.SetActive(true);
                    StartCoroutine(DesactivarDespuesDeEspera());
                }
            }
        } else
        {
            if (partesNombreCerradura[1] == "Puerta")
            {
                texto.text = "Esta llave no sirve en esta " + partesNombreCerradura[1].ToLower();

            } else
            {
                texto.text = "Esta llave no sirve en este " + partesNombreCerradura[1].ToLower();
            }
        }
        canvas.SetActive(true);
        Invoke("DesactivarCanvas", 1f);
        
    }

    private void DesactivarCanvas()
    {
        canvas.SetActive(false);      
    }

    IEnumerator DesactivarDespuesDeEspera()
    {
        yield return new WaitForSeconds(2f);
        cerraduraAbre.SetActive(false); //Hace que desaparezca la puerta.
    }

}