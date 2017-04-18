using System;
using System.Collections.Generic;
using UnityEngine;

public class CritterMovement : MonoBehaviour 
{
    public float movementSpeed;
    public float rotationSpeed;
    private Rigidbody rigidBody;
    private Metabolism metabolism;
    private float moveForwardEnergyCost;
    private float turnEnergyCost;
    private Queue<Action> movementQueue;

    private void Start()
    {
        movementQueue = new Queue<Action>();
        rigidBody = GetComponent<Rigidbody>();
        metabolism = GetComponent<Metabolism>();
        moveForwardEnergyCost = .025f;
        turnEnergyCost = .01f;
    }

    private void FixedUpdate()
    {
        while(movementQueue.Count != 0)
        {
            Action action = movementQueue.Dequeue();
            action();
        }
    }

    public void QueueForward()
    {
        movementQueue.Enqueue(Forward);
    }

    public void QueueTurnClockwise()
    {
        movementQueue.Enqueue(TurnClockwise);
    }

    private void Forward()
    {
        metabolism.LoseEnergy(moveForwardEnergyCost);
        rigidBody.MovePosition(transform.position + transform.forward * Time.deltaTime * movementSpeed);
    }

    private void TurnClockwise()
    {
        metabolism.LoseEnergy(turnEnergyCost);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
