using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
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
        transform.position = objeto.position;
    }
}
