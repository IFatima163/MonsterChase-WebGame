using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    private string PLAYER_TAG = "Player";

    [SerializeField]
    private float minX, maxX; //min and max axis to keep camera within the game background

    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    void LateUpdate() //starts execution after all calculations until update are done; helps avoid glitch
    {
        if (!player)
            return; //end the late update without changing position of the camera if the player has been destroyed/ killed

        tempPos = transform.position; //getting the current position of camera from Transform
        tempPos.x = player.position.x; //changing the X axis of the camera

        if (tempPos.x < minX)
            tempPos.x = minX; // to avoid camera going off scene

        if (tempPos.x > maxX)
            tempPos.x = maxX; // to avoid camera going off scene

        transform.position = tempPos; //setting the new over all position of the camera on all three axis
    }
}
