using System;

namespace Techniche_Test.Shapes
{
    public class Textbox : Shape
    {
        protected int Width { get; set; }
        protected int Height { get; set; }
        protected string Text { get; set; }
        public Textbox(string[] inputs) : base(inputs)
        {
            if (inputs.Length < 6)
            {
                throw new Exception($"Textbox - Constructor: inputs length is less then 6.\n\tString: {string.Join(", ", inputs)}");
            }

            int width;
            if (int.TryParse(inputs[3], out width) == false)
            {
                throw new Exception($"Textbox - Constructor: third element isn't a number.\n\tString: {string.Join(", ", inputs)}");
            }
            this.Width = width;

            int height;
            if (int.TryParse(inputs[4], out height) == false)
            {
                throw new Exception($"Textbox - Constructor: fourth element isn't a number.\n\tString: {string.Join(", ", inputs)}");
            }
            this.Height = height;

            this.Text = inputs[5];
        }

        public override string GenerateOutput()
        {
            return $"Textbox ({this.PosX},{this.PosY}) width={this.Width} height={this.Height} text=\"{this.Text}\"";
        }
    }
}
