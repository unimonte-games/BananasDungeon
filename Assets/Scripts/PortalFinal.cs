
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalFinal : MonoBehaviour
{
    public bool BossMorto = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && BossMorto)
        {
            SceneManager.LoadScene("Jogo");
        }
    }

    public void AtivarPortal()
    {
        BossMorto = true;
        GetComponent<ParticleSystem>().Play();
    }
}