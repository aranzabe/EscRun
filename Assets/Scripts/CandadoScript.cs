using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CandadoScript : MonoBehaviour
{
    public GameObject cajonAbre;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Llave_Cajon1")
        {
            Debug.Log("Candado 1 abierto");

            XRGrabInteractable xgrab = cajonAbre.GetComponent<XRGrabInteractable>();
            xgrab.enabled = true;

            Parametros.cajon1Cerrado = false;
        }
    }
}
