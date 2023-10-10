using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool pulan;
    private bool isFire;
    
    private Rigidbody2D rig;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        BowFire();
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

        if (movimento < 0 && !pulan )
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

    IEnumerator Fire()
    {
        if (Input.GetKeyDown((KeyCode.F)))
        {
            isFire = true;
            anim.SetInteger("Transition", 3);
            yield return new WaitForSeconds(0.8f);
            anim.SetInteger("Transition",0);
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            pulan = false;
        }
    }
    
}