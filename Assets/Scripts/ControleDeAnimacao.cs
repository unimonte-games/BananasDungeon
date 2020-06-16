using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleDeAnimacao : MonoBehaviour
{
    public enum Estado
    {
        Morte = -1,
        Idle = 0,
        Andando,
        Atacando
    }
    public AudioSource SFX;
    public Animator anim;
    public bool Atacando = false;
    public bool Morto = false;
    

    void Awake()
    {
        anim = GetComponent<Animator>();
        SFX = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    public float Velocidade(float vel)
    {
        anim.SetFloat("Velocidade", vel);
        return vel;
    }

    public void Idle(int idle)
    {
        if (idle == -1)
            idle = Random.Range(0,2);

        anim.SetInteger("Idle", idle);
        anim.SetInteger("Move", (int)Estado.Idle);
    }

    public void Andar()
    {
        anim.SetInteger("Move", (int)Estado.Andando);
    }

    public void Ataque(int atk)
    {
        anim.SetInteger("Ataque", atk);
        anim.SetInteger("Move", (int)Estado.Atacando);
    }

    public void Morte()
    {
        Morto = true;
        int i = Random.Range(0,2);

        anim.SetInteger(Estado.Morte.ToString(), i);
        anim.SetTrigger("Morrer");
        StartCoroutine(GameOver());
    }

    public void Desequipar()
    {
        anim.SetBool(Dados.Armas.Arco.ToString(), false);
        anim.SetBool(Dados.Armas.Espada.ToString(), false);
        anim.SetBool(Dados.Armas.Machado.ToString(), false);
        anim.SetBool(Dados.Armas.Alabarda.ToString(), false);
        anim.SetBool(Dados.Armas.Lanca.ToString(), false);
        anim.SetBool(Dados.Armas.Cajado.ToString(), false);
    }

    public void TrocaArma(Dados.Armas arma)
    {
        Desequipar();
        Idle(1);
        anim.SetBool(arma.ToString(), true);
    }

    public void Selecionar()
    {
        print("Selecionar");
        anim.SetBool("Selecao", true);
        var arma = GetComponent<ControleDeArmas>().arma;
        Desequipar();
        Idle(0);
        anim.SetBool(arma.ToString(), true);
    }

    public void DesSelecionar()
    {
        print("DesSelecionar");
        anim.SetBool("Selecao", true);
        var arma = GetComponent<ControleDeArmas>().arma;
        Desequipar();
        Idle(1);
        anim.SetBool(arma.ToString(), true);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }

    #region Evento de animação
    public void Disparo()
    {
        GameObject arco = null;
        var ctrArmas = GetComponent<ControleDeArmas>();
        for (int x = 0; x < ctrArmas.Arsenal.Length; x++)
        {
            if (ctrArmas.Arsenal[x].Arma == Dados.Armas.Arco)
            {
                arco = ctrArmas.Arsenal[x].Local;
                break;
            }
        }
        var dano = arco.GetComponent<DanoArma>();
        var detector = arco.GetComponent<DetectorDeDano>();

        SFX.PlayOneShot(detector.SomDano);
        var gbj = Instantiate(dano.Flecha, transform.position, transform.rotation);
        gbj.SetActive(true);
    }

    public void IniciouAtaque()
    {
        Atacando = true;
    }

    public void ParouAtaque()
    {
        Atacando = false;
    }
    #endregion
}