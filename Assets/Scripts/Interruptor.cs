using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    
    public GameObject Portas;
    Light luz;
    bool estadoInterruptor = false;
    Animator anim;

    public enum Alavanca
    {
        Parado = 0,
        Ativar,
        Desativar//caso queiram q seja desativado
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        luz = GetComponent<Light>();
        luz.color = Color.white;
    }

    void OnTriggerEnter (Collider colisor)
    {
        if (colisor.tag == "Player")
        {
            if (estadoInterruptor)
                luz.color = Color.green;
            else
                luz.color = Color.red;
        }
    }

    void OnTriggerStay (Collider colisor)
    {
        if (Input.GetButton("B") &&  !estadoInterruptor)
            AtivarInterruptor();
    }

    void OnTriggerExit (Collider colisor)
    {
        if (colisor.tag == "Player")
        {
            if (estadoInterruptor)
                luz.color = Color.green;
            else
                luz.color = Color.red;
        }
    }

    public void AtivarInterruptor()
    {
        print("Ativando interruptor");
        estadoInterruptor = true;
        luz.color = Color.green;
        anim.SetInteger("Alavanca", (int)Alavanca.Ativar);
    }
}