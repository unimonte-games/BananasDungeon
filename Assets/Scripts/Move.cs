using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController chtr;
    public Vector3 vMove = Vector3.zero;
    public float h, v, xPos, zPos, vel = 20;
    //public float xPos, zPos, vel = 20;
    public GameObject chaoNovo, chaoAtual;
    public Rigidbody rb;
    public float slow = 1;
    float redutor = 1;

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
        // vMove.x = Input.GetAxis("Horizontal");
        // vMove.y = Input.GetAxis("Vertical");

        var pos = transform.position;
        var look = new Vector3(pos.x + h, transform.position.y, pos.z + v);
        // var look = new Vector3(pos.x + vMove.x, transform.position.y, pos.z + vMove.y);

        if (Input.GetKeyDown(KeyCode.Space))
            transform.position = new Vector3(0, 1, 0);

        transform.LookAt(look);
        //print(velMovimento());
        redutor = 1;
        if (Input.GetKey(KeyCode.LeftControl))
            redutor = slow;
        transform.Translate(Vector3.forward * (velMovimento() * redutor));
        // print(Input.acceleration.x + "/b" + Input.acceleration.y);
    }

    float velMovimento()
    {
        // float _h = vMove.x;
        // float _v = vMove.y;
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