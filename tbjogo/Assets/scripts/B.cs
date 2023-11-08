using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class B : MonoBehaviour
{
    private Transform posicaoDoPlayer;
    [SerializeField]
    private Transform alvo;
    
    [SerializeField]
    private Rigidbody2D rigidbody2D;
    
    [SerializeField] 
    private SpriteRenderer spriteRenderer;

    public float velocidadeDoInimigo;

    [SerializeField] 
    private Animation animator;

    [SerializeField] 
    private float distanciaMinima;
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        posicaoDoPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        
    }

    // Update is called once per frame
    void Update()
    {
        SeguirPlayer();
       
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;

        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
        
        if (distancia >= this.distanciaMinima){
            //mover o inimigo
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;
            
            
            this.rigidbody2D.velocity = (this.velocidadeDoInimigo * direcao);

            if (this.rigidbody2D.velocity.x > 0) {// direita
                this.spriteRenderer.flipX = false;
            }else if (this.rigidbody2D.velocity.x < 0) {//esquerda
                this.spriteRenderer.flipX = true;
            }

            //this.animator.SetBool("atackk",true);
        } else{
           //para a movimentaçaõ
           this.rigidbody2D.velocity = Vector2.zero; // (0.0)
        }
        
        

    }
    private void SeguirPlayer()
    {
        if (posicaoDoPlayer.gameObject != null)
        {
            Vector2 positionPlayer = new Vector2(posicaoDoPlayer.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, positionPlayer,velocidadeDoInimigo * Time.deltaTime); 
        }
        
    }

    private void Mover()
    {
        Vector2 posicaoDoPlayer = this.alvo.position;
    }
    
   
}
    
    


