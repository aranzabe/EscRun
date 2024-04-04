using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CajonScript : MonoBehaviour
{
    public GameObject cajon;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
