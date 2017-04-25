using UnityEngine;

public class CritterBrain : MonoBehaviour 
{
    private CritterMovement movement;
    private CritterConsume consume;
    private NeuralNetwork brain;

    private void Start() 
    {
        // TODO: Detect all attached scripts
        movement = GetComponent<CritterMovement>();
        consume = GetComponent<CritterConsume>();
        brain = new NeuralNetwork();
        Debug.Log("=============");
        brain.StimulateNetwork();
    }

    public void ViewedNothing()
    {
        // TODO: Use neural network to connect stimulous with action
        movement.QueueTurnClockwise();
    }
    
    public void ViewedColor()
    {
        // TODO: Use neural network to connect stimulous with action
        movement.QueueForward();
    }

    // OnCollisionStay is acting as "physical" stimulous
    private void OnCollisionStay(Collision other)
    {
        // TODO: Use neural network to connect stimulous with action
        consume.ConsumeOrganism(other.gameObject);
    }
}
