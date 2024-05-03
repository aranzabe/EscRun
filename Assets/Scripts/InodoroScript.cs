using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InodoroScript : MonoBehaviour
{
    public XRBaseInteractor interactor;
    public GameObject llaveInodoro;
    public GameObject RAM2;
    // Start is called before the first frame update
    void Start()
    {
        // Registrar eventos de interacción
        interactor.selectEntered.AddListener(OnSelectEnter);
        interactor.selectExited.AddListener(OnSelectExit);
    }

    private void OnSelectExit(SelectExitEventArgs arg0)
    {
        if (Parametros.enigmaCondicionalesResuelto)
        {
            llaveInodoro.SetActive(true);
            RAM2.SetActive(true);
        }
    }

    private void OnSelectEnter(SelectEnterEventArgs arg0)
    {
    }
}
