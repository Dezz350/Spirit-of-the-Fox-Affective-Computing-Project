using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Control : MonoBehaviour
{

    void Start()
    {
        gameObject.SetActive(false);
        if(PersistentManager.Instance.Control == 1)
        {
            gameObject.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
