using Photon.Pun;
using UnityEngine;

public class Parametros : MonoBehaviourPunCallbacks
{
    //Classroom
    public static bool[] cajonesAbiertos = new bool[12];
    public static bool[] armariosAbiertos = new bool[8];
    public static bool[] puertasAbiertas = new bool[2]; //La [0] es la que va de la clase a la habitaci�n. La 1 de la habitaci�n al cuarto.

    //Tipos de datos
    public static bool[] soportesBienColocados = new bool[6]; //0 - Byte, 1 - Int, 2 - Bool, 3 - String, 4 - Float, 5 - Char
    public static bool[] notasBienColocados = new bool[6]; //0 - Byte, 1 - Int, 2 - Bool, 3 - String, 4 - Float, 5 - Char

    public static bool enigmaDatosResuelto = false;


    //Condicionales
    public static bool enigmaCondicionalesResuelto = false;
    public static bool[] soportesInterruptoresBienColocados = new bool[6]; //Para saber si est�n bien colocados.
    public static bool[] enZocalo = new bool[6]; //Esto es para ver si los botones de las condiciones est�n en el z�calo y se activa la posibilidad de pulsar el bot�n.
    public static bool[] botonCondicionPulsado = new bool[5]; //True o false seg�n si est�n pulsados o no. Se usar� para la soluci�n del enigma 2 y para cambiar el material de los interruptores.
    public static bool[] solucionEnigmaCondiciones = { true, false, true, true, false }; //Para comprobar si est�n bien pulsados. Al dar al bot�n de resolver se comprobar� con esto.

    //Auxiliares
    public static bool pistaCondicion1_CogidaPrimeraVez = false;
    public static bool puerta2HabitacionCuartoAbierta = false;
}

