using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;
    [SerializeField] private float mainThrust = 100f;
    [SerializeField] private float rotateSpeed = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(mainThrust * Time.deltaTime * Vector3.up); //Do in this order, less operations /more efficient
            if (!audioSource.isPlaying)
            {
                audioSource.Play();  
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateSpeed);
        }
    }

    private void ApplyRotation(float rotateThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(rotateThisFrame * Time.deltaTime * Vector3.forward);
        rb.freezeRotation = false;
    }
}
