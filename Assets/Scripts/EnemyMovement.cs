using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Camera cam;

    private NavMeshAgent agent;
    private Vector3 currentPos;
    private Vector3 initialPos;
    private Vector3 finalPosition;
    private Vector3 nextPosition;
    private Vector3 pathPosition;
    private bool isMoving;
    //
    float distanceThreshold = 0.1f; // distancia mínima para detener el movimiento del agente
    int currentNode = 0; // índice del nodo actual
    Vector3 currentDestination; // posición del nodo actual
    private NavMeshPath path;
    Vector3[] corners ;


    // Update is called once per frame
    void Start()
    {
        isMoving = false;
        agent = GetComponent<NavMeshAgent>();
        initialPos = transform.position;
        Debug.Log("La posicion inicial es: "+ initialPos);
    }
    void Update () 
    {
        /* if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && !isMoving) 
            {
                currentPos = transform.position;
                finalPosition = new Vector3(Mathf.Round(hit.point.x),Mathf.Round(hit.point.y),Mathf.Round(hit.point.z));
                Debug.Log("El destino es: "+finalPosition);
                agent.SetDestination(finalPosition);
                isMoving = true;
                agent.isStopped=false;
                path = new NavMeshPath();
                agent.CalculatePath(finalPosition, path);
                corners = path.corners;
                currentDestination = corners[currentNode]; // posición del nodo actual
                Debug.Log(currentNode);
            }
        }

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
}
