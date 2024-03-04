using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePowerup : MonoBehaviour
{
    public int rotateSpeed;
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
        transform.Rotate(rotateSpeed * Time.deltaTime * 2, 0, 0, Space.World);
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime * 0.5f, Space.World);
    }
}
