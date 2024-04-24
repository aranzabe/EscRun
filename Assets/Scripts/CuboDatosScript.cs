using Photon.Pun;
using TMPro;
using UnityEngine;

/**
 * Este script es para comprobar si cada nota está correctamente puesta en su cubo. Caso de ser así el enigma 1 queda resuelto y se abrirá un cajón con la llave de una puerta.
 */
public class CuboDatosScript : MonoBehaviourPunCallbacks
{
    public GameObject cubo;
    private string numeroCubo;
    public TextMeshProUGUI texto;
    // Start is called before the first frame update
    void Start()
    {
        string nombreCubo = cubo.name;
        string[] partesNombreCubo = nombreCubo.Split('_');
        numeroCubo = partesNombreCubo[2];
        texto.text = numeroCubo;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            texto.text = texto.text + "Enter cubo: ";
            string notaNombre = other.tag;
            string[] partesNombreNota = notaNombre.Split('_');
            texto.text = texto.text + " -- " + partesNombreNota[2];
            if (numeroCubo == partesNombreNota[2])
            {
                Parametros.notasBienColocados[int.Parse(numeroCubo)] = true;
            }
            else
            {
                Parametros.notasBienColocados[int.Parse(numeroCubo)] = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (photonView.IsMine)
        {
            texto.text = "Exit cubo";
        }
    }
}
