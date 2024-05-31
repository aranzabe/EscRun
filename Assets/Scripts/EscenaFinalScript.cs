using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaFinalScript : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public GameObject S1;
    public GameObject S2;
    public GameObject S3;
    public GameObject S4;

    private void Start()
    {
        texto.text = Parametros.textoFinal;
        if (Parametros.ordenadorEncendido)
        {
            S1.SetActive(true);
            S2.SetActive(true);
            S3.SetActive(true);
            S4.SetActive(true);
        }
    }
    public void salirJuego()
    {
        Application.Quit();
    }

    public void volverAJugar()
    {
        Parametros.minutos = 59;
        Parametros.segundos = 59;
        SceneManager.LoadScene("Escena_Clase");
    }
}
