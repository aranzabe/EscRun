using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CajonScript : MonoBehaviour
{
    public GameObject cajon;
    public GameObject texto;
    private string numeroCajon;

    // Start is called before the first frame update
    void Start()
    {
        string nombreCajon = cajon.name;
        string[] partesNombreCajon = nombreCajon.Split('_');
        numeroCajon = partesNombreCajon[1];

        if (!Parametros.cajonesAbiertos[int.Parse(numeroCajon) - 1])
        {
            Debug.Log("Deshabilitando cajon");
            XRGrabInteractable xgrab = cajon.GetComponent<XRGrabInteractable>();
            xgrab.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!Parametros.cajonesAbiertos[int.Parse(numeroCajon) - 1])
        {
            texto.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        texto.SetActive(false);
    }
}
