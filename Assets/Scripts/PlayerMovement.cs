using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float maximumSpeed = 3;

    private int rotationSpeed = 10;

    private Animator animator;
    private CharacterController characterController;
    [SerializeField]
    private Transform cameraTransform;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitud = Mathf.Clamp01(movementDirection.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitud /= 2;
        }

        // animation
        animator.SetFloat("Input Magnitud", inputMagnitud, 0.05f, Time.deltaTime);
        
        float speed = inputMagnitud * maximumSpeed;

        // moving player with camera
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
		
        movementDirection.Normalize();

        characterController.SimpleMove(movementDirection * speed);

        // rotation if it is moving
        if (movementDirection != Vector3.zero)
        {
            // set animation to true
            //animator.SetBool("isMoving", true);

            transform.forward = Vector3.Slerp(transform.forward, movementDirection, Time.deltaTime * rotationSpeed);
        }
        else 
        {
            //animator.SetBool("isMoving", false);
        }
	}

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
			Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
