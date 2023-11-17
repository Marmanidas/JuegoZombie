using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public bool PuedoAtacar { get; set; }

    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float velocidadRotacion;

    private CharacterController characterController;
    private Animator anim;
    private bool estoyMuerto;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (!estoyMuerto)
        {
            Movimiento();
            Ataque();
        }
    }

    void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float adelante = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(horizontal, 0, adelante);
        movimiento = transform.TransformDirection(movimiento);
        movimiento *= velocidadMovimiento * Time.deltaTime;
        characterController.Move(movimiento);

        anim.SetFloat("Correr", Mathf.Abs(movimiento.magnitude));

        float rotacion = horizontal * velocidadRotacion * Time.deltaTime;
        transform.Rotate(0, rotacion, 0);
    }

    void Ataque()
    {
        if (Input.GetMouseButtonDown(0) && PuedoAtacar)
        {
            anim.SetTrigger("Ataque");
        }
    }

    public void Muerte()
    {
        Debug.Log("Estoy muerto");
        anim.SetTrigger("Muerto");
        estoyMuerto = true;
    }


}
