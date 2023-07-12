### Problem Description

It is required to develop a graphical application that displays
not intersecting triangles of the same color but different shades on a rectangular surface.
Two triangles are considered intersecting if they overlap each other without complete overlap.

Starting from the outermost region (rectangular area), all shapes are filled
in with the selected shade of color, first with the lightest and for a more nested triangle with a
darker shade.

The program should calculate how many different shades are required for colorizing (text in the upper left corner
of the application window). If the collection of triangles contains intersecting triangles, then
the word `ERROR` should be shown instead of the number of shades.

### Input Example

The collection of triangles to display is set in the input file. The first line of the file
contains one non-negative number `n (n <= 1000)`, which specifies the number of triangles.
The following `n` lines contain a description of the triangles in the format x<sub>1</sub> y<sub>1</sub> x<sub>2</sub> y<sub>2</sub> x<sub>3</sub> y<sub>3</sub>,
where x<sub>i</sub>, y<sub>i</sub> (0 <= x<sub>i</sub>, y<sub>i</sub>  < = 1000) - coordinates of the vertices of the triangles.
Three points are guaranteed not to be collinear.

 ```sh
8
450 150 450 200 400 200
750 650 0 450 500 0
100 400 400 350 250 500
300 500 600 400 700 600
500 500 600 500 600 450
150 350 500 50 550 300
300 250 300 300 450 300
500 100 500 250 350 200
 ```

### Screenshots

![image](https://github.com/Lozovskij/Triangles-Problem-WinForms/assets/56762093/2de2ee50-9e8d-48af-adca-8f6326f590b4)
![image](https://github.com/Lozovskij/Triangles-Problem-WinForms/assets/56762093/8c20e87a-1381-4cbe-b2e2-bde8315d8cd8)

### Built With

- Windows Forms (.NET Framework)
- MVP Design Pattern
