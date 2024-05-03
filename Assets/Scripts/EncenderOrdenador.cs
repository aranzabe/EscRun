using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EncenderOrdenador : MonoBehaviour
{
    private AudioSource sound;
    //Para el cambio de color.
    private Renderer meshRenderer;
    public Material normalMaterial;
    public Material pressedMaterial;
    public GameObject S1;
    public GameObject S2;
    public GameObject S3;
    public GameObject S4;
    public GameObject S1Joint;
    public GameObject S2Joint;
    public GameObject S3Joint;
    public GameObject S4Joint;
    private Animator animator1;
    private Animator animator2;
    private Animator animator3;
    private Animator animator4;
    private AudioSource sound1;
    private AudioSource sound2;
    private AudioSource sound3;
    private AudioSource sound4;
    public AudioClip[] clips;

    void Start()
    {
        meshRenderer = GetComponent<Renderer>();
        sound = GetComponent<AudioSource>();
        meshRenderer.material = normalMaterial;
        animator1 = S1Joint.GetComponent<Animator>();
        animator2 = S2Joint.GetComponent<Animator>();
        animator3 = S3Joint.GetComponent<Animator>();
        animator4 = S4Joint.GetComponent<Animator>();
        sound1 = S1Joint.GetComponent<AudioSource>();
        sound2 = S2Joint.GetComponent<AudioSource>();
        sound3 = S3Joint.GetComponent<AudioSource>();
        sound4 = S4Joint.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        sound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (Parametros.todosComponentesCPUOk())
        {
            Parametros.ordenadorEncendido = !Parametros.ordenadorEncendido;
        }
        if (!Parametros.ordenadorEncendido)
        {
            meshRenderer.material = normalMaterial;
        }
        else
        {
            meshRenderer.material = pressedMaterial;
            Parametros.ordenadorEncendido = true;
            S1.SetActive(true);
            S2.SetActive(true);
            S3.SetActive(true);
            S4.SetActive(true);
            animator1.SetBool("mirarDerecha", true);
            sound1.clip = clips[0];
            animator2.SetBool("atacarFuerte", true);
            sound1.clip = clips[1];
            animator3.SetBool("andarZombie", true);
            sound1.clip = clips[2];
            animator4.SetBool("atacar", true);
            sound1.clip = clips[3];
            sound1.Play();
            sound2.Play();
            sound3.Play();
            sound4.Play();
        }

    }


}
