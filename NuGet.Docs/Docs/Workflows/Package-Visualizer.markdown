# Package Visualizer

A new feature added in NuGet 1.4 enables you to easily visualize all the projects and their 
package dependencies within a solution.

Click on the **Tools** -> **Library Package Manager** -> **Package Visualizer** menu option to launch 
the Package Visualizer.

_**Important Note:** This feature takes advantage of the DGML support in Visual Studio. Creating the visualization is only 
supported in Visual Studio Ultimate. Viewing a DGML diagram is only supported in Visual Studio Premium or Higher._

This will bring up a diagram of all of the projects in your solution along with their package dependencies.

![Package Visualizer Diagram](Images/package-visualizer.png)

When viewing a diagram, a new toolbar enables visualizing the dependencies in different ways.

![Package Visualizer Toolbar](Images/package-visualizer-toolbar.png)

For example, the following is a cluster view of the package dependencies.

![Package Visualizer Cluster View](Images/package-visualizer-cluster.png)

You can also generate a dependency matrix.

![Package Visualizer Dependency Matrix](Images/package-visualizer-matrix.png)

## Package Visualizer Format
The Package Visualizer uses the [DGML format](http://en.wikipedia.org/wiki/DGML) for 
generating directed graphs. Support for reading DGML files is built into Visual Studio 
2010 Premium and higher and support for creating DGML files is built into Visual Studio 2010 Ultimate.

The Package Visualizer creates a file named `Packages.dgml` in the root of your 
solution.