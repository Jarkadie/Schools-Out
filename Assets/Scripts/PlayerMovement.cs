using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lookSpeed = 1f;
    [SerializeField] private int duckDistance;



    [SerializeField] private Camera playerView;
    private Vector3 rotationValue = new Vector3();
    private Vector3 cameraRotationValue = new Vector3();


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            duckDistance *= -1;
            transform.localScale += new Vector3(0, duckDistance, 0);
        }
    }

    private void FixedUpdate()
    {
        float zDirection = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float xDirection = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector3(xDirection,0,zDirection));

        cameraRotationValue.x = Input.GetAxis("Mouse Y") * lookSpeed;
        rotationValue.y = -Input.GetAxis("Mouse X") * lookSpeed;

        transform.eulerAngles -=  rotationValue;
        playerView.transform.eulerAngles -= cameraRotationValue;

    }
}
