using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Camera cam;

    private NavMeshAgent agent;
    private bool isMoving;
    //
    float distanceThreshold = 0.8f; // distancia mínima para detener el movimiento del agente
    int currentNode = 0; // índice del nodo actual
    Vector3 currentDestination; // posición del nodo actual
    private NavMeshPath path;
    Vector3[] corners ;
    private Vector3 finalPosition , initialPosition , roundedActualPosition , currentPosition , lastPosition;
    public Transform[] waypoints ;
    private Transform playerTransform;
    private int waypointNumber , layerJugador;
    public bool usaWaypoints = true;
    private float distanceX = 0;
    private float distanceZ = 0;


    // Update is called once per frame
    void Start()
    {
        lastPosition = transform.position;
        isMoving = false;
        agent = GetComponent<NavMeshAgent>();
        initialPosition = new Vector3(0,0,0);
        waypointNumber = 0;
        WaypointChecker(waypointNumber);
        layerJugador = LayerMask.NameToLayer("Jugador");
    }
    void Update () 
    {
        /* if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && !isMoving) 
            {
                finalPosition = new Vector3(Mathf.Round(hit.point.x),Mathf.Round(hit.point.y),Mathf.Round(hit.point.z));
                Debug.Log("El destino es: "+finalPosition);
            }
        } */

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
        var right45 = (transform.forward + transform.right).normalized;
        var left45 = (transform.forward - transform.right).normalized;
            if (hit.transform.gameObject.layer == layerJugador) 
            {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Debug.DrawRay(transform.position, right45 * hit.distance, Color.yellow);
                    Debug.DrawRay(transform.position, left45 * hit.distance, Color.yellow);
                    Debug.Log("Te encontre!!");
                    playerTransform = hit.transform;
                    finalPosition = playerTransform.position;
                    agent.SetDestination(finalPosition);
                    //Debug.Log(Mathf.Ceil(hit.distance));
            } 
        }

        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) && !PlayerController.playerIsMoving)
        {
            distanceX = 0;
            distanceZ = 0;
            agent.SetDestination(finalPosition);
            agent.isStopped = false;
            isMoving = true;
        }
        if (Vector3.Distance(agent.transform.position, finalPosition) < distanceThreshold)
        {
            isMoving = false;
            if(usaWaypoints)
            {
                WaypointChecker(++waypointNumber);
            }
            Debug.Log("LLEGUEEE GUACHOOO");
        }
        if(isMoving)
        {
            Vector3 currentPosition = transform.position;

            distanceX += Mathf.Abs(currentPosition.x - lastPosition.x);
            distanceZ += Mathf.Abs(currentPosition.z - lastPosition.z);
            lastPosition = currentPosition;
            /* Debug.Log("Distancia en X: " + distanceX);
            Debug.Log("Distancia en Z: " + distanceZ);  */
            if(distanceX >= 1.1 || distanceZ >= 1.1)
            {
                roundedActualPosition = new Vector3(Mathf.Round(transform.position.x),transform.position.y,Mathf.Round(transform.position.z));
                agent.SetDestination(roundedActualPosition);
                if(agent.velocity.magnitude < 0.15f)
                {
                    agent.isStopped = true;
                    isMoving = false;
                    agent.SetDestination(finalPosition);
                    Debug.Log("Me detuve, el destino es: "+finalPosition);
                }
            } 
        }
/* 
        if (Vector3.Distance(agent.transform.position, currentDestination) < distanceThreshold)
        {
            Debug.Log("AAAAAAAAAAAAAAA");
            currentNode++;
            //agent.isStopped=true;
            agent.SetDestination(corners[currentNode]);

            if (currentNode < corners.Length)
            {
                currentDestination = corners[currentNode];
                agent.SetDestination(currentDestination);
            }
        } */
    }

        void WaypointChecker(int waypointNode)
        {
            if(waypointNode <= waypoints.Length)
            {
                if(waypoints[waypointNode]!=null)
                {
                    finalPosition = waypoints[waypointNode].position;
                }
                else
                {
                    finalPosition = waypoints[0].position;
                    waypointNumber = 0;
                }
            }
            else
            {
                finalPosition = waypoints[0].position;
                waypointNumber = 0;
            }
        }
}
