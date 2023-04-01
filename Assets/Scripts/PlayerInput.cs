using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class PlayerInput : MonoBehaviour
{


    public KeyCode forward = KeyCode.W;
    public KeyCode back = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode turnLeft = KeyCode.Q;
    public KeyCode turnRight = KeyCode.E;
  
    public float range=2;

    PlayerController controller;
    [SerializeField] Camera myCamera; 

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        

    }

    private void Update()
    {
        //Vector3 front = Vector3.forward;
        // Ray frontRay = new Ray(transform.position, transform.TransformDirection(front * range));
        RaycastHit hitForward;
        RaycastHit hitBackward;
        RaycastHit hitLeft;
        RaycastHit hitRight;


        if (Input.GetKeyUp(turnLeft)) controller.RotateLeft();
        if (Input.GetKeyUp(turnRight)) controller.RotateRight();

        //Rayo adelante

        if (controller.smoothTransition)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range);
            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitForward, range) && Input.GetKey(forward))
            {
                controller.MoveForward();

            }
        }
        else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range);
            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitForward, range) && Input.GetKeyUp(forward))
            {
                controller.MoveForward();

            }
        }

        //Rayo atras
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)* -1 * range);
        if (!Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward), out hitBackward, range) && Input.GetKeyUp(back))
        {
            controller.MoveBack();

        }

        //Rayo Izquierda
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * range);
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitLeft, range) && Input.GetKeyUp(left))
        {
            controller.MoveLeft();

        }

        //Rayo Derecha
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * range);
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitRight, range) && Input.GetKeyUp(right))
        {
            controller.MoveRight();

        }

       
    }

}
