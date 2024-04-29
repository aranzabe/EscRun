using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AbrelatasImpacto : MonoBehaviour
{
    public GameObject lataCompleta;
    public GameObject lataIntacta;
    public GameObject lataEspachurra;
    public GameObject contenido;
    private AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Abrelatas")
        {
            sound.Play();
            lataIntacta.SetActive(false);
            lataEspachurra.SetActive(true);
            //Vector3 lataPosition = lataEspachurra.transform.position;
            //Vector3 offset = new Vector3(-0.2f, -0.2f, -0.2f);
            //Vector3 contenidoPosition = lataPosition + offset;
            contenido.SetActive(true);
            XRGrabInteractable xgrab = lataCompleta.GetComponent<XRGrabInteractable>();
            xgrab.enabled = false;
            //contenido.transform.position = contenidoPosition;
        }
    }


    
}
