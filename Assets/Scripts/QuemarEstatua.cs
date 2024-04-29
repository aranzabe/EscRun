using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuemarEstatua : MonoBehaviour
{
    public GameObject estatua;
    public GameObject pieza;

    private void OnTriggerEnter(Collider other)
    {
        if (Parametros.enigmaObjetosCompletoResuelto)
        {
            estatua.SetActive(false);
            pieza.SetActive(true);
        }
    }
}
