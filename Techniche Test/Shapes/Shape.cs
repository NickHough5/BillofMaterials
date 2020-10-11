using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Techniche_Test.Interfaces;

namespace Techniche_Test.Shapes
{
    public abstract class Shape : IShape
    {
        protected int PosX = 0;
        protected int PosY = 0;

        public Shape(string[] inputs)
        {
            if(inputs.Length < 3)
            {
                throw new Exception($"Shape - Constructor: inputs length is less then 3.\n\tString: {string.Join(", ", inputs)}");
            }

            int posX;
            if(int.TryParse(inputs[1], out posX) == false)
            {
                throw new Exception($"Shape - Constructor: second element isn't a number.\n\tString: {string.Join(", ", inputs)}");
            }
            this.PosX = posX;

            int posY;
            if(int.TryParse(inputs[2], out posY) == false)
            {
                throw new Exception($"Shape - Constructor: third element isn't a number.\n\tString: {string.Join(", ", inputs)}");
            }
            this.PosY = posY;
        }

        public abstract string GenerateOutput();
    }
}
