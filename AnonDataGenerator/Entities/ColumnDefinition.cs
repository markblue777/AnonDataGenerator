using System;
using System.Collections.Generic;
using System.Text;

namespace AnonDataGenerator.Entities
{
    public class ColumnDefinition
    {
        public string ColumnName { get; set; }
        public DataTypes DataType { get; set; }
        public string Range { get; set; }
        public bool IsAlphanumeric { get; set; }
        public bool IncludeBadFormat { get; set; }     
    }
}
