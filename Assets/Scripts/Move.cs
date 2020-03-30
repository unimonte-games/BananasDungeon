using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController chtr;
    public float h, v, xPos, zPos, vel = 20;
    public GameObject chaoNovo, chaoAtual;
    public Rigidbody rb;

    void Awake()
    {
        if (!chtr)
            chtr = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        chaoAtual = GameObject.Find("Plane");
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        var pos = transform.position;
        var look = new Vector3(pos.x + h, transform.position.y, pos.z + v);
        transform.LookAt(look);
        print(velMovimento());
        transform.Translate(Vector3.forward * velMovimento());

        if (Input.GetButtonDown("Fire2"))
        {
            print("oi eu sou o dash!!");
            dash();
        }

        if (Input.GetKeyDown(KeyCode.Space))
            transform.position = new Vector3(0, 1, 0);
    }

    void dash()
    {
        //rgb.AddForce(Vector3.forward * 50);
        rb.AddForce(Vector3.forward, ForceMode.Impulse);
    }

    float velMovimento()
    {
        float _h = h;
        float _v = v;

        if (_v == 1 || _h == 1)
            return 1f;
        if (Mathf.Abs(_v) + Mathf.Abs(_h) >= 1)
            return 1f;
        return Mathf.Abs(_v) + Mathf.Abs(_h);
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