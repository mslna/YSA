using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace YSA
{
    public class Layer
    {
        public Neuron[] Neurons;

        public Layer(int neuronCount, int inputCountPerNeuron) 
        {
            Neurons = new Neuron[neuronCount];
            for (int i = 0; i < neuronCount; i++)
                Neurons[i] = new Neuron(inputCountPerNeuron);
        }

        public double[] Forward(double[] inputs)
        {
            return Neurons.Select(n => n.Activate(inputs)).ToArray();
        }
    }

}

