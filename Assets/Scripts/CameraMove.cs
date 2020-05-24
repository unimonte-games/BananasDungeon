using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float x = 0, y = 17, z = -18;
    public List<GameObject> Players = new List<GameObject>();


    void Awake()
    {
        if (Players.Count == 0)
        {
            var p = FindObjectsOfType<Move>();
            for (int x = 0; x < p.Length; x++)
            {
                Players.Add(p[x].gameObject);
            }
        }
    }

    void Update()
    {
        if (Players.Count == 1)
        {
            var pos = Players[0].transform.position;
            transform.position = new Vector3(pos.x + x, pos.y + y, pos.z + z);
        }
    }
}