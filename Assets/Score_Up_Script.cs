using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Up_Script : MonoBehaviour
{
    GameObject score;
    int add_score;

    public AudioClip pickup_sound;

    void Start()
    {
        score = GameObject.Find("score");
        add_score = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(pickup_sound,transform.position);
        add_score = int.Parse(score.GetComponent<Text>().text) + 1;
        score.GetComponent<Text>().text = "" + add_score;
        Destroy(gameObject);
    }
}
