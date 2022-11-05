using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessScroll : MonoBehaviour
{

    [SerializeField] private float scrollFactor = -1f;
    [SerializeField] private Vector3 gameVelocity;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = gameVelocity * scrollFactor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider gameArea)
    {
        transform.position += Vector3.right * (gameArea.bounds.size.x + GetComponent<BoxCollider>().size.x);
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

