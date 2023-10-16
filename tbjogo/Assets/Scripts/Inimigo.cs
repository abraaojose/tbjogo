using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float speed;
    public float walkTime;
    public bool walkRight = true;
    private float timer;
    

    public GameObject fogoDoInimigo;
    public Transform localDoDisparo;

    public float tempoMaximoEntreOsFogo;
    public float tempoAtualDosFogos;

    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
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
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.velocity = Vector2.left * speed;
        }
        
    }

    void Update()
    {
        AtirarFogo();
    }


    private void AtirarFogo()
    {

       
        tempoAtualDosFogos -= Time.deltaTime;

        if (tempoAtualDosFogos <= 0)
        {
            Instantiate(fogoDoInimigo, localDoDisparo.position, Quaternion.Euler(0f,0f,360f));
            tempoAtualDosFogos = tempoMaximoEntreOsFogo;
            
        }
    }
}
