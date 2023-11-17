using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject panelComienzo;

    public void BotonComenzar()
    {
        panelComienzo.SetActive(false);
    }
}
