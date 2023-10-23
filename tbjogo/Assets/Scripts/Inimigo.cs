using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float speed;
    public float walkTime;
    public bool walkRight = true;

    public int health;
    
    private float timer;

    public GameObject fogoDoInimigo;
    public Transform localDoDisparo;
        
    public float velocidadeDoInimigo;

    public float tempoMaximoEntreOsFogos;
    public float tempoAtualDosFogos;
    

    private Animator anim;
    private Rigidbody2D rig;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
      AtirarFogos();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= walkTime)
        {
            walkRight = !walkRight;
            timer = 0f;
        }

        if (walkRight)
        {
            transform.eulerAngles = new Vector2(0, 0);
            Vector2 direcao = new Vector2(speed, rig.velocity.y);
            rig.velocity = direcao;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
            Vector2 direcao = new Vector2(-speed, rig.velocity.y);
            rig.velocity = direcao;
        }
        
    }

    public void Danage(int dng)
    {
        health += dng;
        anim.SetTrigger("morta");

        if (health <= 0)
        {
            //destroi o inimigo
            Destroy(gameObject);
        }
    }

    private void AtirarFogos()
    {
        tempoAtualDosFogos -= Time.deltaTime;

        if(tempoAtualDosFogos <= 0)
        {
            GameObject clone = Instantiate(fogoDoInimigo, localDoDisparo.position, Quaternion.Euler(0f, 0f, 360f));
            tempoAtualDosFogos = tempoMaximoEntreOsFogos;
            if (!walkRight)
            {
                clone.transform.Rotate(Vector3.up, 180);
            }
        }
    }
}
