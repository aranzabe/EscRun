using TMPro;
using UnityEngine;

/**
 * Este script es para comprobar si cada cubo está correctamente puesto en su soporte.
 */
public class SoporteDatosScript : MonoBehaviour
{
    public GameObject soporte;
    private string numeroSoporte;
    public TextMeshProUGUI texto;

    // Start is called before the first frame update
    void Start()
    {
        string nombreSoporte = soporte.name;
        string[] partesNombreCajon = nombreSoporte.Split('_');
        numeroSoporte = partesNombreCajon[2];
        texto.text = numeroSoporte;
    }

    private void OnTriggerEnter(Collider other)
    {
        //texto.text = texto.text + "Enter: ";
        string cuboNombre = other.tag;
        string[] partesNombreCubo = cuboNombre.Split('_');
        //texto.text = texto.text + " -- " + partesNombreCubo[2];
        if (numeroSoporte == partesNombreCubo[2])
        {
            Parametros.soportesBienColocados[int.Parse(numeroSoporte)] = true;
        }
        else
        {
            Parametros.soportesBienColocados[int.Parse(numeroSoporte)] = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //texto.text = "Exit";
    }
}
