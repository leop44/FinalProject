using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private float turnVelocity;
    private Vector3 velocity;

    public float speedMovement;
    public float turnSpeed = 0.2f;

    public Transform floor;

    private void Update()
    {
        Walk();
    }

    private void Walk() 
    {
        float X = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(X, 0, 0);
    }
}
