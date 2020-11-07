using System;
using System.Collections.Generic;
using System.Text;

namespace AnonDataGenerator.Entities
{
    public class DataDefinition
    {
        public int RowCount { get; set; }
        public List<ColumnDefinition> ColumnDefinitions { get; set; }

    }
}
