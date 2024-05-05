using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SoportesOcupados : MonoBehaviour
{
    public XRBaseInteractor interactor;
    public TextMeshProUGUI texto;

    // Start is called before the first frame update
    void Start()
    {
        interactor.selectEntered.AddListener(OnSelectEnter);
        interactor.selectExited.AddListener(OnSelectExit);
    }

    [Obsolete]
    private void OnSelectEnter(SelectEnterEventArgs arg0)
    {
        texto.text = "Pieza colocada correctamente.";
    }

    private void OnSelectExit(SelectExitEventArgs arg0)
    {
        texto.text = "Soporte vacío.";
    }
}
