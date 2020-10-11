using System;
using System.Collections.Generic;
using System.Text;

namespace Techniche_Test.Shapes
{
    public class Square : Shape
    {
        private int Width { get; set; }
        public Square(string[] inputs) : base(inputs)
        {
            if (inputs.Length < 4)
            {
                throw new Exception($"Square - Constructor: inputs length is less then 4.\n\tString: {string.Join(", ", inputs)}");
            }

            int width;
            if (int.TryParse(inputs[3], out width) == false)
            {
                throw new Exception($"Square - Constructor: third element isn't a number.\n\tString: {string.Join(", ", inputs)}");
            }
            this.Width = width;
        }

        public override string GenerateOutput()
        {
            return $"Square ({this.PosX},{this.PosY}) size={this.Width}";
        }
    }
}
