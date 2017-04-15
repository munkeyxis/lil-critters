using UnityEngine;

public class CritterMovement : MonoBehaviour 
{
    public float movementSpeed;
    public float rotationSpeed;
    private Rigidbody rigidBody;
    private Metabolism metabolism;
    private float moveForwardEnergyCost;
    private float turnEnergyCost;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        metabolism = GetComponent<Metabolism>();
        moveForwardEnergyCost = .025f;
        turnEnergyCost = .01f;
    }

    public void Forward()
    {
        metabolism.LoseEnergy(moveForwardEnergyCost);
        rigidBody.MovePosition(transform.position + transform.forward * Time.deltaTime * movementSpeed);
    }

    public void TurnClockwise()
    {
        metabolism.LoseEnergy(turnEnergyCost);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
