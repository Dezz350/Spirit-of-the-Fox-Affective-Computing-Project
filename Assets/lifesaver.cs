using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifesaver : MonoBehaviour
{
    GameObject healthbar;

    void Start()
    {
        healthbar = GameObject.Find("Healthbar");
    }

    // Update is called once per frame
    void Update()
    {
        PersistentManager.Instance.Health = healthbar.GetComponent<Slider>().value;
    }
}
