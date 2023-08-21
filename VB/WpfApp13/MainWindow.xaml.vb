Imports DevExpress.Diagram.Core
Imports DevExpress.Xpf.Diagram
Imports System.Windows
Imports System.Windows.Media

Namespace WpfApp13

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            RegisterStencil()
        End Sub

        Private Sub RegisterStencil()
            Dim stencil = New DiagramStencil("CustomStencil", "Custom Shapes")
            Dim itemTool = New FactoryItemTool("CustomShape1", Function() "Custom Shape 1", Function(diagram) CreateContainerShape1(), New Size(200, 200), False)
            stencil.RegisterTool(itemTool)
            DiagramToolboxRegistrator.RegisterStencil(stencil)
            Me.diagramControl1.SelectedStencils = New StencilCollection() From {"CustomStencil"}
        End Sub

        Public Function CreateContainerShape1() As DiagramContainer
            Dim container = New DiagramContainer()
            container.StrokeThickness = 0
            container.Background = Brushes.Transparent
            Dim innerShape1 = New DiagramShape() With {.CanSelect = False, .CanChangeParent = False, .CanEdit = False, .CanCopyWithoutParent = False, .CanDeleteWithoutParent = False, .CanMove = False, .Shape = BasicShapes.Trapezoid, .Anchors = Sides.Top Or Sides.Left Or Sides.Right, .Height = 50, .Width = 200, .Content = "Custom text"}
            Dim innerShape2 = New DiagramShape() With {.CanSelect = False, .CanChangeParent = False, .CanEdit = False, .CanCopyWithoutParent = False, .CanDeleteWithoutParent = False, .CanMove = False, .Shape = BasicShapes.Rectangle, .Anchors = Sides.All, .Height = 150, .Width = 200, .Position = New Point(0, 50)}
            container.Items.Add(innerShape1)
            container.Items.Add(innerShape2)
            Return container
        End Function
    End Class
End Namespace
