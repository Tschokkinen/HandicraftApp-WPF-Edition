using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandicraftApp
{
    public class Item : INotifyPropertyChanged
    {
        public long Id { get; set; } // Long required for SQLite id.
        public double? Size { get; set; }
        public string? Material { get; set; }
        public string? Colour {  get; set; }
        public string? PatternModel { get; set; }
        public string? PatternSizes { get; set; }
        public string? OptionalInfo { get; set; }
        public string? MainType { get; set; }
        public string? SubType { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }


        public string? TableName { get; set; }

        public Item(long id, double size, string material, string tableName)
        {
            this.Id = id;
            this.Size = size;
            this.Material = material;
            this.TableName = tableName;
        }

        public Item(long id, double size, string material, string colour, string tableName)
        {
            this.Id = id;
            this.Size = size;
            this.Material = material;
            this.Colour = colour;
            this.TableName = tableName;
        }

        public Item(long id, string patternModel, string patternSizes, string optionalInfo, string tableName)
        {
            this.Id = id;
            this.PatternModel = patternModel;
            this.PatternSizes = patternSizes;
            this.OptionalInfo = optionalInfo;
            this.TableName = tableName;
        }

        public Item(long id, string mainType, string subType, double width, double height, string tableName)
        {
            this.Id = id;
            this.MainType = mainType;
            this.SubType = subType;
            this.Width = width;
            this.Height = height;
            this.TableName = tableName;
        }

        public Item(long id, string colour, string optionalInfo, string tableName)
        {
            this.Id = id;
            this.Colour = colour;
            this.OptionalInfo = optionalInfo;
            this.TableName = tableName;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
