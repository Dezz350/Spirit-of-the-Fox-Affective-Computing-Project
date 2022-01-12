using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager Instance {get; private set;}

    GameObject CurrentPlayer;

    public int Score;
    public float Health;
    public int Control;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        CurrentPlayer = GameObject.Find("FirstPersonController");
    }

    void Update()
    {
        gameObject.transform.position = CurrentPlayer.transform.position;
    }
}
