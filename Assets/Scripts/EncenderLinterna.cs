using UnityEngine;

public class EncenderLinterna : MonoBehaviour
{
    public GameObject luz;

    public void encenderLinterna()
    {
        luz.SetActive(true);
    }

    public void apagarLinterna()
    {
        luz.SetActive(false);
    }

   
}
