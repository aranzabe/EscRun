using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValidarClave : MonoBehaviour
{
    public TextMeshProUGUI cajaDeTexto;
    public TextMeshProUGUI pantalla;
    private Button botonValidar;
    // Start is called before the first frame update

    private void Start()
    {
        botonValidar = GetComponent<Button>();
        botonValidar.onClick.AddListener(validarClave);
    }
    public void validarClave()
    {
        string textoCaja = cajaDeTexto.text;
        if (!string.IsNullOrEmpty(textoCaja))
        {
            textoCaja = textoCaja.Substring(0, textoCaja.Length - 1);
            //pantalla.text = "L1: " + textoCaja.Length + " L2: " + "reloj".Length;
            if (textoCaja == "reloj")
            {
                Parametros.enigmaBuclesResuelto = true;
                pantalla.text = "Enigma 3 resuelto!!!";
            }
            else
            {
                pantalla.text = "Has fallado";
                Invoke("textoInicial", 1f);
            }
        } 
    }

    private void textoInicial()
    {
        pantalla.text = "Teclea la clave. No pierdas demasiado tiempo...";
    }
}
