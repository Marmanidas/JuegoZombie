using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    private BoxCollider colArma;

    private void Awake()
    {
        colArma = GetComponent<BoxCollider>();
    }

    public void ActivarCollider (bool estaActivo)
    {
        colArma.enabled = estaActivo;
    }



}
