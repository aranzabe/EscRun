using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;


/**
 * Este script es para comprobar qué pasa cuando se pulsa el botón de la mesa de los cubos de los datos.
 */
public class ButtonPlayDatos : MonoBehaviour
{
    public GameObject button;
    //public UnityEvent onPress;
    //public UnityEvent onRelease;
    public GameObject canvas;
    public TextMeshProUGUI texto;
    private AudioSource sound;
    public GameObject cajon;
    //public GameObject llaveGuardada;
    //private GameObject presser;
    //bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        //isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //onPress.Invoke ();
        sound.Play();
        //if (!isPressed)
        //{
        //    //button.transform.localPosition = new Vector3 (0, 0.003f, 0);
        //    presser = other.gameObject;
            
        //    isPressed = true;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        comprobarDatos();
        //onRelease.Invoke ();
        //if (other == presser)
        //{
        //    //button.transform.localPosition = new Vector3(0, 0.015f,0);

        //    isPressed = true;
        //}
    }

    public void comprobarDatos()
    {
        texto.text = "";


        //texto.text = "Enigma completado!!! Algo ha cambiado.";
        //Vector3 currentPosition = cajon.transform.localPosition;
        //float nuevaPosicionZ = currentPosition.z - 0.3f;
        //cajon.transform.localPosition = new Vector3(currentPosition.x, currentPosition.y, nuevaPosicionZ);
        //llaveGuardada.transform.localPosition = cajon.transform.localPosition;


        if (!Parametros.enigmaDatosResuelto)
        {
            Parametros.enigmaDatosResuelto = true;
            for (int i = 0; i < Parametros.soportesBienColocados.Length; i++)
            {
                if (!Parametros.soportesBienColocados[i])
                {
                    Parametros.enigmaDatosResuelto = false;
                    texto.text = "Verifica los soportes";
                }
            }
            if (Parametros.enigmaDatosResuelto)
            {
                for (int i = 0; i < Parametros.notasBienColocados.Length; i++)
                {
                    if (!Parametros.notasBienColocados[i])
                    {
                        Parametros.enigmaDatosResuelto = false;
                        texto.text = "Todavía falta algo";
                    }
                }
                if (Parametros.enigmaDatosResuelto)
                {
                    texto.text = "Enigma completado!!! Algo ha cambiado.";
                    Vector3 currentPosition = cajon.transform.localPosition;
                    float nuevaPosicionZ = currentPosition.z - 0.3f;
                    cajon.transform.localPosition = new Vector3(currentPosition.x, currentPosition.y, nuevaPosicionZ);

                    XRGrabInteractable xgrab = cajon.GetComponent<XRGrabInteractable>();
                    xgrab.enabled = true;
                }
            }
        } else
        {
            texto.text = "Este enigma ya está resuelto.";
        }
        canvas.SetActive(true);
        Invoke("DesactivarCanvas", 3f);
    }

    private void DesactivarCanvas()
    {
        canvas.SetActive(false);
    }
}
