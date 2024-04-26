using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SoporteAccionScript : MonoBehaviour
{
    public GameObject soporte;
    private string numeroSoporte;
    public TextMeshProUGUI texto;
    public XRBaseInteractor interactor;

    public TextMeshProUGUI textoAuxiliarGeneral;
    // Start is called before the first frame update

    private void Start()
    {
        string nombreSoporte = soporte.name;
        string[] partesNombre = nombreSoporte.Split('_');
        numeroSoporte = partesNombre[2];
        texto.text = numeroSoporte;

        // Registrar eventos de interacción
        interactor.selectEntered.AddListener(OnSelectEnter);
        interactor.selectExited.AddListener(OnSelectExit);
    }

    private void OnSelectExit(SelectExitEventArgs arg0)
    {
        texto.text = "Socket vacio";
        Parametros.acciones[int.Parse(numeroSoporte) - 1] = "";
        mostrarEstado();
    }

    [Obsolete]
    private void OnSelectEnter(SelectEnterEventArgs arg0)
    {
        texto.text = "Socket con objeto";
        Parametros.acciones[int.Parse(numeroSoporte) - 1] = arg0.interactable.gameObject.tag.ToString();
        mostrarEstado();
    }

    private void mostrarEstado()
    {
        textoAuxiliarGeneral.text = "";
        for (int i = 0; i < Parametros.acciones.Length; i++)
        {
            textoAuxiliarGeneral.text += "[" + i + "]= " + Parametros.acciones[i] + " ";
        }
    }

}
