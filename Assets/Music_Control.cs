using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PersistentManager.Instance.Control == 4)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
