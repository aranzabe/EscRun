using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbrirPuertaFinal : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI texto;

    private void OnTriggerEnter(Collider other)
    {
        if (Parametros.ordenadorEncendido)
        {
            texto.text = "Has salido! Enhorabuena.";
        } else
        {
            texto.text = "Esta es la puerta principal para escapar pero... te queda mucho para eso.";
        }
        canvas.SetActive(true);
        Invoke("DesactivarCanvas", 5f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (Parametros.ordenadorEncendido)
        {
            texto.text = "Has salido! Enhorabuena.";
        }
        else
        {
            texto.text = "Esta es la puerta principal para escapar pero... te queda mucho para eso.";
        }
        canvas.SetActive(true);
        Invoke("DesactivarCanvas", 5f);
    }

    private void DesactivarCanvas()
    {
        canvas.SetActive(false);
    }
}
