using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.ScorwModel
{
   public class ModelOutput
    {
        [ColumnName("PredictedLable")]
        public bool Preiction { get; set; }
        public float probability { get; set; }
    }
}
