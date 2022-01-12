using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_control : MonoBehaviour
{
    GameObject line;
    GameObject hidden_mob;
    GameObject hidden_mob2;

    void Start()
    {
        line = GameObject.Find("line");
        hidden_mob = GameObject.Find("mob_terror");
        hidden_mob.SetActive(false);
        hidden_mob2 = GameObject.Find("mob_terror1");
        hidden_mob2.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        line.SetActive(false);
        hidden_mob.SetActive(true);
        hidden_mob2.SetActive(true);
    }
}
