using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuentaAtras : MonoBehaviour
{
    private int minutos;
    private int segundos;
    public TextMeshProUGUI texto;

    void Start()
    {
        minutos = Parametros.minutos;
        segundos = Parametros.segundos;
        //ActualizarTextoReloj();
        texto.text = "Tiempo: " + Parametros.minutos.ToString("00") + ":" + Parametros.segundos.ToString("00");
        InvokeRepeating("ActualizarTiempo", 1f, 1f); // Llama a ActualizarTiempo() cada segundo
    }
   
    void ActualizarTiempo()
    {
        if (segundos > 0)
        {
            segundos--;
            Parametros.segundos--;
        }
        else
        {
            if (minutos > 0)
            {
                minutos--;
                Parametros.minutos--;
                segundos = 59;
                Parametros.segundos = 59;
            }
            else
            {
                Parametros.textoFinal = "¡Has fallado! No has resuelto todos los enigmas, te quedarás repitiendo curso...";
                CancelInvoke("ActualizarTiempo");
                SceneManager.LoadScene("Sala_Final");
            }
        }
        texto.text = "Tiempo: " + Parametros.minutos.ToString("00") + ":" + Parametros.segundos.ToString("00");
    }
}
