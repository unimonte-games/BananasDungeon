using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    Light luz;
    public bool estadoInterruptor = false;

    void Awake()
    {
        luz = GetComponent<Light>();
        //luz.enabled = false;
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
        if (Input.GetButton("A") &&  !estadoInterruptor)
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
    }
}