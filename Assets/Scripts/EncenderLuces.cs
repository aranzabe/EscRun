using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncenderLuces : MonoBehaviour
{
    public GameObject luzClase;
    public GameObject luzCuarto;
    public GameObject luzSalon;
    private AudioSource sound;

    private string nombreSala;

    private void Start()
    {
        nombreSala = gameObject.tag;
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (nombreSala == "onCuarto")
        {
            luzClase.SetActive(true);
            luzCuarto.SetActive(true);
        }
        if (nombreSala == "onSalon")
        {
            luzSalon.SetActive(true);
        }
        sound.Play(); 
    }
}
