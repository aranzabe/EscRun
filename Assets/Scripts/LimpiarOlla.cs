using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimpiarOlla : MonoBehaviour
{
    public GameObject canvas;
    
    public void limpiarOlla()
    {
        canvas.SetActive(true);
        Parametros.contenidoOlla.Clear();
        Invoke("DesactivarCanvas", 5f);
    }

    private void DesactivarCanvas()
    {
        canvas.SetActive(false);
    }

}
