using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 gravity;
    [SerializeField] private Vector3 jumpSpeed;
    [SerializeField] private GameObject jumpSound;    

    private bool isGrounded = false;
    private Rigidbody rb;
    private GameObject newSound;
    private Animator animator;


    private void Awake()
    {
        Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && isGrounded)
        {
            rb.velocity = jumpSpeed;
            isGrounded = false;
            animator.SetBool("isJumping", true);
            newSound = Instantiate(jumpSound);
            Destroy(newSound, 2);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
