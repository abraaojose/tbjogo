using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool pulan;
    private bool isFire;
    private bool canFire = true; // Nova variável para controle do disparo
    public GameObject Bowprefab;
    public Transform firePonit;

    private Rigidbody2D rig;
    private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
        
        // Somente chama a função de disparo se estiver no estado Idle
        if (Input.GetKeyDown(KeyCode.F) && !isFire && anim.GetInteger("Transition") == 0)
        {
            StartCoroutine("Fire");
        }
    }

    private void FixedUpdate()
    {
        Move();
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
            if (!pulan)
            {
                anim.SetInteger("Transition", 2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                pulan = true;
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
        }

        Destroy(bow, 2f);
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

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            pulan = false;
        }
    }
}
