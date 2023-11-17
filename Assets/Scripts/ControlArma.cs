using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArma : MonoBehaviour
{
    bool esActivo;

    public void ActivarCollider()
    {
        esActivo = !esActivo;
        Arma arma = GameObject.FindAnyObjectByType<Arma>();
        arma.ActivarCollider(esActivo);
    }
}
