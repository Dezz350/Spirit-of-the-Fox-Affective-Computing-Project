using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidden_path1 : MonoBehaviour
{
    public int hidden_limit;

    void Start()
    {
        hidden_limit = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        hidden_limit = 1;
    }
}
