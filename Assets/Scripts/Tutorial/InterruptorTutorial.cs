using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterruptorTutorial : MonoBehaviour
{
    public TextMeshProUGUI texto;

    private void OnTriggerEnter(Collider other)
    {
        texto.text = "Encendido.";
    }

    private void OnTriggerExit(Collider other)
    {
        texto.text = "Apagado.";
    }
}
