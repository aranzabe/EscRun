using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Parametros : MonoBehaviour
{
    //Classroom
    public static bool[] cajonesAbiertos = new bool[12];
    public static bool[] armariosAbiertos = new bool[8];
    public static bool[] puertasAbiertas = new bool[2]; //La [0] es la que va de la clase a la habitación. La 1 de la habitación al cuarto.

    //Tipos de datos
    public static bool[] soportesBienColocados = new bool[6]; //0 - Byte, 1 - Int, 2 - Bool, 3 - String, 4 - Float, 5 - Char
    public static bool[] notasBienColocados = new bool[6]; //0 - Byte, 1 - Int, 2 - Bool, 3 - String, 4 - Float, 5 - Char
    public static bool enigmaDatosResuelto = false;

    //Condicionales
    public static bool enigmaCondicionalesResuelto = false;
    public static bool[] soportesInterruptoresBienColocados = new bool[6]; //Para saber si están bien colocados.
    public static bool[] enZocalo = new bool[6]; //Esto es para ver si los botones de las condiciones están en el zócalo y se activa la posibilidad de pulsar el botón.
    public static bool[] botonCondicionPulsado = new bool[5]; //True o false según si están pulsados o no. Se usará para la solución del enigma 2 y para cambiar el material de los interruptores.
    public static bool[] solucionEnigmaCondiciones = { true, false, true, true, false }; //Para comprobar si están bien pulsados. Al dar al botón de resolver se comprobará con esto.

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

    //Enigma final - CPU
    public static bool[] piezasCPUColocadas = new bool[4]; //0 - RAM1, 1 - RAM2, 2 - CPU, 3 - Disipador.
    public static bool ordenadorEncendido = false;
    public static bool botonEncendidoDisponible = false;

    private static bool yaInicializado = false;

    //Para la escena final
    public static string textoFinal = "";
    public static int segundos = 59;
    public static int minutos = 59;

    public static bool todosComponentesCPUOk()
    {
        bool ok = true;
        for (int i = 0; i < piezasCPUColocadas.Length; i++)
        {
            if (piezasCPUColocadas[i] == false)
            {
                ok = false;
            }
        }
        return ok;
    }

    void Start()
    {
        if (!yaInicializado)
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

            yaInicializado = true;
        }
    }

   
}

