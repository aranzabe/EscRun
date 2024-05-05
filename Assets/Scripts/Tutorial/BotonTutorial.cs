using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BotonTutorial : MonoBehaviour
{
    public TextMeshProUGUI texto;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        sound.Play();
        texto.text = "Pulsado!! Muy bien.";
    }
}
