using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BotonEncenderAparatos : MonoBehaviour
{
    public TextMeshProUGUI texto;
    private string tagGa;
    private string[] partesNombreBoton;
    //public TextMeshProUGUI textoAuxiliarGeneral;

    private AudioSource sound;

    //Para el cambio de color.
    private Renderer meshRenderer;
    public Material normalMaterial;
    public Material pressedMaterial;
    public GameObject boton;
    public GameObject aparatoAActivar;
    public GameObject imagenProyector;


    private void Start()
    {
        //textoAuxiliarGeneral.text = "";
        tagGa = gameObject.tag;
        partesNombreBoton = tagGa.Split('_');

        meshRenderer = boton.GetComponent<Renderer>();
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        sound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        //Cambiamos el material al pulsar (pulsado o no).
        Parametros.aparatosEncendidos[int.Parse(partesNombreBoton[2]) - 1] = !Parametros.aparatosEncendidos[int.Parse(partesNombreBoton[2]) - 1];

        if (!Parametros.aparatosEncendidos[int.Parse(partesNombreBoton[2]) - 1])
        {
            meshRenderer.material = normalMaterial;
            if (this.aparatoAActivar != null)
            {
                this.aparatoAActivar.SetActive(false);
            }
            imagenProyector.SetActive(false);
        }
        else
        {
            meshRenderer.material = pressedMaterial;
            if (this.aparatoAActivar != null)
            {
                this.aparatoAActivar.SetActive(true);
            }
            imagenProyector.SetActive(true);
        }
        
    }
}
