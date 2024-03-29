using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool pulan;
    private bool isFire;
    private bool canFire = true; // Nova variável para controle do disparo
    public GameObject Bowprefab;
    public GameObject Bowprefab2;
    public Transform firePonit;
    public bool Estagio2;
    public bool Estagio3;
    public int jumps = 1;
    public int vida = 3;
    public AudioSource Pulo;
    public AudioSource tiro;
    
    public int maxHealth = 5;
    public int currentHealth;
    public bool isdead;

    public Text healthText;

    private Rigidbody2D rig;
    private Animator anim;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        // Somente chama a função de disparo se estiver no estado Idle
        if (Input.GetKeyDown(KeyCode.F) && !isFire && anim.GetInteger("Transition") == 0)
        {
            StartCoroutine("Fire");
        }
        
        // Somente chama a função de disparo se estiver no estado Idle
        if (Input.GetKeyDown(KeyCode.X) && Estagio2 == true && !isFire && anim.GetInteger("Transition") == 0)
        {
            StartCoroutine("Fire2");
        }
        Move();
        
        Jump();
    }

    private void LateUpdate()
    {
        if (isdead = true)
        { 
            dead();
        }
    }

    void Move()
    {
        float movimento = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movimento * speed, rig.velocity.y);

        if (movimento > 0 && !pulan)
        {
            anim.SetInteger("Transition", 1);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (movimento < 0 && !pulan)
        {
            anim.SetInteger("Transition", 1);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (movimento == 0 && !pulan && !isFire)
        {
            anim.SetInteger("Transition", 0);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (jumps > 0)
            {
                pulan = true;
                if (jumps == 1 || jumps == 2)
                {
                    anim.SetInteger("Transition", 2);
                    rig.velocity = new Vector2(rig.velocity.x, 0); // Define a velocidade Y como zero para um pulo mais consistente
                    rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    jumps--; // Decrementa o contador de pulos
                    Pulo.Play();
                }
            }
        }
    }

    void BowFire()
    {
        StartCoroutine("Fire");
    }

    void fogo()
    {
        GameObject bow = Instantiate(Bowprefab, firePonit.position, firePonit.rotation);
        Rigidbody2D rb = bow.GetComponent<Rigidbody2D>();

        // Verificação da direção do personagem
        if (transform.eulerAngles.y == 0) // Personagem está voltado para a direita
        {
            rb.velocity = Vector2.right * 11f; // Bola de fogo vai para a direita
        }
        else // Personagem está voltado para a esquerda
        {
            rb.velocity = Vector2.left * 11f; // Bola de fogo vai para a esquerda
            tiro.Play();
        }

        Destroy(bow, 2f);
    }
    void fogo2()
    {
        GameObject bow2 = Instantiate(Bowprefab2, firePonit.position, firePonit.rotation);
        Rigidbody2D rb = bow2.GetComponent<Rigidbody2D>();

        // Verificação da direção do personagem
        if (transform.eulerAngles.y == 0) // Personagem está voltado para a direita
        {
            rb.velocity = Vector2.right * 11f; // Bola de fogo vai para a direita
        }
        else // Personagem está voltado para a esquerda
        {
            rb.velocity = Vector2.left * 11f; // Bola de fogo vai para a esquerda
        }

        Destroy(bow2, 2f);
    }
    
    IEnumerator Fire()
    {
        isFire = true;
        anim.SetInteger("Transition", 3);
        Invoke("fogo" ,0.5f);// Chama o método de disparo imediatamente
        canFire = false; // Bloqueia temporariamente o disparo
        yield return new WaitForSeconds(0.8f);
        anim.SetInteger("Transition", 0);
        isFire = false;
        canFire = true; // Libera o disparo novamente
    }
    
    IEnumerator Fire2()
    {
        isFire = true;
        anim.SetInteger("Transition", 3);
        Invoke("fogo2" ,0.5f);// Chama o método de disparo imediatamente
        canFire = false; // Bloqueia temporariamente o disparo
        yield return new WaitForSeconds(0.8f);
        anim.SetInteger("Transition", 0);
        isFire = false;
        canFire = true; // Libera o disparo novamente
    }
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FoguinhoAzul"))
        {
            Debug.Log("Morri");
            vida--;
            currentHealth--;
            UpdateHealthUI();
        }
    }

    void dead()
    {
        if (vida <= 0)
        {
            isdead = true;
            anim.SetTrigger("Morte");
            Destroy(gameObject, 0.7f);
        }
    }

    void UpdateHealthUI()
    {
        healthText.text = currentHealth.ToString();
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            pulan = false;
            if (Estagio3 == true)
            {
                jumps = 2;
            }
            else
            {
                jumps = 1;
            }
        }
    }
}
