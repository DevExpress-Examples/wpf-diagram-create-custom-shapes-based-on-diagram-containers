<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1174650)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Diagram - Create Custom Shapes Based on Diagram Containers

This example demonstrates how to create custom shapes (that are [DiagramContainers](https://docs.devexpress.com/WPF/DevExpress.Xpf.Diagram.DiagramContainer)) with multiple inner shapes. You can use this technique to create custom shapes if their geometry should consist of predefined shapes combined together.

![image](https://github.com/DevExpress-Examples/wpf-shapes-based-on-diagramcontainers/assets/65009440/9be4713a-dfd8-4ef1-988e-74062609d39f)

## Implementation Details

Follow the steps below to accomplish this task:

1. Create a container and add static non-selectable shapes:

   ```cs
   public DiagramContainer CreateContainerShape1() {
       var container = new DiagramContainer();
       container.StrokeThickness = 0;
       container.Background = Brushes.Transparent;

       var innerShape1 = new DiagramShape() {
           CanSelect = false,
           CanChangeParent = false,
           CanEdit = false,
           CanCopyWithoutParent = false,
           CanDeleteWithoutParent = false,
           CanMove = false,
           Shape = BasicShapes.Trapezoid,
           Anchors = Sides.Top | Sides.Left | Sides.Right,
           Height = 50,
           Width = 200,

           Content = "Custom text"
       };

       var innerShape2 = new DiagramShape() {
           CanSelect = false,
           CanChangeParent = false,
           CanEdit = false,
           CanCopyWithoutParent = false,
           CanDeleteWithoutParent = false,
           CanMove = false,
           Shape = BasicShapes.Rectangle,
           Anchors = Sides.All,
           Height = 150,
           Width = 200,
           Position = new Point(0, 50),
       };

       container.Items.Add(innerShape1);
       container.Items.Add(innerShape2);

       return container;
   }
   ```

2. Register a [FactoryItemTool](https://docs.devexpress.com/CoreLibraries/DevExpress.Diagram.Core.FactoryItemTool) that creates an instance of this container:

   ```cs
   void RegisterStencil() {
       var stencil = new DiagramStencil("CustomStencil", "Custom Shapes");

       var itemTool = new FactoryItemTool("CustomShape1",
           () => "Custom Shape 1",
           diagram => CreateContainerShape1(),
           new System.Windows.Size(200, 200),
           false
       );

       stencil.RegisterTool(itemTool);
       DiagramToolboxRegistrator.RegisterStencil(stencil);

       diagramControl1.SelectedStencils = new StencilCollection() { "CustomStencil" };
   }
   ```

## Files to Review

- [MainWindow.xaml.cs](./CS/WpfApp13/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApp13/MainWindow.xaml.vb))

## Documentation

- [DiagramContainer](https://docs.devexpress.com/WPF/DevExpress.Xpf.Diagram.DiagramContainer)
- [Containers and Lists](https://docs.devexpress.com/WPF/117205/controls-and-libraries/diagram-control/diagram-items/containers)
- [Shapes](https://docs.devexpress.com/WPF/116099/controls-and-libraries/diagram-control/diagram-items/shapes)
- [Manage Item Interaction](https://docs.devexpress.com/WPF/120257/controls-and-libraries/diagram-control/diagram-items/managing-items-interaction)

## More Examples

- [WPF DiagramControl - Register FactoryItemTools for Regular and Custom Shapes](https://github.com/DevExpress-Examples/wpf-diagram-register-factoryitemtools-for-shapes)
- [WPF DiagramControl - Create Rotatable Containers with Shapes](https://github.com/DevExpress-Examples/wpf-diagram-create-rotatable-containers-with-shapes)
