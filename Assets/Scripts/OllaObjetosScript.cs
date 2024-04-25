using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OllaObjetosScript : MonoBehaviour
{
    public TextMeshProUGUI textoAuxiliarGeneral;

    private void OnTriggerEnter(Collider other)
    {
        Parametros.contenidoOlla.Add(other.tag);
        textoAuxiliarGeneral.text = "";
        foreach (var item in Parametros.contenidoOlla)
        {
            textoAuxiliarGeneral.text += item + "  ";
        }
        textoAuxiliarGeneral.text += "(" + Parametros.contenidoOlla.Count + ")";
        textoAuxiliarGeneral.text += "  Buscado: ";
        foreach (var item in Parametros.contenidoOllaBuscado)
        {
            textoAuxiliarGeneral.text += item + "  ";
        }
        textoAuxiliarGeneral.text += "(" + Parametros.contenidoOllaBuscado.Count + ")";
    }

    private void OnTriggerExit(Collider other)
    {
        Parametros.contenidoOlla.Remove(other.tag);
        textoAuxiliarGeneral.text = "";
        foreach (var item in Parametros.contenidoOlla)
        {
            textoAuxiliarGeneral.text += item + "  ";
        }
        textoAuxiliarGeneral.text += "(" + Parametros.contenidoOlla.Count + ")";
        textoAuxiliarGeneral.text += "  Buscado: ";
        foreach (var item in Parametros.contenidoOllaBuscado)
        {
            textoAuxiliarGeneral.text += item + "  ";
        }
        textoAuxiliarGeneral.text += "(" + Parametros.contenidoOlla.Count + ")";
    }
}
