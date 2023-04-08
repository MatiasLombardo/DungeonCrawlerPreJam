using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class PlayerInput : MonoBehaviour
{


    KeyCode forward = KeyCode.W;
    KeyCode back = KeyCode.S;
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;
    KeyCode turnLeft = KeyCode.Q;
    KeyCode turnRight = KeyCode.E;
    [SerializeField] float range=2;
    private bool bufferRotation;

    public bool sePuedeMover;
    [SerializeField] float rotationSpeed;

    PlayerController controller;
    public GameObject camaraPlayer; 
    [SerializeField] AudioClip au_Movimiento1;
    [SerializeField] AudioClip au_Movimiento2;

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


        if (Input.GetKeyUp(turnLeft) && sePuedeMover) 
        {
            AudioManager.Instance.Play(au_Movimiento2);
            controller.RotateLeft();
        }
        if (Input.GetKeyUp(turnRight) && sePuedeMover)
        {
            AudioManager.Instance.Play(au_Movimiento2);
            controller.RotateRight();
        }

        //Rayo adelante
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range);
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) , out hitForward, range)&& Input.GetKey(forward) && sePuedeMover && controller.smoothTransition)
        {
            AudioManager.Instance.Play(au_Movimiento1);
            controller.MoveForward();
            
        }
        else if(!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) , out hitForward, range)&& Input.GetKeyDown(forward) && sePuedeMover)
        {
            AudioManager.Instance.Play(au_Movimiento1);
            controller.MoveForward();            
        }

        //Rayo atras
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)* -1 * range);
        if (!Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward), out hitBackward, range) && Input.GetKeyDown(back) && sePuedeMover)
        {
            AudioManager.Instance.Play(au_Movimiento1);
            controller.MoveBack();

        }

        //Rayo Izquierda
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * range);
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitLeft, range) && Input.GetKeyDown(left) && sePuedeMover)
        {
            AudioManager.Instance.Play(au_Movimiento1); 
            controller.MoveLeft();

        }

        //Rayo Derecha
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * range);
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitRight, range) && Input.GetKeyDown(right) && sePuedeMover)
        {
            AudioManager.Instance.Play(au_Movimiento1);
            controller.MoveRight();

        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            InventarioBehaviour.Instance.QuitarPocion();
        }
        

        /*if (Input.GetKeyUp(forward)) controller.MoveForward();
       /if (Input.GetKeyUp(back)) controller.MoveBack();
        //if (Input.GetKeyUp(left)) controller.MoveLeft();
        if (Input.GetKeyUp(right)) controller.MoveRight();
        */


        

        
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
                //esto cumple la misma funcion que LookAt(), poer tomando mas control del angulo.
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