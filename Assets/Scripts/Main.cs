using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	/*
    [SerializeField] private GameObject player;
    [SerializeField] private float playerMoveSpeed = 7f;
    private Camera camera;
    private int rotationSpeed = 10;

	private int cameraRotationSpeed = 10;
	float rotationX = 0f;
	float rotationY = 0f;

	// Start is called before the first frame update
	private void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
		Vector3 movement = Vector3.zero;

		// setting input vector for keyboard input
		if (Input.GetKey(KeyCode.W))
		{
			movement += transform.forward;
		}
		// Backward movement
		if (Input.GetKey(KeyCode.S))
		{
			movement -= transform.forward;
		}
		// Right movement
		if (Input.GetKey(KeyCode.D))
		{
			movement += transform.right;
		}
		// Left movement
		if (Input.GetKey(KeyCode.A))
		{
			movement -= transform.right;
		}

		// normalizing the input vector for multiple keys pressed
		movement.Normalize();

        movement *= playerMoveSpeed * Time.deltaTime;
		movement.y = 0f;

        // setting player and camera movement
        player.transform.position += movement;
        camera.transform.position += movement;
        
        // rotation
        player.transform.forward = Vector3.Slerp(player.transform.forward, movement, Time.deltaTime * rotationSpeed);

		//rotationY += Input.GetAxis("Mouse X") * cameraRotationSpeed;
		//rotationX += Input.GetAxis("Mouse Y") * cameraRotationSpeed * -1;
		//camera.transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
	}
	*/
}
