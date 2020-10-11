using System;
using System.Collections.Generic;
using System.Text;

namespace Techniche_Test.Shapes
{
    public class Rectangle : Shape
    {
        protected int Width { get; set; }
        protected int Height { get; set; }
        public Rectangle(string[] inputs) : base(inputs)
        {
            if (inputs.Length < 5)
            {
                throw new Exception($"Rectangle - Constructor: inputs length is less then 5.\n\tString: {string.Join(", ", inputs)}");
            }

            int width;
            if (int.TryParse(inputs[3], out width) == false)
            {
                throw new Exception($"Rectangle - Constructor: third element isn't a number.\n\tString: {string.Join(", ", inputs)}");
            }
            this.Width = width;

            int height;
            if (int.TryParse(inputs[4], out height) == false)
            {
                throw new Exception($"Rectangle - Constructor: fourth element isn't a number.\n\tString: {string.Join(", ", inputs)}");
            }
            this.Height = height;
        }

        public override string GenerateOutput()
        {
            return $"Rectangle ({this.PosX},{this.PosY}) width={this.Width} height={this.Height}";
        }
    }
}
