using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //UNITY_WSA
    public enum PlayerIndice { P1 = 1, P2 = 2} //teste de muti players
    public PlayerIndice playerIndice;
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
        // h = Input.GetAxis("Right/Left");
        // v = Input.GetAxis("Up/Down");

        var pos = transform.position;
        var look = new Vector3(pos.x + h, transform.position.y, pos.z + v);

        if (Input.GetButtonDown("A"))
        {
            print("A");
            var bala = Instantiate(Resources.Load<GameObject>("Bala"), transform.position + transform.forward, transform.rotation);
            bala.transform.GetComponent<Projetil>().Atirador = gameObject;
            bala.SetActive(true);
        }

        if (Input.GetAxis("Right/Left") != 0)
            print("Right/Left: " + Input.GetAxis("Right/Left"));
        
        if (Input.GetAxis("Up/Down") != 0)
            print("Up/Down: " + Input.GetAxis("Up/Down"));

        if (Input.GetButtonDown("B"))
            print("B");
        
        if (Input.GetButtonDown("Y"))
            print("Y");
        
        if (Input.GetButtonDown("X"))
            print("X");
        
        if (Input.GetButtonDown("Start"))
            print("Start");
        
        if (Input.GetButtonDown("Select"))
            print("Select");
        
        if (Input.GetButtonDown("RB"))
            print("RB");
        
        if (Input.GetButtonDown("LB"))
            print("LB");
        
        if (Input.GetAxis("LT") != 0)
            print(Input.GetAxis("LT"));
        
        if (Input.GetAxis("RT") != 0)
            print(Input.GetAxis("RT"));
        
        if (Input.GetButtonDown("RB3"))
            print("RB3");
        
        if (Input.GetButtonDown("LB3"))
            print("LB3");

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