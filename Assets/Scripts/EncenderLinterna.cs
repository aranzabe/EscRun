using UnityEngine;

public class EncenderLinterna : MonoBehaviour
{
    public GameObject luz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void encenderLinterna()
    {
        luz.SetActive(true);
    }

    public void apagarLinterna()
    {
        luz.SetActive(false);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.tag);
    //    if (collision.gameObject.CompareTag("Player"))
    //    {

    //    }
    //    luz.SetActive(true);
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    luz.SetActive(false);
    //}
}
