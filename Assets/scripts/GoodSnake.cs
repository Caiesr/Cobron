using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

enum Direction
{
    up,
    right,
    down,
    left
}

public class GoodSnake : MonoBehaviour
{
    DeuALoucaNoGerente gerente;
    Direction virado = Direction.right;
    public GameObject headPrefab;
    public GameObject tailPrefab;
    List<GameObject> tail = new List<GameObject>();
    public float baseSpeed = 5f;
    public float speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gerente = GameObject.Find("gerente").GetComponent<DeuALoucaNoGerente>();
        GameObject head = Instantiate(headPrefab, transform.position, UnityEngine.Quaternion.identity);
        tail.Add(head);
        head.transform.parent = transform;
    }

    void Update()
    {
        RotationInput();
        ParaFrente();
        UpdateTailPosition();
    }


    void RotateAntiHorario()
    {
        virado = (Direction)(((int)virado + 3) % 4);
    }
    void RotateHorario()
    {
        virado = (Direction)(((int)virado + 1) % 4);
    }


    void ParaFrente()
    {
        UnityEngine.Vector3 moveDirection = UnityEngine.Vector3.zero;
        switch (virado)
        {
            case Direction.up:
                moveDirection = UnityEngine.Vector3.up;
                break;
            case Direction.down:
                moveDirection = UnityEngine.Vector3.down;
                break;
            case Direction.left:
                moveDirection = UnityEngine.Vector3.left;
                break;
            case Direction.right:
                moveDirection = UnityEngine.Vector3.right;
                break;
        }
        transform.position += moveDirection * speed * Time.deltaTime;
    }



    void RotationInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            RotateAntiHorario();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            RotateHorario();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            float newSpeed = baseSpeed * 2;
            speed = newSpeed;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            speed = baseSpeed;
        }
    }


    public void Rabasso()
    {
        UnityEngine.Vector3 newPosition = UnityEngine.Vector3.zero;
        switch (virado)
        {
            case Direction.up:
                newPosition = tail[tail.Count - 1].transform.position - new UnityEngine.Vector3(0, 1, 0);
                break;
            case Direction.down:
                newPosition = tail[tail.Count - 1].transform.position - new UnityEngine.Vector3(0, 1, 0);
                break;
            case Direction.left:
                newPosition = tail[tail.Count - 1].transform.position - new UnityEngine.Vector3(1, 0, 0);
                break;
            case Direction.right:
                newPosition = tail[tail.Count - 1].transform.position - new UnityEngine.Vector3(1, 0, 0);
                break;
        }
        GameObject newTail = Instantiate(tailPrefab, newPosition, UnityEngine.Quaternion.identity);
        tail.Add(newTail);
    }


    void UpdateTailPosition()
    {
        float distanciaSegmento = 1.2f;
        for (int i = 1; i < tail.Count; i++)
        {
            GameObject segmentoAtual = tail[i];
            GameObject segmentoNaFrente = tail[i - 1];
            UnityEngine.Vector3 newPosition = segmentoNaFrente.transform.position -
             (segmentoNaFrente.transform.position - segmentoAtual.transform.position).normalized * distanciaSegmento;

            segmentoAtual.transform.position = UnityEngine.Vector3.Lerp(segmentoAtual.transform.position, newPosition, Time.deltaTime * 30);
        }
    }

}
