using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAccess.ViewModel
{
    public static class ValidationModel
    {
        private static readonly string _validBackground = "Transparent";
        private static readonly string _invalidBackground = "#DC143C";
        private static readonly string _validForeground = "#ADFF2F";
        private static readonly string _invalidForeground = "#f0f8ff";

        /// <summary>
        /// Colors to Validation. Item1 --> ForeGround, Item2 --> Background
        /// </summary>
        public static Tuple<string,string> Valid
        {
            get => new Tuple<string, string>(_validForeground, _validBackground);
        }

        /// <summary>
        /// Colors to Validation. Item1 --> ForeGround, Item2 --> Background
        /// </summary>
        public static Tuple<string, string> InValid
        {
            get => new Tuple<string, string>(_invalidForeground, _invalidBackground);
        }
    }
}
