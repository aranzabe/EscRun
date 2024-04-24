using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviourPunCallbacks
{
    public Transform objeto;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = objeto.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            transform.position = objeto.position;
        }
    }
}
