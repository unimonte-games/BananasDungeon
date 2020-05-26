using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //UNITY_WSA
    public enum PlayerIndice { P1 = 1, P2, P3, P4} //teste de multiplayers
    public PlayerIndice playerIndice;
    CharacterController chtr;
    ControleDeAnimacao ctrAnim;
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
        ctrAnim = GetComponent<ControleDeAnimacao>();
    }
    
    void Update()
    {
        h = Input.GetAxis(playerIndice.ToString() + "Horizontal");
        v = Input.GetAxis(playerIndice.ToString() + "Vertical");
        // h = Input.GetAxis("Right/Left");
        // v = Input.GetAxis("Up/Down");

        if (!ctrAnim.Atacando)
        {
            var pos = transform.position;
            var look = new Vector3(pos.x + h, transform.position.y, pos.z + v);


            transform.LookAt(look);
            redutor = 1;

            if (Input.GetKey(KeyCode.LeftControl))
                redutor = slow;

            print(Time.deltaTime);
            transform.Translate(Vector3.forward * ctrAnim.Velocidade(velMovimento() * redutor) * vel * Time.deltaTime);
        }

        if (velMovimento() == 0)
            ctrAnim.Idle();
        else
            ctrAnim.Andar();

        if (Input.GetAxis("Right/Left") != 0)
            print("Right/Left: " + Input.GetAxis("Right/Left"));
        
        if (Input.GetAxis("Up/Down") != 0)
            print("Up/Down: " + Input.GetAxis("Up/Down"));

        if (Input.GetButtonDown("A"))
        {
            print("A");
            ctrAnim.Ataque(0);
        }

        if (Input.GetButtonDown("B"))
        {
            print("B");
            ctrAnim.Ataque(1);
        }
        
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
    }

    // void FixedUpdate()
    // {

    //     float vel = rb.velocity.magnitude;

    //     //limite de velocidade
    //     rb.AddForce((move * forcemove)/ (vel*2+1));
    //     anim.SetFloat("Velocity", vel);

    //     //velocidade sem y
    //     Vector3 velwoy = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    //     //drag manual
    //     rb.AddForce(-velwoy * drag);
    // }

    float velMovimento()
    {
        float _h = h;
        float _v = v;

        if (Mathf.Abs(_v) + Mathf.Abs(_h) < 0.3f)
            return 0;

        if (Mathf.Abs(_v) + Mathf.Abs(_h) > 1)
            return 1f;

        return Mathf.Abs(_v) + Mathf.Abs(_h);
    }
}