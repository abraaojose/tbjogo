using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Bow : MonoBehaviour
{

    private Rigidbody2D rig;
    public float speed; 
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.velocity = Vector2.right * speed;
    }
}
