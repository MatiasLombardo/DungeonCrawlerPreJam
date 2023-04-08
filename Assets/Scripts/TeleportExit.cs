using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportExit : MonoBehaviour
{
    public Transform Player;
    public Transform teleportLocation;
    public PlayerController playercontroller; 
    void OnTriggerEnter(Collider other)
    {
        playercontroller.targetGridPos = teleportLocation.position;
        playercontroller.prevTargetGridPos = teleportLocation.position;
        Player.position = teleportLocation.position;
    }
}
