using UnityEngine;

public class CritterBrain : MonoBehaviour 
{
    public int NetworkInputs;
    public int NetworkHidden;
    public int NetworkOutputs;

    public double[] InputValues;

    private CritterMovement movement;
    private CritterConsume consume;
    private NeuralNetwork neuralNetwork;

    private void Start() 
    {
        // TODO: Detect all attached scripts
        movement = GetComponent<CritterMovement>();
        consume = GetComponent<CritterConsume>();

        // Create Brain
        neuralNetwork = new NeuralNetwork(NetworkInputs, NetworkHidden, NetworkOutputs);
    }

    public void ComputeOutputs()
    {
        double[] outputs = neuralNetwork.ComputeOutputs(InputValues);

        LogOutputsToConsole(outputs);
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

    private void LogOutputsToConsole(double[] outputs)
    {
        int outputIndex = 0;

        Debug.Log("Outputs");
        Debug.Log("=================");

        foreach (double value in outputs)
        {
            Debug.Log("output " + outputIndex + ": " + value);
            outputIndex++;
        }
    }
}
