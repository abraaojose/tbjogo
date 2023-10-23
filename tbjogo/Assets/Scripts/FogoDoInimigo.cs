using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogoDoInimigo : MonoBehaviour
{
    public float velocidadeDoFogo;

    public float tempoDoFogo;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, tempoDoFogo);
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
