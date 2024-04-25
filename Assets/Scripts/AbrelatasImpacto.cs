using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrelatasImpacto : MonoBehaviour
{
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
            contenido.SetActive(true);
        }
    }


    
}
