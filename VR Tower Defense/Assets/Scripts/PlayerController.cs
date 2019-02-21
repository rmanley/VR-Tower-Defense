using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public float turnSpeed = 1f;
    public float jumpVelocity = 5f;

    private Transform cameraLook;
    private Rigidbody rb;
    private float startHeight;
    private bool isJumping = false;

    void Start()
    {
        cameraLook = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        startHeight = transform.position.y + 0.2f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y <= startHeight)
        {
            isJumping = false;
        }
    }

    void FixedUpdate()
    {
        float leftHorizAxis = Input.GetAxis("Horizontal");
        float leftVertAxis = Input.GetAxis("Vertical");

        transform.Translate(leftHorizAxis * movementSpeed, 0, leftVertAxis * movementSpeed, cameraLook);

        float rightHorizAxis = Input.GetAxis("RJH");
        //float rightVertAxis = Input.GetAxis("RJV");  //if head movement not used

        transform.Rotate(0f, rightHorizAxis * turnSpeed, 0f);

        if (Input.GetButtonDown("A") && !isJumping)
        {
            rb.velocity += Vector3.up * jumpVelocity;
            isJumping = true;
        }
    }
}