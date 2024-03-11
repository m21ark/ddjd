using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public bool isFixed = true;
    public float speed = 1f;
    public float distance = 5f;

    private float initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFixed) 
        {
            Move();
        }
    }

    private void Move()
    {
        float newPositionZ = initialPosition + Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        transform.position = new Vector3(transform.position.x, transform.position.y, newPositionZ);
    }
}
