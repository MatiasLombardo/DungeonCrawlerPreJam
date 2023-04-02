using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public Image compass;
    public PlayerController playerController;
    public Transform a;

    [SerializeField] Sprite north;
    [SerializeField] Sprite south;
    [SerializeField] Sprite east;
    [SerializeField] Sprite west;

    public KeyCode change = KeyCode.J;
  

    void Update()
    {
        if (Input.GetKeyDown(change))
        {
            compass.sprite = west;
        }
        //Debug.Log(playerController.targetRotation.y);
        switch (playerController.targetRotation.y)
        {
            case 0f: compass.sprite = north; break;
            case 90f: compass.sprite = east; break;
            case 270f: compass.sprite= west; break;
            case 180f: compass.sprite= south; break;
                default: break;
        }

    }
}
