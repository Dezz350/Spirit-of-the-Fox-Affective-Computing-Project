using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPicker : MonoBehaviour
{
    int picker;

    void Start()
    {
        picker = Random.Range(0,5);
        PersistentManager.Instance.Control = picker;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
