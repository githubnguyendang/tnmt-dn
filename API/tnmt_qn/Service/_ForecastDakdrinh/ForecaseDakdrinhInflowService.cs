using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace tnmt_qn.Service
{
    public class ForecaseDakdrinhInflowService
    {
        private readonly InferenceSession _session;
        private const int LookBack = 24;
        private readonly float[] _xMean = new float[] { 2.21656919f, 0.56330361f };
        private readonly float[] _xStd = new float[] { 5.78194223f, 2.02093652f };
        private readonly float _yMean = 159.35280456f;
        private readonly float _yStd = 165.46952727f;

        public ForecaseDakdrinhInflowService(string modelPath)
        {
            _session = new InferenceSession(modelPath);
        }

        public List<float> PredictInflow(float[] xQuangNgai, float[] xDakTo)
        {
            // Validate input length
            if (xQuangNgai.Length < LookBack || xDakTo.Length < LookBack)
            {
                throw new ArgumentException($"Input arrays must have at least {LookBack} elements.");
            }

            if (xQuangNgai.Length != xDakTo.Length)
            {
                throw new ArgumentException("Both input arrays must have the same length");
            }

            List<float> predictedInflow = new List<float>();
            float[,] currentInputSequence = new float[LookBack, 2];

            // Initialize the input sequence with the first LookBack elements
            for (int i = 0; i < LookBack; i++)
            {
                currentInputSequence[i, 0] = xQuangNgai[i];
                currentInputSequence[i, 1] = xDakTo[i];
            }

            for (int i = 0; i <= xQuangNgai.Length - LookBack; i++)
            {
                var inputTensor = new DenseTensor<float>(new[] { 1, LookBack, 2 });
                for (int j = 0; j < LookBack; j++)
                {
                    // Normalize input data
                    inputTensor[0, j, 0] = (currentInputSequence[j, 0] - _xMean[0]) / _xStd[0];
                    inputTensor[0, j, 1] = (currentInputSequence[j, 1] - _xMean[1]) / _xStd[1];
                }

                var inputs = new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor("input", inputTensor) };

                using (var results = _session.Run(inputs))
                {
                    var outputTensor = results.First().AsTensor<float>();
                    // Inverse transform the result
                    float prediction = outputTensor[0] * _yStd + _yMean;
                    predictedInflow.Add(prediction);
                }

                // Update the input sequence for the next prediction
                if (i < xQuangNgai.Length - LookBack)
                {
                    for (int j = 0; j < LookBack - 1; j++)
                    {
                        currentInputSequence[j, 0] = currentInputSequence[j + 1, 0];
                        currentInputSequence[j, 1] = currentInputSequence[j + 1, 1];
                    }
                    currentInputSequence[LookBack - 1, 0] = xQuangNgai[i + LookBack];
                    currentInputSequence[LookBack - 1, 1] = xDakTo[i + LookBack];
                }
            }

            return predictedInflow;
        }
    }
}
