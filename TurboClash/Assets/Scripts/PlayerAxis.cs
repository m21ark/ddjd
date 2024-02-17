using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string HorizontalAxisName;
    [SerializeField] private string VerticalAxisName;

    private Rigidbody rb;
    private new Renderer renderer;

    private float inputHorizontal;
    private float inputVertical;

    public playerMovement playerMovement;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponentInChildren<Renderer>();
        // renderer.material.color = color;
    }

    private void Update()
    {
        /* inputHorizontal = Input.GetAxisRaw(HorizontalAxisName);
        inputVertical = Input.GetAxisRaw(VerticalAxisName);

        if(inputHorizontal != null && inputVertical != null)
            if (inputHorizontal != 0 || inputVertical != 0)
            {
                playerMovement.Move(inputHorizontal, inputVertical);
            } */
    }
}
