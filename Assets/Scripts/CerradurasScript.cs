using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

/**
 * Este script es para ver si la llave que se pone en un candado de un cajón es correcta. Antoguo 'CandadoScript'.
 */
public class CerradurasScript : MonoBehaviour
{
    public GameObject cerraduraAbre;
    public GameObject canvas;
    public TextMeshProUGUI texto;
    public AudioSource audioSource;

    //Estos son los objetos ocultos hasta que se abre el cajón 1.
    public GameObject tarjetaCajon1;
    public GameObject cuboByteCajon1;

    public GameObject memoriaRAMCajon4;
    public GameObject llaveCajon4;
    public GameObject botonCajon4;
   

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
                texto.text = partesNombreCerradura[1] + " abierto";
                if (int.Parse(numeroElemento) == 1)
                {
                    tarjetaCajon1.SetActive(true);
                    cuboByteCajon1.SetActive(true);
                }
                if (int.Parse(numeroElemento) == 4)
                {
                    memoriaRAMCajon4.SetActive(true);
                    llaveCajon4.SetActive(true);
                    botonCajon4.SetActive(true); 
                }
            }
            if (partesNombreCerradura[1] == "Armario" && partesNombreLlave[1] == "Armario")
            {
                audioSource.Play();

                Parametros.armariosAbiertos[int.Parse(numeroElemento) - 1] = true;
                texto.text = partesNombreCerradura[1] + " abierto";
            }
            if (partesNombreCerradura[1] == "Puerta" && partesNombreLlave[1] == "Puerta")
            {
                
                texto.text = partesNombreCerradura[1] + " abierta";
               
                if (partesNombreLlave[1] == "Puerta" && partesNombreLlave[2] == "1") //Es la puerta que va de la clase a la habitación y tiene que desaparecer.
                {
                    Parametros.puertasAbiertas[int.Parse(numeroElemento) - 1] = true;
                    audioSource.Play();
                    canvas.SetActive(true);
                    StartCoroutine(DesactivarDespuesDeEspera());
                }
                if (partesNombreLlave[1] == "Puerta" && partesNombreLlave[2] == "2" && !Parametros.puertasAbiertas[1]) //Es la puerta que va de la clase a la habitación al cuarto de estar y tiene que moverse.
                {
                    Parametros.puertasAbiertas[int.Parse(numeroElemento) - 1] = true;
                    audioSource.Play();
                    canvas.SetActive(true);
                    StartCoroutine(RotarDespuesDeEspera());
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
        GameObject lucesClase = GameObject.Find("LucesClase");
        GameObject sustoPuerta1 = GameObject.Find("SustoPuerta1");
        // Verificar si se encontró el objeto
        if (lucesClase != null)
        {
            lucesClase.SetActive(false);
            
        }
        cerraduraAbre.SetActive(false); //Hace que desaparezca la puerta.
        AudioSource sound = sustoPuerta1.GetComponent<AudioSource>();
        sound.Play();
    }

    IEnumerator RotarDespuesDeEspera()
    {
        yield return new WaitForSeconds(2f);
        GameObject sustoPuerta2 = GameObject.Find("SustoPuerta2");
        AudioSource sound = sustoPuerta2.GetComponent<AudioSource>();
        cerraduraAbre.transform.Rotate(Vector3.down, 90f, Space.Self);
        Parametros.puerta2HabitacionCuartoAbierta = true;
        //Hace que rote la puerta.
    }
}
