using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandicraftApp.Enums;

namespace HandicraftApp.Models
{
    public class Item : INotifyPropertyChanged
    {
        public long Id { get; set; } // Long required for SQLite id.
        public double? Size { get; set; }
        public string? Material { get; set; }
        public string? Colour { get; set; }
        public string? PatternModel { get; set; }
        public string? PatternSizes { get; set; }
        public string? OptionalInfo { get; set; }
        public string? MainType { get; set; }
        public string? SubType { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public TableNames TableName { get; set; }


        public Item(long id, double size, string material, TableNames tableName)
        {
            Id = id;
            Size = size;
            Material = material;
            TableName = tableName;
        }

        public Item(long id, double size, string material, string colour, TableNames tableName)
        {
            Id = id;
            Size = size;
            Material = material;
            Colour = colour;
            TableName = tableName;
        }

        public Item(long id, string patternModel, string patternSizes, string optionalInfo, TableNames tableName)
        {
            Id = id;
            PatternModel = patternModel;
            PatternSizes = patternSizes;
            OptionalInfo = optionalInfo;
            TableName = tableName;
        }

        public Item(long id, string mainType, string subType, double width, double height, TableNames tableName)
        {
            Id = id;
            MainType = mainType;
            SubType = subType;
            Width = width;
            Height = height;
            TableName = tableName;
        }

        public Item(long id, string colour, string optionalInfo, TableNames tableName)
        {
            Id = id;
            Colour = colour;
            OptionalInfo = optionalInfo;
            TableName = tableName;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
