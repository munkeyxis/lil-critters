using System;
using UnityEngine;

public class NeuralNetwork
{
    private Neuron[][] network;
    private int layers;
    private int neuronsPerLayer;

    public NeuralNetwork()
    {
        layers = 3;
        neuronsPerLayer = 5;
        network = new Neuron[layers][];

        InitializeNetwork();
        ConnectLayers();

        //ConsoleLogNetwork();
    }

    public void StimulateNetwork()
    {
        foreach(Neuron neuron in network[0])
        {
            neuron.Pulse(1);
        }
    }

    private void InitializeNetwork()
    {
        for (int i = 0; i < network.Length; i++)
        {
            network[i] = new Neuron[neuronsPerLayer];

            for (int j = 0; j < neuronsPerLayer; j++)
            {
                int neuronIndex = j;
                network[i][neuronIndex] = new Neuron();
            }
        }
    }

    private void ConnectLayers()
    {
        for (int i = 0; i < network.Length - 1; i++)
        {
            for (int j = 0; j < network[i].Length; j++)
            {
                for(int k = 0; k < network[i + 1].Length; k++)
                {
                    network[i][j].SetConnection(network[i + 1][k]);
                }
            }
        }
    }

    private void ConsoleLogNetwork()
    {
        for (int i = 0; i < network.Length; i++)
        {
            Debug.Log("Layer: " + i);

            foreach (Neuron neuron in network[i])
            {
                Debug.Log("neuron amplitude: " + neuron.amplitude);
                Debug.Log("number of connections " + neuron.connectedNeurons.Count);
            }
        }
    }
}
