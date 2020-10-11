# Bill of Materials
A scalable application that allows users to specify any number of shapes to generate. These then get output to the console and to a file.

## Inputs
As part of this project there are some command line inputs.
1. Output file name (within the project, this is currently set to output.txt)
2. Input file names, you can have as many input files as you wish (within the project, this is currently set to input.txt)

## Information
This application was created using C# .Net Core 3.1.
It is therefore recommended to use .Net Core 3.1 when trying to compile and run this application.

## Inputs and Outputs
By default this project comes with a file called input.txt, this will contain the information that you wish to convert to the following examplar output.

``
----------------------------------------------------------------
Bill of Materials
----------------------------------------------------------------
Rectangle (10,10) width=30 height=40
Square (15,30) size=35
Ellipse (100,150) diameterH = 300 diameterV = 200
Circle (1,1) size=300
Textbox (5,5) width=200 height=100 text="sample text"
----------------------------------------------------------------
``

The input is a simple CSV, where the first column contains the "widget" type and the following columns are the properties of that widget.
Below is an example of this input.txt file:
``
	Rectangle,10,10,30,40
	Square,15,30,35
	Ellipse,100,150,300,200
	Circle,1,1,300
	Textbox,5,5,200,100,sample text
``
Do note that the input properties must match the following formats
``
Rectangle
	Position X - integer
	Position Y - integer
	Width - integer
	Height - integer
Square
	Position X - integer
	Position Y - integer
	Width - integer
Ellipse
	Position X - integer
	Position Y - integer
	Horizontal Diameter - integer
	Vertical Diameter - integer
Circle
	Position X - integer
	Position Y - integer
	Diameter - integer
Textbox
	Position X - integer
	Position Y - integer
	Width - integer
	Height - integer
	Text - string
``
Note, any "string" types, do NOT require quotes around them within the CSV file. But also string types can NOT contain any commas.