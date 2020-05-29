using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //UNITY_WSA
    public enum PlayerIndice { P1 = 1, P2, P3, P4} //teste de multiplayers
    public PlayerIndice playerIndice;
    ControleDeAnimacao ctrAnim;
    public float h, v, vel = 20;
    public Rigidbody rb;
    public float slow = 0.7f;
    float redutor = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ctrAnim = GetComponent<ControleDeAnimacao>();
    }
    
    void FixedUpdate()
    {
        h = Input.GetAxis(playerIndice.ToString() + "Horizontal");
        v = Input.GetAxis(playerIndice.ToString() + "Vertical");
        h += Input.GetAxis(playerIndice.ToString() + "Right/Left");
        v += Input.GetAxis(playerIndice.ToString() + "Up/Down");

        h += Input.GetAxis("Horizontal");
        v += Input.GetAxis("Vertical");

        if (!ctrAnim.Atacando && Mathf.Abs(h + v) > .2f)
        {

            //Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical"));
            //rigidbody.MovePosition(transform.position + direction * movementSpeed * Time.fixedDeltaTime);

            // Vector3 look = new Vector3(h, 0, v) + transform.position;
            // transform.LookAt(look);
            // rb.MovePosition(transform.forward + look * vel * redutor * Time.fixedDeltaTime);
            // ctrAnim.Velocidade(velMovimento());

            //atual sistema dew movimentação
            var pos = transform.position;
            var look = new Vector3(pos.x + h, transform.position.y, pos.z + v);


            transform.LookAt(look);
            redutor = 1;

            if (Input.GetKey(KeyCode.LeftControl))
                redutor = slow;

            transform.Translate(Vector3.forward * ctrAnim.Velocidade(velMovimento() * redutor) * vel * Time.deltaTime);
        }
    }

    void Update()
    {
        if (velMovimento() == 0)
            ctrAnim.Idle();
        else
            ctrAnim.Andar();

        if (Input.GetAxis(playerIndice.ToString() + "Right/Left") != 0)
            print("Right/Left: " + Input.GetAxis(playerIndice.ToString() + "Right/Left"));
        
        if (Input.GetAxis(playerIndice.ToString() + "Up/Down") != 0)
            print("Up/Down: " + Input.GetAxis(playerIndice.ToString() + "Up/Down"));

        if (Input.GetButtonDown(playerIndice.ToString() + "A") || Input.GetKeyDown(KeyCode.Z))
        {
            print("A");
            ctrAnim.Ataque(0);
        }

        if (Input.GetButtonDown(playerIndice.ToString() + "B") || Input.GetKeyDown(KeyCode.X))
            print("B");
        
        if (Input.GetButtonDown(playerIndice.ToString() + "X") || Input.GetKeyDown(KeyCode.C))
        {
            print("X");
            ctrAnim.Ataque(1);
        }
        
        if (Input.GetButtonDown(playerIndice.ToString() + "Y") || Input.GetKeyDown(KeyCode.V))
            print("Y");
        
        if (Input.GetButtonDown(playerIndice.ToString() + "Start") || Input.GetKeyDown(KeyCode.Return))
            print("Start");
        
        if (Input.GetButtonDown(playerIndice.ToString() + "Select"))
            print("Select");
        
        if (Input.GetButtonDown(playerIndice.ToString() + "RB"))
            print("RB");
        
        if (Input.GetButtonDown(playerIndice.ToString() + "LB"))
            print("LB");
        
        if (Input.GetAxis(playerIndice.ToString() + "LT") != 0)
            print("LT");
        
        if (Input.GetAxis(playerIndice.ToString() + "RT") != 0)
            print("RT");
        
        if (Input.GetButtonDown(playerIndice.ToString() + "RB3"))
            print("RB3");
        
        if (Input.GetButtonDown(playerIndice.ToString() + "LB3"))
            print("LB3");
    }

    float velMovimento()
    {
        if (Mathf.Abs(v) + Mathf.Abs(h) < 0.3f)
            return 0;

        if (Mathf.Abs(v) + Mathf.Abs(h) > 1)
            return 1f;

        return Mathf.Abs(v) + Mathf.Abs(h);
    }
}