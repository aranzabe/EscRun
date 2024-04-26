using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CocinarObjeto : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI texto;
    private AudioSource sound;
    public GameObject esqueleto;
    public GameObject panelDeMando;
    public GameObject tarjetas;


    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        sound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!Parametros.enigmaObjetosResuelto)
        {
            if (comprobarCocido())
            {
                texto.text = "Receta correcta. Se ha creado un objeto que te espera en la clase... para que completes la receta. En la mesa del profesor encontrarás lo necesario.";
                Parametros.enigmaObjetosResuelto = true;
                esqueleto.SetActive(true);
                panelDeMando.SetActive(true);
                tarjetas.SetActive(true);
            }
            else
            {
                texto.text = "El contenido de la olla no es correcto. No se ha cocinado nada.";
            }
        }
        else
        {
            texto.text = "Esta parte de la receta está resuelta. Se ha creado un objeto que te espera en la clase... para que completes la receta. En la mesa del profesor encontrarás lo necesario.";
        }
        canvas.SetActive(true);
        Invoke("DesactivarCanvas", 10f);
    }

    private bool comprobarCocido()
    {
        bool correcto = true;

        
        if (Parametros.contenidoOlla.Count == Parametros.contenidoOllaBuscado.Count && Parametros.contenidoOlla.Count != 0)
        {
            Parametros.contenidoOlla.Sort();
            var array1 = Parametros.contenidoOlla.ToArray();
            var array2 = Parametros.contenidoOllaBuscado.ToArray();
            correcto = array1.SequenceEqual(array2);
        } else
        {
            correcto = false;
        }
        return correcto;
    }

    private void DesactivarCanvas()
    {
        canvas.SetActive(false);
    }
}
