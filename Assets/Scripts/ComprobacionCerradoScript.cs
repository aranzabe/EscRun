using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/**
 * Este script es para decir si un caj�n est� cerrado o no. Si est� cerrado deshabilita la propiedad de grab.
 */
public class ComprobacionCerradoScript : MonoBehaviourPunCallbacks
{
    public GameObject elemento; //Puede ser Cajon, Armario o Puerta. Por eso se llaman: SheetRack_Cajon_X, Door_Armario_X o Loquesea_Puerta_X.
    public GameObject canvas;
    private string numeroElemento;
    private string[] partesNombreElemento;
    // Start is called before the first frame update

    void Start()
    {
        string nombreElemento = elemento.name;
        partesNombreElemento = nombreElemento.Split('_');
        numeroElemento = partesNombreElemento[2];

        
        if (partesNombreElemento[1] == "Cajon")
        {
            if (!Parametros.cajonesAbiertos[int.Parse(numeroElemento) - 1])
            {
                XRGrabInteractable xgrab = elemento.GetComponent<XRGrabInteractable>();
                xgrab.enabled = false;
            }
        }
        if (partesNombreElemento[1] == "Armario")
        {
            if (!Parametros.armariosAbiertos[int.Parse(numeroElemento) - 1])
            {
                XRGrabInteractable xgrab = elemento.GetComponent<XRGrabInteractable>();
                xgrab.enabled = false;
            }
        }
        canvas.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            if (partesNombreElemento[1] == "Cajon")
            {
                if (!Parametros.cajonesAbiertos[int.Parse(numeroElemento) - 1])
                {
                    canvas.SetActive(true);
                }
            }
            if (partesNombreElemento[1] == "Armario")
            {
                if (!Parametros.armariosAbiertos[int.Parse(numeroElemento) - 1])
                {
                    canvas.SetActive(true);
                }
            }
            if (partesNombreElemento[1] == "Puerta")
            {
                if (!Parametros.puertasAbiertas[int.Parse(numeroElemento) - 1])
                {
                    canvas.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (photonView.IsMine)
        {
            canvas.SetActive(false);
        }
    }
}
