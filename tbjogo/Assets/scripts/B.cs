using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;

public class B : MonoBehaviour
{
    //private Transform posicaoDoPlayer;

    public float velocidadeDoInimigo;
    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private float velocidadeMovimento;
    [SerializeField]
    private Rigidbody2D rigidbody2D;

    [SerializeField] private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //posicaoDoPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //SeguirPlayer();
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;
        Vector2 direcao = posicaoAlvo - posicaoAtual;
        direcao = direcao.normalized;

        this.rigidbody2D.velocity = (this.velocidadeMovimento * direcao);

        if (this.rigidbody2D.velocity.x > 0) {// direita
            this.spriteRenderer.flipX = false;
        }else if (this.rigidbody2D.velocity.x < 0) {//esquerda
            this.spriteRenderer.flipX = true;
        }

    }

    //private void SeguirPlayer()
    //{
        //if (posicaoDoPlayer.gameObject != null)
        //{
            //transform.position = Vector2.MoveTowards(transform.position, posicaoDoPlayer.position,velocidadeDoInimigo * Time.deltaTime); 
        //}
        
    }

    //private void Mover()
    //{
        //Vector2 posicaoDoPlayer = this.alvo.position;
    //}
//}
    
    


