using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public float speed;
    public float walkTime;

    private float timer;
    private bool walkRihgt = true;

    public int vida;

    private Animator anima;
    private Rigidbody2D rig;

    public float ataque = 2.0f;
    public int damage = 10;

    private Transform player;
    private Animator anim;
    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= walkTime)
        {
            walkRihgt = !walkRihgt;
            timer = 0f;
        }

        if (walkRihgt)
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.velocity = Vector2.left * speed;
        }
    }

    public void Damage(int dmg)
    {
        vida -= dmg;
        anim.SetTrigger("hit");

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= ataque && !isAttacking)
        {
            // Iniciar a animação de ataque
            anima.SetTrigger("Ataque"); // Acione o trigger de ataque
            isAttacking = true;
        }
    }

    public void PerformAttack()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= ataque)
        {

        }
    }
}


