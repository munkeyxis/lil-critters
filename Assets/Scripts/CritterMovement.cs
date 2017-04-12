using UnityEngine;

public class CritterMovement : MonoBehaviour 
{
    public float movementSpeed;
    public float rotationSpeed;

    public void Forward()
    {
        transform.localPosition += transform.forward * Time.deltaTime * movementSpeed;
    }

    public void TurnClockwise()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
