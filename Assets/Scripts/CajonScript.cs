using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CajonScript : MonoBehaviour
{
    public GameObject cajon;
    public GameObject texto;
    // Start is called before the first frame update
    void Start()
    {
        if (Parametros.cajon1Cerrado)
        {
            Debug.Log("Deshabilitando cajon1");
            XRGrabInteractable xgrab = cajon.GetComponent<XRGrabInteractable>();
            xgrab.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (Parametros.cajon1Cerrado)
        {
            texto.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        texto.SetActive(false);
    }
}
