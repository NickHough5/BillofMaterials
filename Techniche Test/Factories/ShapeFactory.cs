using System;
using System.Collections.Generic;
using System.Text;
using Techniche_Test.Shapes;
using Techniche_Test.Interfaces;
using System.Data;

namespace Techniche_Test.Factories
{
    public static class ShapeFactory
    {
        //public static IShape Create(ShapeEnum shapeEnum)
        public static IShape Create(string input)
        {
            string[] inputArray = input.Split(',');
            
            IShape shape = inputArray[0].ToLowerInvariant() switch
            {
                "rectangle" => new Rectangle(inputArray),
                "square" => new Square(inputArray),
                "ellipse" => new Ellipse(inputArray),
                "circle" => new Circle(inputArray),
                "textbox" => new Textbox(inputArray),
                _ => throw new Exception($"ShapeFactory - Create: Shape has not been implemented.\n\tString: {input}")
            };

            return shape;
        }
    }
}
