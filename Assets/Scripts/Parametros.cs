using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parametros : MonoBehaviour
{
    public static bool[] cajonesAbiertos = new bool[12];
    public static bool[] armariosAbiertos = new bool[8];
    public static bool[] puertasAbiertas = new bool[2]; //La [0] es la que va de la clase a la habitación. La 1 de la habitación al cuarto.


    public static bool[] soportesBienColocados = new bool[6]; //0 - Byte, 1 - Int, 2 - Bool, 3 - String, 4 - Float, 5 - Char
    public static bool[] notasBienColocados = new bool[6]; //0 - Byte, 1 - Int, 2 - Bool, 3 - String, 4 - Float, 5 - Char

    public static bool enigmaDatosResuelto = false;

}
