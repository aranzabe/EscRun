using Photon.Pun;
using System.Collections;
using TMPro;
using UnityEngine;

public class ButtonCondicion : MonoBehaviourPunCallbacks
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
        if (photonView.IsMine)
        {
            sound.Play();
            //Vector3 currentPosition = boton.transform.localPosition;
            //float nuevaPosicionY = currentPosition.y - 0.006f;
            //boton.transform.localPosition = new Vector3(currentPosition.x, nuevaPosicionY, currentPosition.z);
            //StartCoroutine(RecolocarBoton(currentPosition));
            //textoAuxiliarGeneral.text = tagGa + " ";

            //textoAuxiliarGeneral.text += "Pulsado.";

            //Si el bot�n est� bien colocado actualizamos el vector correspondiente (lo haremos viendo el n�mero final que es el �ndice del vector).
            //if (Parametros.enZocalo[int.Parse(partesNombreBoton[2]) - 1])
            //{
            //    Parametros.soportesInterruptoresBienColocados[int.Parse(partesNombreBoton[2]) - 1] = true;
            //    textoAuxiliarGeneral.text += " en pos correcta";
            //} else
            //{
            //    Parametros.soportesInterruptoresBienColocados[int.Parse(partesNombreBoton[2]) - 1] = false;
            //}

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (photonView.IsMine)
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
    }

    //IEnumerator RecolocarBoton(Vector3 currentPosition)
    //{
    //    yield return new WaitForSeconds(1f);
    //    boton.transform.position = currentPosition;
    //}
}
