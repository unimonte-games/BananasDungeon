using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public enum MododeSpawn { Queda, Aparecer};
    public GameObject Inimigo;
    public int quantidade;
    public float delaySpawn;
    public MododeSpawn TipoSpawn;

    public IEnumerator IniciaSpawn()
    {
        for (int q = 0; q < quantidade; q++)
        {
            var ini = Inimigo.GetComponent<Inimigo>();
            Vector3 pos = transform.position;
            switch (TipoSpawn)
            {
                case MododeSpawn.Aparecer:
                    pos = transform.position;
                    break;
                case MododeSpawn.Queda:
                    pos = new Vector3(transform.position.x, 5, transform.position.z);
                    break;
            }
            var gbj = Instantiate(Inimigo, pos, Quaternion.identity);
            gbj.SetActive(true);
            yield return new WaitForSeconds(delaySpawn);
        }
    }
}