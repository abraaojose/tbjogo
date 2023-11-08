using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public int vida = 100;
    public float speed = 5f;
    public int maxHealth = 100;
    private int currentHealth;

    private void Awake()
    {
        transform.tag = "Player";
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }

    }
    private void Die()
    {
        // Adicione aqui a lógica para lidar com a morte do jogador, como recarregar o nível ou mostrar uma tela de fim de jogo.
        Debug.Log("O jogador morreu!");
    }
}
