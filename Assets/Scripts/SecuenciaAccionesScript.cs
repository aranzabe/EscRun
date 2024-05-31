using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecuenciaAccionesScript : MonoBehaviour
{
    public TextMeshProUGUI textoAuxiliarGeneral;

    private AudioSource sound;
    public GameObject indicadorColor;
    private Renderer meshRenderer;
    public Material normalMaterial;
    public Material pressedMaterial;
    public GameObject colliderBoton;

    private string etiquetaBoton;
    private string[] partesNombreBoton;

    private void Start()
    {
        etiquetaBoton = colliderBoton.gameObject.tag;
        partesNombreBoton = etiquetaBoton.Split('_');
        meshRenderer = indicadorColor.GetComponent<Renderer>();
        sound = colliderBoton.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collider_Interruptor_Panel")
        {
            textoAuxiliarGeneral.text = "Entrando en triger " + partesNombreBoton[0] + " " + partesNombreBoton[1] + " " + partesNombreBoton[2];
            sound.Play();
            if (partesNombreBoton[1] == "Secuencial")
            {
                Parametros.ejecucionAcciones[int.Parse(partesNombreBoton[2]) - 1] = 0;
            }
            if (partesNombreBoton[1] == "Bucle")
            {
                Parametros.ejecucionAcciones[int.Parse(partesNombreBoton[2]) - 1] = 1;
            }
            meshRenderer.material = pressedMaterial;
            mostrarEstado();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Collider_Interruptor_Panel")
        {
            textoAuxiliarGeneral.text = "Saliendo triger";
            Parametros.ejecucionAcciones[int.Parse(partesNombreBoton[2]) - 1] = 2;
            meshRenderer.material = normalMaterial;
            mostrarEstado();
        }
    }

    private void mostrarEstado()
    {
        textoAuxiliarGeneral.text += "";
        for (int i = 0; i < Parametros.ejecucionAcciones.Length; i++)
        {
            textoAuxiliarGeneral.text += "[" + i + "]= " + Parametros.ejecucionAcciones[i] + " ";
        }
    }
}
