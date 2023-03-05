using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 10f;

    private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;

    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();    
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
        rb.velocity = movement;

        Vector3 targetPosition = transform.position + rb.velocity.normalized;

        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            anim.SetBool("Walk", true);
        }
        else
            anim.SetBool("Walk", false);
    }







}