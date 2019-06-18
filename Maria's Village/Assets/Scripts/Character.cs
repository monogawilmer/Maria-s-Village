using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    [Header("Velocidad de movimiento:")] [SerializeField] private float speed;

    [Header("Fuerza de salto")] [Tooltip("La fuerza debe ser una magnitud grande")]public float jumpForce;
    
    private Rigidbody2D _rigidbody;
    private Animator anim;
    
    [HideInInspector]
    public float _distGround;

    private bool isOnGround;
    private int saltos;
    public AudioClip death;
    public AudioClip  salto;
    public AudioClip win;
    private AudioSource playSound;
    public bool grounded; //Para la animación del personaje.
    
    // Start is called before the first frame update
    void Start()
    {
        playSound = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
        isOnGround = false;
        saltos = 0;

    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            isOnGround = true;
            saltos = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            isOnGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KillZone"))
        {
            playSound.PlayOneShot(death, 5f);
            System.Threading.Thread.Sleep(1000);
            Scene escena = SceneManager.GetActiveScene();
            SceneManager.LoadScene(escena.name);
            
        }
        else if (other.CompareTag("WinZone"))
        {
            playSound.PlayOneShot(win, 10f);
            System.Threading.Thread.Sleep(9000);
            SceneManager.LoadScene("Titulo");
        }   
    }

    private void Update()
    {
        //anim.SetFloat("speed",Mathf.Abs(_rigidbody.velocity.x));
        //anim.SetBool("grounded",grounded);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        Vector2 movimiento = new Vector2(movHorizontal,0f);
        _rigidbody.AddForce(movimiento * speed);
        
        //saltar con un boton
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            playSound.clip=salto;
            playSound.PlayOneShot(salto);
            _rigidbody.AddForce(Vector2.up * jumpForce * 100f, ForceMode2D.Force);
            saltos++;
        }
        else if (isOnGround == false && saltos >0 && saltos <2 && Input.GetButtonDown("Jump"))
        { 
            playSound.PlayOneShot(salto);
            _rigidbody.AddForce(Vector2.up * jumpForce * 100f, ForceMode2D.Force); 
            saltos++;
        }

        
    }
}
