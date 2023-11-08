using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogoDoInimigo : MonoBehaviour
{
    public float velocidadeDoFogo;
    
    public float tempoDoFogo;
    
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound.Play();
        Destroy(this.gameObject, 2f );
    }

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarFogo(); 
    }

    void MovimentarFogo()
    {
       transform.Translate(Vector3.right * velocidadeDoFogo * Time.deltaTime);
    }
}
