using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace JasonGraf
{
    public class JasonGrafView : GraphView
    {
        private JasonGrafDocument _document;

        public new class UxmlFactory : UxmlFactory<JasonGrafView, GraphView.UxmlTraits>
        {
        }

        public JasonGrafView()
        {
            ImportUss();

            Insert(0, new GridBackground());
            this.AddManipulator(new ContentZoomer());
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());

            serializeGraphElements = SerializeGraphElementsImpl;
            canPasteSerializedData = CanPasteSerializedDataImpl;
            unserializeAndPaste = UnserializeAndPasteImpl;
        }

        private void UnserializeAndPasteImpl(string operationname, string str)
        {
            var data = JsonFacade.StringToJson(str);
            var document = new JasonGrafDocument();
            document.Parse(data);

            foreach (var node in document.Nodes)
            {
                _document.AddNode(node);
                CreateNodeView(node);
            }
        }

        private bool CanPasteSerializedDataImpl(string data)
        {
            return JsonFacade.IsJson(data);
        }

        private string SerializeGraphElementsImpl(IEnumerable<GraphElement> elements)
        {
            var document = new JasonGrafDocument();
            foreach (var nodeView in elements.OfType<JasonNodeView>()) // todo: take only roots
                document.AddNode(nodeView.Node);
            var data = document.Serialize();
            return JsonFacade.JsonToString(data);
        }

        public void PopulateView(JasonGrafDocument document)
        {
            _document = document;
            graphViewChanged -= OnGraphViewChanged;
            DeleteElements(graphElements.ToList());
            graphViewChanged += OnGraphViewChanged;
            foreach (var node in _document.Nodes)
                CreateNodeView(node);
        }

        private GraphViewChange OnGraphViewChanged(GraphViewChange graphviewchange)
        {
            if (graphviewchange.elementsToRemove != null)
            {
                foreach (var graphElement in graphviewchange.elementsToRemove)
                {
                    if (graphElement is Node node)
                    {
                        RemoveGraphNode(node);
                    }
                    if (graphElement is Edge edge)
                    {
                        RemoveGraphEdge(edge);
                    }
                }
            }
            if (graphviewchange.edgesToCreate != null)
            {
                foreach (var edge in graphviewchange.edgesToCreate)
                {
                    var parentNode = (JasonNodeView)edge.output.node;
                    var childNode = (JasonNodeView)edge.input.node;
                    parentNode.AttachNode(edge.output, childNode);
                    _document.RemoveNode(childNode.Node);
                }
            }
            return graphviewchange;
        }

        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            base.BuildContextualMenu(evt);
            evt.menu.AppendAction("Add node", x => AddNode());
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            return ports.ToList().Where(p => p.direction != startPort.direction && p.node != startPort.node).ToList();
        }

        public void AddNode()
        {
            var jasonNode = _document.AddNode();
            CreateNodeView(jasonNode);
        }

        private void RemoveGraphNode(Node node)
        {
            if (node is JasonNodeView jasonNodeView)
                _document.RemoveNode(jasonNodeView.Node);
            foreach (var graphEdge in graphElements.ToList().OfType<Edge>())
            {
                var shouldAlsoRemove = graphEdge.output.node == node || graphEdge.input.node == node;
                if (shouldAlsoRemove)
                    RemoveGraphEdge(graphEdge);
            }
            RemoveElement(node);
        }

        private void RemoveGraphEdge(Edge edge)
        {
            var parentNode = edge.output.node as JasonNodeView;
            var childNode = edge.input.node as JasonNodeView;
            if (parentNode != null)
                parentNode.DetachNode(edge.output, childNode);
            if (childNode != null)
                _document.AddNode(childNode.Node);
            RemoveElement(edge);
        }

        private void ImportUss()
        {
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/JasonGraf/JasonGrafEditor.uss");
            styleSheets.Add(styleSheet);
        }

        public JasonNodeView CreateNodeView(JasonNode node)
        {
            var nodeView = new JasonNodeView(this, node);
            AddElement(nodeView);
            return nodeView;
        }

        public Edge CreateEdge(Port output, Port input)
        {
            var edge = output.ConnectTo(input);
            AddElement(edge);
            return edge;
        }
    }
}