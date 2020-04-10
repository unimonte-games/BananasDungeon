using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoIA : MonoBehaviour
{
    public GameObject Player;
    public float velocidade = 12;

    void Awake()
    {
        Player = FindObjectOfType<Move>().gameObject;
    }
    void Start()
    {
        transform.LookAt(Player.transform.position);
    }

    void Update()
    {
        transform.LookAt(Player.transform.position);
        if ((Player.transform.position - transform.position).magnitude > 2)
            transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
    }
}