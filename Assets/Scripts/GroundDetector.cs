using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    // Note to Level 3 Cohort 7: This script is HORRIBLE! ABSOLUTELY ATROCIOUS! And that's on purpose! It's simple and easy to understand.
    // There are several bugs involved with this very simplistic approach to detecting the floor.
    // Try to improve it if you have time! Here's a hint: https://docs.unity3d.com/ScriptReference/Physics2D.Raycast.html
    
    //This tells us whether we are currently touching the ground
    [HideInInspector]
    public bool onGround = false;

    //If we are touching ANYTHING, we are considered "on the ground"
    public void OnCollisionStay2D(Collision2D collision)
    {
        onGround = true;
    }

    //Whenever we STOP touching something, we are no longer considered "on the ground"
    public void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }


}
