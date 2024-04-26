using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BotonRunEsqueleto : MonoBehaviour
{
    public GameObject esqueleto;
    public GameObject canvas;
    public TextMeshProUGUI texto;
    private AudioSource sound;
    private Animator animator;
    public TextMeshProUGUI textoAuxiliarGeneral;

    // Start is called before the first frame update
    void Start()
    {
        animator = esqueleto.GetComponent<Animator>();  
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        sound.Play();
        texto.text = "Ejecutando programa...";
    }

    private void OnTriggerExit(Collider other)
    {
        //comprobarSecuenciaCorrecta();
        ejecutarPrograma();
        canvas.SetActive(true);
        //Invoke("DesactivarCanvas", 5f);
    }

    private void ejecutarPrograma()
    {
        mostrarAccionesPuestas();
        StartCoroutine(EjecutarAnimaciones());
    }

    private IEnumerator EjecutarAnimaciones()
    {
        //mostrarAccionesPuestas();
        //animator.SetBool("andar", true);
        for (int i = 0; i < Parametros.acciones.Length; i++)
        {
            if (Parametros.acciones[i] != "")
            {
                textoAuxiliarGeneral.text += "Lanzando " + Parametros.acciones[i].ToString() + " ";
                switch (Parametros.acciones[i])
                {
                    case "andar": animator.SetBool("andar", true); break;
                    case "correr": animator.SetBool("correr", true); break;
                    case "andarZombie": animator.SetBool("andarZombie", true); break;
                    case "atacar": animator.SetBool("atacar", true); break;
                    case "atacarFuerte": animator.SetBool("atacarFuerte", true); break;
                    case "mirar": animator.SetBool("mirar", true); break;
                    case "serGolpeado": animator.SetBool("serGolpeado", true); break;
                    case "morir": animator.SetBool("morir", true); break;
                }
                //animator.SetBool(Parametros.acciones[i], true);    //<- Esto no funciona (????)
                //StartCoroutine(Esperar(10.0f));
                float duracionAnimacion = 5.0f;
                if (Parametros.ejecucionAcciones[i] == 1) //Repetitivo
                {
                    textoAuxiliarGeneral.text += " bucle ";
                    duracionAnimacion = 15.0f;
                }
                //animator.SetBool(Parametros.acciones[i], false);
                yield return new WaitForSeconds(duracionAnimacion);
                switch (Parametros.acciones[i])
                {
                    case "andar": animator.SetBool("andar", false); break;
                    case "correr": animator.SetBool("correr", false); break;
                    case "andarZombie": animator.SetBool("andarZombie", false); break;
                    case "atacar": animator.SetBool("atacar", false); break;
                    case "atacarFuerte": animator.SetBool("atacarFuerte", false); break;
                    case "mirar": animator.SetBool("mirar", false); break;
                    case "serGolpeado": animator.SetBool("serGolpeado", false); break;
                    case "morir": animator.SetBool("morir", false); break;
                }
            }
        }
    }

 

    void mostrarAccionesPuestas()
    {
        textoAuxiliarGeneral.text = "";
        for (int i = 0; i < Parametros.acciones.Length; i++)
        {
            textoAuxiliarGeneral.text += "[" + i + "]= " + Parametros.acciones[i] + " ";
        }
    }


    private IEnumerator Esperar(float segundos)
    {
        yield return new WaitForSeconds(segundos);
    }


    private bool comprobarSecuenciaCorrecta()
    {
        return true;
    }

    private void DesactivarCanvas()
    {
        canvas.SetActive(false);
    }

}
