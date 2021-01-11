using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.ScorwModel
{
   public class ModelInput
    {
        [LoadColumn(1)]
        public string OtherText { get; set; }
        [LoadColumn(0),ColumnName("Lable")]
        public bool IsAggrissive { get; set; }
    }
}
