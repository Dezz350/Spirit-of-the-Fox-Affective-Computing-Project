using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Up_Script : MonoBehaviour
{
    GameObject healthbar;

    public AudioClip pickup_sound2;

    void Start()
    {
        healthbar = GameObject.Find("Healthbar");
    }

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(pickup_sound2,transform.position);
        healthbar.GetComponent<Slider>().value += 50;
        Destroy(gameObject);
    }

}
