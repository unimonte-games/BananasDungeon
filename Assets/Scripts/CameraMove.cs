using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float x = 0, y = 17, z = -18;
    public GameObject Player;


    void Awake()
    {
        if (!Player)
            Player = FindObjectOfType<Move>().gameObject;
    }

    void Update()
    {
        var pos = Player.transform.position;
        transform.position = new Vector3(pos.x + x, pos.y + y, pos.z + z);
    }
}