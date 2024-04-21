using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncenderChimenea : MonoBehaviour
{
    public GameObject luz;
    public GameObject particulas;
    private AudioSource sound;

    private void Start()
    {
        sound = particulas.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Estatua")
        {
            luz.SetActive(true);
            particulas.SetActive(true);
            sound.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Estatua")
        {
            luz.SetActive(true);
            particulas.SetActive(true);
            sound.Play();
        }
    }
    
}
