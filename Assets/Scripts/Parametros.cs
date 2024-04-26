using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Parametros : MonoBehaviour
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

    //Bucles
    public static string claveEnigmaBucle = "reloj";
    public static bool enigmaBuclesResuelto = false;

    //Auxiliares
    public static bool pistaCondicion1_CogidaPrimeraVez = false;
    public static bool puerta2HabitacionCuartoAbierta = false;
    public static bool[] aparatosEncendidos = new bool[2]; //0 el proyector y 1 el monitor de clase.

    //Objetos
    public static ArrayList contenidoOlla = new ArrayList();
    public static ArrayList contenidoOllaBuscado = new ArrayList();
    public static bool enigmaObjetosResuelto = false;

    public static string[] acciones = new string[4];
    public static int[] ejecucionAcciones = new int[4]; //0 es secuencial, 1 repetitivo y 2 palanca sin posicionar correctamente.
    public static string[] accionesCorrectas = new string[4];
    public static int[] ejecucionAccionesCorrectas = new int[4];
    public static bool enigmaObjetosCompletoResuelto = false;  

    void Start()
    {
        contenidoOllaBuscado.Add("OjoVerde");
        contenidoOllaBuscado.Add("OjoVerde");
        contenidoOllaBuscado.Add("Cuerno");
        contenidoOllaBuscado.Add("Cuerno");
        contenidoOllaBuscado.Add("PajaritaRoja");
        contenidoOllaBuscado.Sort();
        for (int i = 0; i < Parametros.acciones.Length; i++)
        {
            acciones[i] = "";
        }
        Parametros.accionesCorrectas[0] = "andarZombie";
        Parametros.accionesCorrectas[1] = "correr";
        Parametros.accionesCorrectas[2] = "serGolpeado";
        Parametros.accionesCorrectas[3] = "morir";
        Parametros.ejecucionAccionesCorrectas[0] = 0;
        Parametros.ejecucionAccionesCorrectas[1] = 1;
        Parametros.ejecucionAccionesCorrectas[2] = 1;
        Parametros.ejecucionAccionesCorrectas[0] = 0;
    }
    
}

