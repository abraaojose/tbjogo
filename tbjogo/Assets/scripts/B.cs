using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;

public class B : MonoBehaviour
{
    private GameObject player;

    private NavMeshAgent navMesh;
    private bool podeAtacar;
    
    // Start is called before the first frame update
    void Start()
    {
        podeAtacar = true;
        player = GameObject.FindWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.destination = player.transform.position;
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5)
        {
            Atacar();
        }
    }

    void Atacar()
    {
        if (podeAtacar)
        { 
            StartCoroutine("TempoDeAtaque");
            player.GetComponent<Player>().vida -= 40;
        }
    }
    IEnumerator TempoDeAtaque()
    {
        podeAtacar = false;
        yield return new WaitForSeconds(1);
        podeAtacar = true;
    }
}


