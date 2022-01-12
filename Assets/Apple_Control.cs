using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_Control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        if(PersistentManager.Instance.Control == 2)
        {
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
