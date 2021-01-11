using Microsoft.ML;
using Survey.ScorwModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Survey.Scorer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Survey score model bulder started!");
            var mlContext = new MLContext(0);
            //Build pipeline
            var inputDataPreparer = mlContext
                .Transforms
                .Text
                .FeaturizeText("Features", "OtherText")
                .AppendCacheCheckpoint(mlContext);

            var trainer = mlContext
                .BinaryClassification
                .Trainers
                .LbfgsLogisticRegression();

            var trainingPipeline = inputDataPreparer.Append(trainer);

            //Load Data
            var createInputFile = @"Data\preparedInput.tsv";
            DataPreparer.CreatePreparedDataFile(createInputFile, true);

            IDataView traningDataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                path: createInputFile,
                hasHeader: true,
                separatorChar: '\t',
                allowQuoting: true
                );

            //Fit the model
            ITransformer model = trainingPipeline.Fit(traningDataView);

            //Save the model
            if (!Directory.Exists("Model"))
            {
                Directory.CreateDirectory("Model");
            }
            var modelFile = @"Model\\SurveyScoreModel.zip";
            mlContext.Model.Save(model,traningDataView.Schema,modelFile);
            Console.WriteLine("Don");
        }
    }
}
