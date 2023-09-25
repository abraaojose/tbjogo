using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float speed;
    public float walkTime;
    public bool walkRight = true;
    private float timer;
   

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
}
