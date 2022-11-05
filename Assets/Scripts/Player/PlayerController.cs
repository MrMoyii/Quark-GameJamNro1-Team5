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


    private void Awake()
    {
        Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && isGrounded)
        {
            rb.velocity = jumpSpeed;
            isGrounded = false;
            newSound = Instantiate(jumpSound);
            Destroy(newSound, 2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
