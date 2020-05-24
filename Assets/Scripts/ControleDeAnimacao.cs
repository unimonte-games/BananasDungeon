using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeAnimacao : MonoBehaviour
{
    Animator anim;
    public bool Atacando = false;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public float Velocidade(float vel)
    {
        anim.SetFloat("Velocidade", vel);
        return vel;
    }

    public void Idle()
    {
        int rndIdle = Random.Range(0,2);

        anim.SetInteger("Idle", rndIdle);
        anim.SetInteger("Move", 0);
    }

    public void Andar()
    {
        anim.SetInteger("Move", 1);
    }

    public void Ataque(int atk)
    {
        print("Ataque");
        //Atacando = true;
        anim.SetInteger("Move", 2);
        anim.SetInteger("Ataque", atk);
    }

    public void Apanhando()
    {

    }

    public void Morrendo()
    {

    }

    public void IniciouAtaque()
    {
        Atacando = true;
    }

    public void ParouAtaque()
    {
        Atacando = false;
    }
}