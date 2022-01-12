using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class To_next_scene_7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeLockedExit(7));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeLockedExit(int sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(7);
    }
    
}
