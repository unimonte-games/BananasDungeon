using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //UNITY_WSA
    public Dados.PlayerIndice playerIndice;
    ControleDeAnimacao ctrAnim;
    public float h = 0, v = 0;
    public float hv = 0;
    public float vel = 5;
    public float slow = 0.7f;
    float redutor = 1;
    public float aceleracao = 0;
    public float velAceleracao = .5f;


    void Awake()
    {
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

        if (Input.GetKeyDown(KeyCode.LeftControl))
            redutor = slow;
        else
            redutor = 1;

        hv = Mathf.Abs(h) + Mathf.Abs(v);
        if (!ctrAnim.Morto && !ctrAnim.Atacando && Mathf.Abs(h) + Mathf.Abs(v) > .4f)
        {
            if (aceleracao < 1)
                aceleracao += velAceleracao;
            else
                aceleracao = 1;

            var look = new Vector3(h, 0, v) + transform.position;

            transform.LookAt(look);

            transform.Translate(Vector3.forward * ctrAnim.Velocidade(velMovimento() * redutor) * (vel * aceleracao) * Time.deltaTime);
            
        }
    }

    void Update()
    {
        if (ctrAnim.Morto)
            return;

        if (velMovimento() == 0)
            ctrAnim.Idle(-1);
        else
            ctrAnim.Andar();

        if (Input.GetAxisRaw(playerIndice.ToString() + "Right/Left") != 0)
            print("Right/Left: " + Input.GetAxisRaw(playerIndice.ToString() + "Right/Left"));

        if (Input.GetAxisRaw(playerIndice.ToString() + "Up/Down") != 0)
            print("Up/Down: " + Input.GetAxisRaw(playerIndice.ToString() + "Up/Down"));

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

        if (Input.GetAxis(playerIndice.ToString() + "LT") != 0f)
            print("LT");

        if (Input.GetAxis(playerIndice.ToString() + "RT") != 0f)
            print("RT");

        if (Input.GetButtonDown(playerIndice.ToString() + "RSB3"))
            print("RSB3");

        if (Input.GetButtonDown(playerIndice.ToString() + "LSB3"))
            print("LSB3");
    }

    float velMovimento()
    {
        if (Mathf.Abs(v) + Mathf.Abs(h) < 0.3f)
        {
            aceleracao = 0;
            return 0;
        }

        if (Mathf.Abs(v) + Mathf.Abs(h) > 1)
            return 1f;

        return Mathf.Abs(v) + Mathf.Abs(h);
    }
}