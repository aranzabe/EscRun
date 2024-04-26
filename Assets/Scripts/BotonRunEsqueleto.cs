using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        texto.text = "Ejecutando programa...\n";
    }

    private void OnTriggerExit(Collider other)
    {
        ejecutarPrograma();
        canvas.SetActive(true);
    }

    private void ejecutarPrograma()
    {
        if (!Parametros.enigmaObjetosCompletoResuelto)
        {
            mostrarAccionesPuestas();
            if (accionesPuestasCorrectamente())
            {
                StartCoroutine(EjecutarAnimaciones());
            }
            else
            {
                texto.text = "Faltan acciones por programar.";
                Invoke("DesactivarCanvas", 5f);
            }
            
        } else
        {
            texto.text = "Ya has resuelto este enigma. La estatua se ha convertido en cera, dentro guarda algo para ti.";
            Invoke("DesactivarCanvas", 10f);
        }
       
    }


    private bool accionesPuestasCorrectamente()
    {
        bool correcto = true;
        for (int i = 0;i < Parametros.acciones.Length;i++) { 
            if (Parametros.acciones[i] == "")
            {
                correcto = false;
            }
        }
        return correcto;
    }

    private IEnumerator EjecutarAnimaciones()
    {
        //mostrarAccionesPuestas();
        //animator.SetBool("andar", true);
        for (int i = 0; i < Parametros.acciones.Length; i++)
        {
            if (Parametros.acciones[i] != "")
            {
                texto.text += "Lanzando " + Parametros.acciones[i].ToString() + " ";
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
                float duracionAnimacion = 1.0f;
                if (Parametros.ejecucionAcciones[i] == 1) //Repetitivo
                {
                    texto.text += " bucle \n";
                    duracionAnimacion = 20.0f;
                } else
                {
                    texto.text += " secuencial \n";
                    duracionAnimacion = 5.0f;
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
        if (comprobarSecuenciaCorrecta())
        {
            Parametros.enigmaObjetosCompletoResuelto = true;
            texto.text += "Has elegido sabiamente. La estatua se ha convertido en cera, dentro guarda algo para ti.";
        }
        else
        {
            texto.text += "Programa incorrecto";
        }
        Invoke("DesactivarCanvas", 10f);
    }

 

    void mostrarAccionesPuestas()
    {
        textoAuxiliarGeneral.text = "Acciones: ";
        for (int i = 0; i < Parametros.acciones.Length; i++)
        {
            textoAuxiliarGeneral.text += "[" + i + "]= " + Parametros.acciones[i] + " ";
        }
        textoAuxiliarGeneral.text += "\nAcciones Correctas: ";
        for (int i = 0; i < Parametros.acciones.Length; i++)
        {
            textoAuxiliarGeneral.text += "[" + i + "]= " + Parametros.accionesCorrectas[i] + " ";
        }
        textoAuxiliarGeneral.text += "\nEjecución: ";
        for (int i = 0; i < Parametros.acciones.Length; i++)
        {
            textoAuxiliarGeneral.text += "[" + i + "]= " + Parametros.ejecucionAcciones[i] + " ";
        }
        textoAuxiliarGeneral.text += "\nEjecución correcta: ";
        for (int i = 0; i < Parametros.acciones.Length; i++)
        {
            textoAuxiliarGeneral.text += "[" + i + "]= " + Parametros.ejecucionAccionesCorrectas[i] + " ";
        }

    }


    private IEnumerator Esperar(float segundos)
    {
        yield return new WaitForSeconds(segundos);
    }


    private bool comprobarSecuenciaCorrecta()
    {
        
        bool correcto = Parametros.acciones.SequenceEqual(Parametros.accionesCorrectas) && Parametros.ejecucionAcciones.SequenceEqual(Parametros.ejecucionAccionesCorrectas);
        return correcto;
    }

    private void DesactivarCanvas()
    {
        canvas.SetActive(false);
    }

}
