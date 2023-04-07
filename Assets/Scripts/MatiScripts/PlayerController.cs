using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool smoothTransition = false;
    public float transitionSpeed = 7f;
    public float transitionRotationSpeed = 700f;

    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    public Vector3 targetRotation;

    public void RotateLeft() { if (AtRest) targetRotation -= Vector3.up * 90; }
    public void RotateRight() { if (AtRest) targetRotation += Vector3.up * 90; }

    public void MoveForward() { if (AtRest) targetGridPos += transform.forward; }
    public void MoveBack() { if (AtRest) targetGridPos -= transform.forward; }
    public void MoveRight() { if (AtRest) targetGridPos += transform.right; }
    public void MoveLeft () { if (AtRest) targetGridPos -= transform.right; }


    private void Start()
    {
        targetGridPos = Vector3Int.RoundToInt(transform.position);

    }
    void Update()
    {
        if(!AtRest && Input.GetKey(KeyCode.Q))
        {
            
        }
    }

    

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (true)
        {

            prevTargetGridPos= targetGridPos;

            Vector3 targetPosition = targetGridPos;

            if (targetRotation.y > 270f && targetRotation.y < 361f) targetRotation.y = 0f;
            if (targetRotation.y < 0f) targetRotation.y = 270f;
            
            if (!smoothTransition)
            {
                transform.position=targetPosition;
                transform.rotation = Quaternion.Euler(targetRotation);

            } else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * transitionRotationSpeed);
                
            }

        } else
        {
            //targetGridPos = prevTargetGridPos;
        }
    }

    public bool AtRest {
        get {
            if ((Vector3.Distance(transform.position, targetGridPos) < 0.05f) &&
                (Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05f))
                return true;
            else
                return false;

            
        }
    }

}
