using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    public float speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float _mouseSensitivty = 3.0f;
    public float distanceFromTarget = 150f;
    private float rotationX;
    private float rotationY;
    private bool moveCamera = false;

    // Update is called once per frame
    void Update()
    {

        GameObject player = GameObject.Find("PlayerTarget");
        // camera swivel
        if (Input.GetMouseButtonDown(0)) {
            moveCamera = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            moveCamera = false;
        }
        if (moveCamera) {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivty;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivty;
        
            rotationX += mouseY;
            rotationY += mouseX;

            rotationX = Mathf.Clamp(rotationX,20,60);

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
        transform.position = player.transform.position - transform.forward * distanceFromTarget;

    }
}
