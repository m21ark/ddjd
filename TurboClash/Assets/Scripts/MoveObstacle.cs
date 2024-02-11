using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public bool isFixed = true;
    public float speed = 1f;
    public float distance = 5f;
    public enum Direction { X, Y, Z }
    public Direction direction;

    private float currentSpeed;
    private float currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFixed) move();
    }

    private void move(){
        if(direction == Direction.Z){
            currentPosition = transform.position.z;
            if(currentPosition > distance) currentSpeed = -speed;
            else if(currentPosition < -distance) currentSpeed = speed;
            
            transform.position += new Vector3(0, 0, currentSpeed * Time.deltaTime);
        }
        else if(direction == Direction.X){
            currentPosition = transform.position.x;
            if(currentPosition > distance) currentSpeed = -speed;
            else if(currentPosition < -distance) currentSpeed = speed;

            transform.position += new Vector3(currentSpeed * Time.deltaTime, 0, 0);
        }
        else if(direction == Direction.Y){
            currentPosition = transform.position.y;
            if(currentPosition > distance) currentSpeed = -speed;
            else if(currentPosition < -distance) currentSpeed = speed;
            
            transform.position += new Vector3(0, currentSpeed * Time.deltaTime, 0);
        }
    }
}
