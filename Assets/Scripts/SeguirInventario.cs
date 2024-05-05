using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirInventario : MonoBehaviour
{
    public Transform objeto;
    private Boolean encendido = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (encendido)
        {
            transform.position = objeto.position;
        }
        else
        {
            transform.position = new Vector3(15f, 0f, 10f);
        }
    }


    public void encender()
    {
        encendido = true;

    }
    public void apagar()
    {
        encendido = false;

    }

}
