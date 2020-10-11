using System;
using System.Collections.Generic;
using System.Text;

namespace Techniche_Test.Shapes
{
    public class Ellipse : Shape
    {
        private int HorizontalDiameter { get; set; }
        private int VerticalDiameter { get; set; }
        public Ellipse(string[] inputs) : base(inputs)
        {
            if (inputs.Length < 5)
            {
                throw new Exception($"Ellipse - Constructor: inputs length is less then 5.\n\tString: {string.Join(", ", inputs)}");
            }

            int horizontalDiameter;
            if (int.TryParse(inputs[3], out horizontalDiameter) == false)
            {
                throw new Exception($"Ellipse - Constructor: third element isn't a number.\n\tString: {string.Join(", ", inputs)}");
            }
            this.HorizontalDiameter = horizontalDiameter;

            int verticalDiameter;
            if (int.TryParse(inputs[4], out verticalDiameter) == false)
            {
                throw new Exception($"Ellipse - Constructor: third element isn't a number.\n\tString: {string.Join(", ", inputs)}");
            }
            this.VerticalDiameter = verticalDiameter;
        }

        public override string GenerateOutput()
        {
            return $"Ellipse ({this.PosX},{this.PosY}) diameterH = {this.HorizontalDiameter} diameterV = {this.VerticalDiameter}";
        }
    }
}
