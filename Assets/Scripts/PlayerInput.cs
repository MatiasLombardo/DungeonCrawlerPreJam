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
  
    [SerializeField] float range=2;
    
    public bool sePuedeMover;
    public static bool enemigosPuedenMover;
    [SerializeField] float rotationSpeed;
    PlayerController controller;
    public GameObject camaraPlayer; 
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        sePuedeMover = true;
        

    }
    private void OnEnable() 
    {
        camaraPlayer.transform.rotation = new Quaternion (0,0,0,0);
        sePuedeMover = true;
    }
    private void Update()
    {
        //Vector3 front = Vector3.forward;
        // Ray frontRay = new Ray(transform.position, transform.TransformDirection(front * range));
        RaycastHit hitForward;
        RaycastHit hitBackward;
        RaycastHit hitLeft;
        RaycastHit hitRight;


        if (Input.GetKeyUp(turnLeft) && sePuedeMover) controller.RotateLeft();
        if (Input.GetKeyUp(turnRight) && sePuedeMover) controller.RotateRight();

        //Rayo adelante
        if (controller.smoothTransition)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range);
            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) , out hitForward, range)&& Input.GetKey(forward) && sePuedeMover)
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
        if (!Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward), out hitBackward, range) && Input.GetKeyUp(back) && sePuedeMover)
        {
            controller.MoveBack();

        }

        //Rayo Izquierda
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * range);
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitLeft, range) && Input.GetKeyUp(left) && sePuedeMover)
        {
            controller.MoveLeft();

        }

        //Rayo Derecha
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * range);
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitRight, range) && Input.GetKeyUp(right) && sePuedeMover)
        {
            controller.MoveRight();
        }

       
    }
    public void GirarCamaraA(Transform pointer)
    {
        //Mueve la camara a el objetivo pointer
            sePuedeMover = false;
            int temp = 0;
            int temp2 = 0;
            Debug.Log("mueve la cam");
            while (temp < 1000)
            {
                if(temp2 >= 1000) break;
                Vector3 direction = pointer.position - transform.position;
                //esto cumple la misma funcion que LookAt(), pero tomando mas control del angulo.
                float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
                camaraPlayer.transform.rotation = Quaternion.Slerp(camaraPlayer.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
                //Debug.Log("gira la camara");
                //myCamera.transform.LookAt(pointer);
                temp++;
                temp2++;
            }
            //sePuedeMover = true;
    }

}
