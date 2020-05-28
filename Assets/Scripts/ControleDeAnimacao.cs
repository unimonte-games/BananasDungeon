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
        anim.SetInteger("Ataque", atk);
        anim.SetInteger("Move", 2);
    }

    public void Morrendo()
    {

    }

    #region Evento de animação
    public void IniciouAtaque()
    {
        print("Iniciou o Ataque");
        Atacando = true;
    }

    public void ParouAtaque()
    {
        print("Terminou o Ataque");
        Atacando = false;
    }
    #endregion
}