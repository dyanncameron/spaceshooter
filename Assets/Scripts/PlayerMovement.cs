using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float rotSpeed = 180f;
    float shipBoundaryRadius = 0.5f;
    void Start()
    {
        
    }
    void Update(){
       //Rotate the Ship.

       //Grab the Z euler
       Quaternion rot = transform.rotation;

       //Grab the Z euler angle
       float z = rot.eulerAngles.z;

       //Change the Z angle based on input 
       z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

       // Recreate the quaternion 
       rot = Quaternion.Euler( 0, 0, z);

       //Feed the quaternion into our rotation 
       transform.rotation = rot;

        //Move the Ship.
       Vector3 pos = transform.position;
       
       Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

       pos += rot * velocity;

       //Restricting the player to the camera bounderies

        if(pos.y+shipBoundaryRadius > Camera.main.orthographicSize){
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }
        if(pos.y-shipBoundaryRadius < -Camera.main.orthographicSize){
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }
        //calculating the orthographic width based on the screen ratio
        float screenRatio = (float)Screen.width / (float)Screen.height; 
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        //horizontal bounds
         if(pos.x+shipBoundaryRadius > widthOrtho){
             pos.x = widthOrtho- shipBoundaryRadius;
        }
         if(pos.x-shipBoundaryRadius < -widthOrtho){
             pos.x = -widthOrtho+ shipBoundaryRadius;
         }
         //updating position 
       transform.position = pos;
    }
}
