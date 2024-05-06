using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionesPistas : MonoBehaviour
{
    public GameObject pistas1;
    public GameObject pistas2;
    public GameObject pistas3;
    public GameObject pistas4;
    public GameObject pistas4a;
    public GameObject pistas5;
    
    public void seleccionarPista()
    {
        if (!Parametros.enigmaDatosResuelto)
        {
            pistas1.SetActive(true);
        } else
        {
            if (!Parametros.enigmaCondicionalesResuelto)
            {
                pistas2.SetActive(true);
            } else
            {
                if (!Parametros.enigmaBuclesResuelto)
                {
                    pistas3.SetActive(true);
                } else
                {
                    if (!Parametros.enigmaObjetosResuelto)
                    {
                        pistas4.SetActive(true);
                    }
                    else
                    {
                        if (!Parametros.enigmaObjetosCompletoResuelto)
                        {
                            pistas4a.SetActive(true);
                        } else
                        {
                            pistas5.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
