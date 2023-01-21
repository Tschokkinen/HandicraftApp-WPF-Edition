using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HandicraftApp
{
    public class TextBoxValidation : IDataErrorInfo
    {
        private string? textBoxOne;
        public string? TextBoxOne
        {
            get { return textBoxOne; }
            set { textBoxOne = value; }
        }

        private string? textBoxTwo;
        public string? TextBoxTwo
        {
            get { return textBoxTwo; }
            set { textBoxTwo = value; }
        }

        private string? textBoxThree;
        public string? TextBoxThree
        {
            get { return textBoxThree; }
            set { textBoxThree = value; }
        }

        private string? textBoxFour;
        public string? TextBoxFour
        {
            get { return textBoxFour; }
            set { textBoxFour = value; }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string item]
        {
            get
            {
                string? result = null;

                if (item == "TextBoxOne")
                {
                    if (textBoxOne == "")
                    {
                        result = "Kenttä ei voi olla tyhjä.";
                    }
                }
                else if (item == "TextBoxTwo")
                {
                    if (textBoxTwo == "")
                    {
                        result = "Kenttä ei voi olla tyhjä.";
                    }
                }
                else if (item == "TextBoxThree")
                {
                    if (textBoxThree == "")
                    {
                        result = "Kenttä ei voi olla tyhjä.";
                    }
                }
                else if (item == "TextBoxFour")
                {
                    if (textBoxFour == "")
                    {
                        result = "Kenttä ei voi olla tyhjä.";
                    }
                }
                return result;
            }
        }
    }
}
