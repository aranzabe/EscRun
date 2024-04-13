using System.Collections;
using TMPro;
using UnityEngine;

public class ButtonCondicion : MonoBehaviour
{
    public TextMeshProUGUI texto;
    private string tagGa;
    private string[] partesNombreBoton;
    public TextMeshProUGUI textoAuxiliarGeneral;

    private AudioSource sound;

    //Para el cambio de color.
    private Renderer meshRenderer;
    public Material normalMaterial;
    public Material pressedMaterial;
    public GameObject boton;


    private void Start()
    {
        textoAuxiliarGeneral.text = "";
        tagGa = gameObject.tag;
        partesNombreBoton = tagGa.Split('_');

        meshRenderer = boton.GetComponent<Renderer>();
        sound = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        sound.Play();
        //Vector3 currentPosition = boton.transform.localPosition;
        //float nuevaPosicionY = currentPosition.y - 0.006f;
        //boton.transform.localPosition = new Vector3(currentPosition.x, nuevaPosicionY, currentPosition.z);
        //StartCoroutine(RecolocarBoton(currentPosition));
        //textoAuxiliarGeneral.text = tagGa + " ";
        
        //textoAuxiliarGeneral.text += "Pulsado.";
        
        //Si el botón está bien colocado actualizamos el vector correspondiente (lo haremos viendo el número final que es el índice del vector).
        //if (Parametros.enZocalo[int.Parse(partesNombreBoton[2]) - 1])
        //{
        //    Parametros.soportesInterruptoresBienColocados[int.Parse(partesNombreBoton[2]) - 1] = true;
        //    textoAuxiliarGeneral.text += " en pos correcta";
        //} else
        //{
        //    Parametros.soportesInterruptoresBienColocados[int.Parse(partesNombreBoton[2]) - 1] = false;
        //}


    }

    private void OnTriggerExit(Collider other)
    {
        //Cambiamos el material al pulsar (pulsado o no).
        Parametros.botonCondicionPulsado[int.Parse(partesNombreBoton[2]) - 1] = !Parametros.botonCondicionPulsado[int.Parse(partesNombreBoton[2]) - 1];

        if (!Parametros.botonCondicionPulsado[int.Parse(partesNombreBoton[2]) - 1])
        {
            meshRenderer.material = normalMaterial;
        }
        else
        {
            meshRenderer.material = pressedMaterial;
        }
    }

    //IEnumerator RecolocarBoton(Vector3 currentPosition)
    //{
    //    yield return new WaitForSeconds(1f);
    //    boton.transform.position = currentPosition;
    //}
}
