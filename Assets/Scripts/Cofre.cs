using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    [SerializeField] GameObject[] arrayObjetosCofre;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ColocarArma();
            Destroy(this.gameObject);
        }
    }

    void ColocarArma()
    {
        GameObject manoArma = GameObject.FindGameObjectWithTag("Mano"); 
        int numeroAleatorio = Random.Range (0, arrayObjetosCofre.Length);
        Instantiate(arrayObjetosCofre[numeroAleatorio], manoArma.transform);
        GameObject.FindAnyObjectByType<Personaje>().PuedoAtacar = true;
    }
}
