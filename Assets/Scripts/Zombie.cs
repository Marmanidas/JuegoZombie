using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [Header ("Transforms")]
    [Space(7)]
    [SerializeField] Transform personaje;
    [SerializeField] Transform[] puntosRuta;

    [Space(20)]
    [Header("Ojos del Zombie")]
    [SerializeField] float distanciaOjos;
    [SerializeField] Transform ojosZombie;

    [SerializeField] int vidas;

    private NavMeshAgent agente;
    private int indiceRuta;
    private bool personajeDetectado;
    private Animator anim;
    private bool estaMuerto;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (!estaMuerto)
        {

            if (this.transform.position.x == puntosRuta[indiceRuta].position.x)
            {
                indiceRuta++;

                if (indiceRuta == puntosRuta.Length)
                {
                    indiceRuta = 0;
                }
            }

            Perseguir(personajeDetectado);
            OjosZombie();
        }
        else
        {
            agente.SetDestination(this.transform.position);
        }
    }

    void OjosZombie()
    {
        Ray rayo = new Ray (ojosZombie.position, transform.forward * distanciaOjos) ;
        Debug.DrawRay(ojosZombie.position, transform.forward * distanciaOjos, Color.red);
        RaycastHit toque;

        if (Physics.Raycast (rayo, out toque, distanciaOjos)) 
        {
            if (toque.collider.CompareTag("Player"))
            {
                personajeDetectado = true;
                Debug.Log("DETECTADO!");
            }
        }

    }

    void Perseguir(bool esDetectado)
    {
        if (!esDetectado)
        {
            agente.SetDestination(puntosRuta[indiceRuta].position);
            return;
        }
        agente.SetDestination(personaje.position);      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !estaMuerto && personajeDetectado)
        {
            anim.SetTrigger("Ataque");
            other.gameObject.GetComponent<Personaje>().Muerte();
            //Perseguir(false);
        }
        else if (other.gameObject.GetComponent<Arma>() && !estaMuerto )
        {
            anim.SetTrigger("Muerto");
            estaMuerto = true;
            Invoke(nameof(MatarAlZombie), 5);
            Debug.Log("MUERTE DEL ZOMBIE");
        }
    }

    void MatarAlZombie()
    {
        Destroy(this.gameObject);
    }
}
