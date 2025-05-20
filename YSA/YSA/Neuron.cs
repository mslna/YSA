using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSA
{
    public class Neuron
    {
        public double[] Weights;
        public double Bias;    
        public double Output; 
        public double Delta;  

        private static Random rnd = new Random(); 

        public Neuron(int inputCount)   
        {
            Weights = new double[inputCount];
            for (int i = 0; i < inputCount; i++)
                Weights[i] = rnd.NextDouble() - 0.5; 
            Bias = rnd.NextDouble() - 0.5;
        }

        public double Activate(double[] inputs)  
        {
            double net = 0;
            for (int i = 0; i < inputs.Length; i++)
                net += inputs[i] * Weights[i];
            net += Bias;

            Output = Sigmoid(net);
            return Output;
        }

        private double Sigmoid(double x) => 1.0 / (1.0 + Math.Exp(-x));

        public double Derivative() => Output * (1 - Output); 
    }

}
