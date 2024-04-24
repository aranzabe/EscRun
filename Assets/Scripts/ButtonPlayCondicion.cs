using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPlayCondicion : MonoBehaviourPunCallbacks
{
    public GameObject canvas;
    public TextMeshProUGUI texto;
    private AudioSource sound;
    public TextMeshProUGUI textoAuxiliarGeneral;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            sound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (photonView.IsMine)
        {
            mostrarEstado();
            comprobarDatos();
        }
    }


    private void mostrarEstado()
    {
        if (photonView.IsMine)
        {
            textoAuxiliarGeneral.text = "Soportes bien colocados: ";
            for (int i = 0; i < Parametros.soportesInterruptoresBienColocados.Length; i++)
            {
                if (Parametros.soportesInterruptoresBienColocados[i])
                {
                    textoAuxiliarGeneral.text += "v ";
                }
                else
                {
                    textoAuxiliarGeneral.text += "f ";
                }
            }
            textoAuxiliarGeneral.text += "En zocalo: ";
            for (int i = 0; i < Parametros.enZocalo.Length; i++)
            {
                if (Parametros.enZocalo[i])
                {
                    textoAuxiliarGeneral.text += "v ";
                }
                else
                {
                    textoAuxiliarGeneral.text += "f ";
                }
            }
            textoAuxiliarGeneral.text += "Pulsados: ";
            for (int i = 0; i < Parametros.botonCondicionPulsado.Length; i++)
            {
                if (Parametros.botonCondicionPulsado[i])
                {
                    textoAuxiliarGeneral.text += "v ";
                }
                else
                {
                    textoAuxiliarGeneral.text += "f ";
                }
            }
            textoAuxiliarGeneral.text += "Respuesta correcta: ";
            for (int i = 0; i < Parametros.solucionEnigmaCondiciones.Length; i++)
            {
                if (Parametros.solucionEnigmaCondiciones[i])
                {
                    textoAuxiliarGeneral.text += "v ";
                }
                else
                {
                    textoAuxiliarGeneral.text += "f ";
                }
            }
        }
    }

    public void comprobarDatos()
    {
        if (photonView.IsMine)
        {
            texto.text = "";


            if (!Parametros.enigmaCondicionalesResuelto)
            {
                Parametros.enigmaCondicionalesResuelto = true;
                for (int i = 0; i < Parametros.soportesInterruptoresBienColocados.Length; i++)
                {
                    if (!Parametros.soportesInterruptoresBienColocados[i])
                    {
                        Parametros.enigmaCondicionalesResuelto = false;
                        texto.text = "Verifica los soportes";
                    }
                }
                if (Parametros.enigmaCondicionalesResuelto)
                {
                    for (int i = 0; i < Parametros.solucionEnigmaCondiciones.Length; i++)
                    {
                        if (Parametros.botonCondicionPulsado[i] != Parametros.solucionEnigmaCondiciones[i])
                        {
                            Parametros.enigmaCondicionalesResuelto = false;
                            texto.text = "Todav�a falta algo";
                        }
                    }
                    if (Parametros.enigmaCondicionalesResuelto)
                    {
                        texto.text = "Enigma 2 completado!!! Pero estoy atascada, necesito que me ayudes para poder liberarte...";
                    }
                }
            }
            else
            {
                if (Parametros.puerta2HabitacionCuartoAbierta)
                {
                    texto.text = "Este enigma ya est� resuelto.";
                }
                else
                {
                    texto.text = "Estoy atascada, necesito que me ayudes para poder liberarte...";
                }

            }
            canvas.SetActive(true);
            Invoke("DesactivarCanvas", 5f);
        }
    }

    private void DesactivarCanvas()
    {
        if (photonView.IsMine)
        {
            canvas.SetActive(false);
        }
    }
}
