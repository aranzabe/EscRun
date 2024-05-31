using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SoporteDisipador : MonoBehaviour
{
    public GameObject canvas;
    public XRBaseInteractor interactor;

    public TextMeshProUGUI textoAuxiliarGeneral;
    // Start is called before the first frame update
    void Start()
    {
        interactor.selectEntered.AddListener(OnSelectEnter);
        interactor.selectExited.AddListener(OnSelectExit);
    }

    private void OnSelectExit(SelectExitEventArgs arg0)
    {
        Parametros.piezasCPUColocadas[3] = false;
        //mostrarEstado();
    }

    [Obsolete]
    private void OnSelectEnter(SelectEnterEventArgs arg0)
    {
        Parametros.piezasCPUColocadas[3] = true;
        //mostrarEstado();
        if (Parametros.todosComponentesCPUOk())
        {
            canvas.SetActive(true);
            textoAuxiliarGeneral.text = "CPU funcional. Este ordenador controla la puerta de salida que hay en la clase... eres libre. Arranca el ordenador y CORRE!!!";
        }
    }

  
    private void mostrarEstado()
    {
        textoAuxiliarGeneral.text += "Piezas CPU colocadas: ";
        for (int i = 0; i < Parametros.piezasCPUColocadas.Length; i++)
        {
            if (Parametros.piezasCPUColocadas[i])
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
