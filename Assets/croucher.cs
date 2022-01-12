using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class croucher : MonoBehaviour
{
    GameObject Player;
    FirstPersonController player_script;
    int crouch_limit;

    void Start()
    {
        Player = GameObject.Find("FirstPersonController");
        player_script = Player.GetComponent<FirstPersonController>();
        player_script.isCrouched = false;
        crouch_limit = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (crouch_limit == 1)
        {
            player_script.isCrouched = false;
            player_script.Crouch();
            crouch_limit = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (crouch_limit == 0)
        {
            player_script.isCrouched = true;
            player_script.Crouch();
            crouch_limit = 1;
        }
    }
}
