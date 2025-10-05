using UnityEngine;

public class NhomNhom : MonoBehaviour
{

    [SerializeField] float limiteX = 16f;
    [SerializeField] float limiteY = 8.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(Random.Range(-limiteX, limiteX), Random.Range(-limiteY, limiteY), 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent.GetComponent<GoodSnake>().Rabasso();
            transform.position = new Vector3(Random.Range(-limiteX, limiteX), Random.Range(-limiteY, limiteY), 0);
        }   
    }

}
