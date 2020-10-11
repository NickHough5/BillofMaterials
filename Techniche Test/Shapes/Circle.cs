using System;
using System.Collections.Generic;
using System.Text;

namespace Techniche_Test.Shapes
{
    public class Circle : Shape
    {
        private int Diameter { get; set; }
        public Circle(string[] inputs) : base(inputs)
        {
            if (inputs.Length < 4)
            {
                throw new Exception($"Circle - Constructor: inputs length is less then 4.\n\tString: {string.Join(", ", inputs)}");
            }

            int diameter;
            if (int.TryParse(inputs[3], out diameter) == false)
            {
                throw new Exception($"Circle - Constructor: third element isn't a number.\n\tString: {string.Join(", ", inputs)}");
            }
            this.Diameter = diameter;
        }

        public override string GenerateOutput()
        {
            return $"Circle ({this.PosX},{this.PosY}) size={this.Diameter}";
        }
    }
}
