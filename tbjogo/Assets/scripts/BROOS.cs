using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BROOS : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;
    
    [SerializeField]
    private float velocidadeMovimento;
    
    [SerializeField]
    private Rigidbody2D rigidbody2D;
    
    [SerializeField] 
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
