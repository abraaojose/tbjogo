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

    private bool attack;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
      AtirarFogos();  
      Danage();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(attack) return;
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

    public void Danage()
    {
        if (health <= 0)
        {
            anim.SetTrigger("morta");
            Destroy(gameObject, 1f);
        }
    }

    private void AtirarFogos()
    {
        if (!attack)
        {
            tempoAtualDosFogos -= Time.deltaTime;
            
            if(tempoAtualDosFogos <= 0)
            {
                tempoAtualDosFogos = 0;
                StartCoroutine(SequenciaDeAtaque());   
            }
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health-=1;
            Debug.Log("Dano");
        }
    }

    IEnumerator SequenciaDeAtaque()
    {
        attack = true;
        rig.velocity = Vector2.zero;
        anim.Play("atacando");
        yield return new WaitForSeconds(0.6f);
        
        GameObject clone = Instantiate(fogoDoInimigo, localDoDisparo.position, Quaternion.Euler(0f, 0f, 360f));
        tempoAtualDosFogos = tempoMaximoEntreOsFogos;
        if (!walkRight)
        {
            clone.transform.Rotate(Vector3.up, 180);
        }
        yield return new WaitForSeconds(0.1f);
        anim.Play("andando");
        attack = false;
        StopCoroutine(SequenciaDeAtaque());

    }
    
}
