### Problem Description

It is required to develop a graphical application that displays
not intersecting triangles of the same color but different shades on a rectangular surface.
Two triangles are considered intersecting if they overlap each other without complete overlap.

Starting from the outermost region (rectangular area), all shapes are filled
in with the selected shade of color, first with the lightest and for a more nested triangle with a
darker shade.

The program should calculate how many different shades are required for colorizing (text in the upper left corner
of the application window). If the collection of triangles contains intersecting triangles, then
the word ERROR should be shown instead of the number of shades.

### Input Example
 
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

![image](https://github.com/Lozovskij/Triangles-Problem-WinForms/assets/56762093/c73b2cbe-4540-455a-9a18-7c7a34dcea2a)
![image](https://github.com/Lozovskij/Triangles-Problem-WinForms/assets/56762093/2d5ee3d2-43c7-4441-841c-66d39c98732c)

### Built With

- Windows Forms (.NET Framework)
- MVP Design Pattern
