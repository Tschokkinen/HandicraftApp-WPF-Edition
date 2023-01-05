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

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
