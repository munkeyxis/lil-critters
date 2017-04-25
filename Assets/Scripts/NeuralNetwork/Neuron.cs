using System.Collections.Generic;
using UnityEngine;

public class Neuron
{
    private float signal;
    public float amplitude { get; private set; }
    public List<Neuron> connectedNeurons { get; private set; }

    public Neuron()
    {
        amplitude = Random.Range(-1f, 1f);
        connectedNeurons = new List<Neuron>();
    }

    public void SetConnection(Neuron connectedNeuron)
    {
        connectedNeurons.Add(connectedNeuron);
    }

    public void Pulse(float incomingSignal)
    {
        signal = incomingSignal + amplitude;

        foreach (Neuron neuron in connectedNeurons)
        {
            neuron.Pulse(signal);
        }

        if(connectedNeurons.Count == 0)
        {
            Debug.Log("output: " + signal);
        }
    }
}
