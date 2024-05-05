using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValidarTutorial : MonoBehaviour
{
    public TextMeshProUGUI cajaDeTexto;
    public TextMeshProUGUI pantalla;
    private Button botonValidar;
    // Start is called before the first frame update
    void Start()
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
            pantalla.text = "Has tecleado: " + textoCaja;
        }
    }
}
