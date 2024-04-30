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

    public bool CanMove { get
        {
            return animator.GetBool("canMove");
        } }

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
        CheckAttack(animator);
        CheckUsingShield(animator);

        float speed = inputMagnitud * maximumSpeed;

        // moving player with camera
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
		
        movementDirection.Normalize();

        // movement looked
        if (CanMove)
        {
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

	}

    private void CheckAttack(Animator animator)
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log("left click");
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }
    
    private void CheckUsingShield(Animator animator)
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("usingShield", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            animator.SetBool("usingShield", false);
        }
        Debug.Log("using shield" + animator.GetBool("usingShield"));
    }

    /** 
     
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
     */
}
