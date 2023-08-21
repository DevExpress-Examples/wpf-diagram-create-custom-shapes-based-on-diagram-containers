﻿using DevExpress.Diagram.Core;
using DevExpress.Xpf.Diagram;
using System.Windows;
using System.Windows.Media;

namespace WpfApp13 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            RegisterStencil();
        }

        void RegisterStencil() {
            var stencil = new DiagramStencil("CustomStencil", "Custom Shapes");

            var itemTool = new FactoryItemTool("CustomShape1",
                () => "Custom Shape 1",
                diagram => CreateContainerShape1(),
                new System.Windows.Size(200, 200), false);

            stencil.RegisterTool(itemTool);
            DiagramToolboxRegistrator.RegisterStencil(stencil);

            diagramControl1.SelectedStencils = new StencilCollection() { "CustomStencil" };
        }

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
    }
}
