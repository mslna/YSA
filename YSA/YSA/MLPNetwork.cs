using System;

namespace YSA
{
    public class MLPNetwork
    {
        private Layer HiddenLayer;
        private Layer OutputLayer;
        private double LearningRate;
        public double LastError { get; private set; } 

        public MLPNetwork(int inputSize, int hiddenCount, int outputCount, double learningRate)
        {
            HiddenLayer = new Layer(hiddenCount, inputSize);
            OutputLayer = new Layer(outputCount, hiddenCount);
            LearningRate = learningRate;
        }

        public double[] Predict(double[] inputs)
        {
            var hiddenOutputs = HiddenLayer.Forward(inputs);
            return OutputLayer.Forward(hiddenOutputs);
        }

        public void Train(double[][] inputs, double[][] targets, double epsilon)
        {
            double error;
            do
            {
                error = 0;
                for (int i = 0; i < inputs.Length; i++)
                {
                    var input = inputs[i];
                    var target = targets[i];

                    var hiddenOutput = HiddenLayer.Forward(input);
                    var predicted = OutputLayer.Forward(hiddenOutput);

                    double[] outputErrors = new double[predicted.Length];
                    for (int j = 0; j < predicted.Length; j++)
                    {
                        outputErrors[j] = target[j] - predicted[j];
                        error += Math.Pow(outputErrors[j], 2);
                    }

                    for (int j = 0; j < OutputLayer.Neurons.Length; j++)
                    {
                        var neuron = OutputLayer.Neurons[j];
                        neuron.Delta = outputErrors[j] * neuron.Derivative();
                        for (int k = 0; k < neuron.Weights.Length; k++)
                            neuron.Weights[k] += LearningRate * neuron.Delta * hiddenOutput[k];
                        neuron.Bias += LearningRate * neuron.Delta;
                    }

                    for (int j = 0; j < HiddenLayer.Neurons.Length; j++)
                    {
                        var neuron = HiddenLayer.Neurons[j];
                        double hiddenError = 0;
                        for (int k = 0; k < OutputLayer.Neurons.Length; k++)
                            hiddenError += OutputLayer.Neurons[k].Delta * OutputLayer.Neurons[k].Weights[j];
                        neuron.Delta = hiddenError * neuron.Derivative();
                        for (int k = 0; k < neuron.Weights.Length; k++)
                            neuron.Weights[k] += LearningRate * neuron.Delta * input[k];
                        neuron.Bias += LearningRate * neuron.Delta;
                    }
                }

                error /= inputs.Length;
                LastError = error;

            } while (error > epsilon);
        }
    }
}

