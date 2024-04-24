using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InodoroScript : MonoBehaviourPunCallbacks
{
    public XRBaseInteractor interactor;
    public GameObject llaveInodoro;
    // Start is called before the first frame update
    void Start()
    {
        // Registrar eventos de interacci�n
        interactor.selectEntered.AddListener(OnSelectEnter);
        interactor.selectExited.AddListener(OnSelectExit);
    }

    private void OnSelectExit(SelectExitEventArgs arg0)
    {
        if (photonView.IsMine)
        {
            if (Parametros.enigmaCondicionalesResuelto)
            {
                llaveInodoro.SetActive(true);
            }
        }
    }

    private void OnSelectEnter(SelectEnterEventArgs arg0)
    {
    }
}
