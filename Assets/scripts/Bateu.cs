using UnityEngine;
using UnityEngine.SceneManagement;

public class Bateu : MonoBehaviour
{
    [SerializeField]bool bogos;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bogos = true;
        }
    }

    public void Update()
    {
        if (bogos == true)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
