using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 1f;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();     
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime); //equivalent to replacing Vector3.up with (0,1,0), which would add 1 to y
        };
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(-Vector3.forward * rotationThrust * Time.deltaTime); -- since repeats much of line 36, broke out into ApplyRotation method
            ApplyRotation(-rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so physics system can take over
    }
}
