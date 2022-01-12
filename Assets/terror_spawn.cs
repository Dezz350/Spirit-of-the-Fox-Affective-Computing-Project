using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class terror_spawn : MonoBehaviour
{
    GameObject Player;
    float distance;
    GameObject Terror;
    List<GameObject> spawners = new List<GameObject>();
    string terror_spawner;
    GameObject spawner;
    Vector3 current_spawner;

    int spawner_picker;

    GameObject terror_volume;
    GameObject healthbar;
    int barlocker;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("FirstPersonController");
        Terror = GameObject.Find("terror_boss");
        terror_volume = GameObject.Find("terror_volume");
        healthbar = GameObject.Find("Healthbar");
        spawner_picker = 1;
        distance = 0;
        barlocker = 0;
        StartCoroutine(TimeLockedEnding(90));

        for(int i = 0; i < 8; i++)
        {
            terror_spawner = "spawn"+(i+1);
            spawner = GameObject.Find(terror_spawner);
            spawners.Add(spawner);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawner_picker = Random.Range(0,8);
        if(spawners[spawner_picker].GetComponent<Renderer>().isVisible)
        {
            current_spawner = spawners[spawner_picker].transform.position;
            current_spawner.y = Terror.transform.position.y;
        }

        distance = Vector3.Distance(Player.transform.position,Terror.transform.position);
        if(distance>30)
        {
            Terror.transform.position = current_spawner;
        }

        if(distance<10)
        {
            terror_volume.GetComponent<PostProcessVolume>().enabled = true;
        }
        else
        {
            terror_volume.GetComponent<PostProcessVolume>().enabled = false;
        }

        if(distance<8 && barlocker == 0)
        {
            barlocker = 1;
            StartCoroutine(TimeLockedBar(0.5f));
            healthbar.GetComponent<Slider>().value -= 30;
            PersistentManager.Instance.Health = healthbar.GetComponent<Slider>().value;
        }

        IEnumerator TimeLockedBar (float sec)
        {
            yield return new WaitForSeconds(sec);
            barlocker = 0;
        }   

        if(healthbar.GetComponent<Slider>().value <= 0)
        {
            SceneManager.LoadScene(5);
        }

    }

    IEnumerator TimeLockedEnding (int sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(5);
    }
}
