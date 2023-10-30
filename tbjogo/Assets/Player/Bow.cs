using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    private bool canMove = false;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Invoke("EnableMovement", 0.6f); // Chama o método EnableMovement após 0.6 segundos
        Destroy(gameObject, 2f);
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            rig.velocity = Vector2.right * speed;
        }
    }

    void EnableMovement()
    {
        canMove = true;
    }
}