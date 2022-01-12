using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSaver : MonoBehaviour
{
    GameObject Score;

    void Start()
    {
        Score = GameObject.Find("score");
        Score.GetComponent<Text>().text = "" + PersistentManager.Instance.Score;
    }

    // Update is called once per frame
    void Update()
    {
        PersistentManager.Instance.Score = int.Parse(Score.GetComponent<Text>().text);
    }
}
