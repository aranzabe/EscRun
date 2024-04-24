using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigueSocketPuerta : MonoBehaviourPunCallbacks
{
    public Transform socket;
    public Transform puerta;
    private Quaternion rotacionInicial;
    private Vector3 offset; 

    void Start()
    {
        rotacionInicial = transform.rotation;
        offset = transform.position - socket.position;
        //transform.rotation = Quaternion.LookRotation(puerta.forward, puerta.up);
    }

    void LateUpdate()
    {
        if (photonView.IsMine)
        {
            if (!Parametros.pistaCondicion1_CogidaPrimeraVez)
            {
                Vector3 seguimiento = socket.position + offset;
                transform.position = seguimiento;
                transform.rotation = rotacionInicial * Quaternion.Euler(puerta.rotation.eulerAngles.x, puerta.rotation.eulerAngles.y, 0);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            if (!Parametros.pistaCondicion1_CogidaPrimeraVez)
            {
                Parametros.pistaCondicion1_CogidaPrimeraVez = true;

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (photonView.IsMine)
        {
            if (!Parametros.pistaCondicion1_CogidaPrimeraVez)
            {
                Parametros.pistaCondicion1_CogidaPrimeraVez = true;

            }
        }
    }
}
