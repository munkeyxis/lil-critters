using System;

public class NeuralNetwork 
{
    private static Random rnd;

    private int numInput;
    private int numHidden;
    private int numOutput;

    private double[] inputs;

    private double[][] ihWeights; // input-hidden
    private double[] hBiases;
    private double[] hOutputs;

    private double[][] hoWeights; // hidden-output
    private double[] oBiases;

    private double[] outputs;

    public NeuralNetwork(int numInput, int numHidden, int numOutput)
    {
        rnd = new Random(0); // for InitializeWeights() and Shuffle()

        this.numInput = numInput;
        this.numHidden = numHidden;
        this.numOutput = numOutput;

        this.inputs = new double[numInput];

        this.ihWeights = MakeMatrix(numInput, numHidden);
        this.hBiases = new double[numHidden];
        this.hOutputs = new double[numHidden];

        this.hoWeights = MakeMatrix(numHidden, numOutput);
        this.oBiases = new double[numOutput];

        this.outputs = new double[numOutput];

        InitializeWeights();
    }

    public double[] ComputeOutputs(double[] xValues)
    {
        if (xValues.Length != numInput)
            throw new Exception("Bad xValues array length");

        double[] hSums = new double[numHidden]; // hidden nodes sums scratch array
        double[] oSums = new double[numOutput]; // output nodes sums

        for (int i = 0; i < xValues.Length; ++i) // copy x-values to inputs
            this.inputs[i] = xValues[i];

        for (int j = 0; j < numHidden; ++j)  // compute i-h sum of weights * inputs
            for (int i = 0; i < numInput; ++i)
                hSums[j] += this.inputs[i] * this.ihWeights[i][j]; // note +=

        for (int i = 0; i < numHidden; ++i)  // add biases to input-to-hidden sums
            hSums[i] += this.hBiases[i];

        for (int i = 0; i < numHidden; ++i)   // apply activation
            this.hOutputs[i] = HyperTanFunction(hSums[i]); // hard-coded

        for (int j = 0; j < numOutput; ++j)   // compute h-o sum of weights * hOutputs
            for (int i = 0; i < numHidden; ++i)
                oSums[j] += hOutputs[i] * hoWeights[i][j];

        for (int i = 0; i < numOutput; ++i)  // add biases to input-to-hidden sums
            oSums[i] += oBiases[i];

        double[] softOut = Softmax(oSums); // softmax activation does all outputs at once for efficiency
        Array.Copy(softOut, outputs, softOut.Length);

        double[] retResult = new double[numOutput]; // could define a GetOutputs method instead
        Array.Copy(this.outputs, retResult, retResult.Length);
        return retResult;
    }

    private static double[][] MakeMatrix(int rows, int cols) // helper for ctor
    {
        double[][] result = new double[rows][];
        for (int r = 0; r < result.Length; ++r)
            result[r] = new double[cols];
        return result;
    }

    private void InitializeWeights()
    {
        // initialize weights and biases to small random values
        int numWeights = (numInput * numHidden) + (numHidden * numOutput) + numHidden + numOutput;
        double[] initialWeights = new double[numWeights];
        double lo = -0.01;
        double hi = 0.01;
        for (int i = 0; i < initialWeights.Length; ++i)
            initialWeights[i] = (hi - lo) * rnd.NextDouble() + lo;
        this.SetWeights(initialWeights);
    }

    private void SetWeights(double[] weights)
    {
        // copy weights and biases in weights[] array to i-h weights, i-h biases, h-o weights, h-o biases
        int numWeights = (numInput * numHidden) + (numHidden * numOutput) + numHidden + numOutput;
        if (weights.Length != numWeights)
            throw new Exception("Bad weights array length: ");

        int k = 0; // points into weights param

        for (int i = 0; i < numInput; ++i)
            for (int j = 0; j < numHidden; ++j)
                ihWeights[i][j] = weights[k++];
        for (int i = 0; i < numHidden; ++i)
            hBiases[i] = weights[k++];
        for (int i = 0; i < numHidden; ++i)
            for (int j = 0; j < numOutput; ++j)
                hoWeights[i][j] = weights[k++];
        for (int i = 0; i < numOutput; ++i)
            oBiases[i] = weights[k++];
    }

    private static double HyperTanFunction(double x)
    {
        if (x < -20.0) return -1.0; // approximation is correct to 30 decimals
        else if (x > 20.0) return 1.0;
        else return Math.Tanh(x);
    }

    private static double[] Softmax(double[] oSums)
    {
        // determine max output sum
        // does all output nodes at once so scale doesn't have to be re-computed each time
        double max = oSums[0];
        for (int i = 0; i < oSums.Length; ++i)
            if (oSums[i] > max) max = oSums[i];

        // determine scaling factor -- sum of exp(each val - max)
        double scale = 0.0;
        for (int i = 0; i < oSums.Length; ++i)
            scale += Math.Exp(oSums[i] - max);

        double[] result = new double[oSums.Length];
        for (int i = 0; i < oSums.Length; ++i)
            result[i] = Math.Exp(oSums[i] - max) / scale;

        return result; // now scaled so that xi sum to 1.0
    }
}
