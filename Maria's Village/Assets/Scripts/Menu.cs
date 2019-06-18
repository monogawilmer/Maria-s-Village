using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel;
    private bool paused = false;

    void Start()
    {
        Panel.SetActive(false);   
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            Panel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
