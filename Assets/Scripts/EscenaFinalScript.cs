using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaFinalScript : MonoBehaviour
{
    public TextMeshProUGUI texto;

    private void Start()
    {
        texto.text = Parametros.textoFinal;
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
