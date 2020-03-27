using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController chtr;
    public float h, v, xPos, zPos, vel = 0.5f;
    public GameObject chaoNovo, chaoAtual;

    void Awake()
    {
        if (!chtr)
            chtr = GetComponent<CharacterController>();
        chaoAtual = GameObject.Find("Plane");
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal") * vel;
        v = Input.GetAxis("Vertical") * vel;
        //xPos = Time.deltaTime * h;
        //zPos = Time.deltaTime * v;

        //transform.position = new Vector3(xPos, 0, zPos);

        transform.Translate(h, 0, v);

        if (Input.GetButtonDown("Fire2"))
        {
            print("oi eu sou o pulo!!");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(0, 1, 0);
            vel = 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject != chaoAtual)
        {
            chaoAtual = collision.gameObject;
            chaoNovo = null;
        }
    }
}