using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar_setter : MonoBehaviour
{
    GameObject healthbar;

    void Start()
    {
        healthbar = GameObject.Find("Healthbar");
        healthbar.GetComponent<Slider>().value = PersistentManager.Instance.Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
