using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class GameHandler : MonoBehaviour
{
    private float health;

    public float Health
    {
        get { return health; }
        set { health = value;  }
    }
    
    private Rigidbody2D _rigidbody;
    public AudioClip death;
    private AudioSource playSound;
    
    [SerializeField] private Barra healthBar;
    private void Start()
    {
        playSound = GetComponent<AudioSource>();
        health = 1f;
        FunctionPeriodic.Create(() =>
        {
            if (health > .01f)
            {
                health -= .001f;
                healthBar.SetSize(health);

                if (health < .3f)
                {
                    if ((health * 100f) % 3 == 0)
                    {
                        healthBar.SetColor(Color.white);
                    }
                    else
                    {
                        healthBar.SetColor(Color.red);
                    }
                }
            }
        }, 0.03f);
    }

    private void FixedUpdate()
    {
        if (health <.1f)
        {
            playSound.PlayOneShot(death, 15f);
            System.Threading.Thread.Sleep(1000);
            Scene escena = SceneManager.GetActiveScene();
            SceneManager.LoadScene(escena.name);
        }
    }
}
