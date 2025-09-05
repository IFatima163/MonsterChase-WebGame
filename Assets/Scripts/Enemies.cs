using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    private Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        //speed = 7f; //not hardcoding the value of speed as it is chosen randomly at the time of spawning at MonsterSpawner.cs line 33
    }

    void FixedUpdate()
    {
        //changing gravity of enemies
        myBody.velocity = new Vector2 (speed, myBody.velocity.y); 
        //above, we could've followed the same pattern as in playerJump with AddForce. But this works too.
        //here we are setting the same value for y parameter i.e; myBody.velocity.y which is however much it was thus no change occurs.
        //we are not putting zero here because then the all enemies will be on the ground instead of whichever position we place them.
        //the zero would work the same for the zombies as they are already on the ground but we are using the myBody.velocity.y 
        //because the ghost is floating. this helps reuse the script for all enemies together.
    }
}
