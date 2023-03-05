using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStartMovement : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 10f; // quantidade de torque a ser aplicada
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(transform.up * torqueAmount, ForceMode.Impulse); // adiciona torque ao rigidbody na direção do eixo Y (up) com a quantidade especificada
    }


}
