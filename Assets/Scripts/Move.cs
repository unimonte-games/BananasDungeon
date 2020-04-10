using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController chtr;
    public Vector3 vMove = Vector3.zero;
    public float h, v, vel = 20;
    public Rigidbody rb;
    public float slow = 0.7f;
    float redutor = 1;

    void Awake()
    {
        if (!chtr)
            chtr = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        var pos = transform.position;
        var look = new Vector3(pos.x + h, transform.position.y, pos.z + v);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bala = Instantiate(Resources.Load<GameObject>("Bala"), transform.position + transform.forward, transform.rotation);
            bala.transform.GetComponent<Projetil>().Atirador = gameObject;
            bala.SetActive(true);
        }

        transform.LookAt(look);
        redutor = 1;
        if (Input.GetKey(KeyCode.LeftControl))
            redutor = slow;
        transform.Translate(Vector3.forward * (velMovimento() * redutor) * vel * Time.deltaTime);
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
}