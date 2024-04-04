using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LlaveCandado1Script : MonoBehaviour
{
    public GameObject cajonAbre;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Candado_Cajon1")
        {
            Debug.Log("Candado 1 abierto");

            XRGrabInteractable xgrab = cajonAbre.GetComponent<XRGrabInteractable>();
            xgrab.enabled = enabled;

            Parametros.cajon1Cerrado = true;
        }
    }
}
