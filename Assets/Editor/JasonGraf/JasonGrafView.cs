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
            foreach (var nodeView in elements.Cast<JasonNodeView>()) // todo: take only roots
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
                    if (graphElement is JasonNodeView jasonNodeView)
                        _document.RemoveNode(jasonNodeView.Node);
                }
            }
            return graphviewchange;
        }

        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            base.BuildContextualMenu(evt);
            evt.menu.AppendAction("Add node", x => AddNode());
        }

        public void AddNode()
        {
            var jasonNode = _document.AddNode();
            CreateNodeView(jasonNode);
        }

        private void ImportUss()
        {
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/JasonGraf/JasonGrafEditor.uss");
            styleSheets.Add(styleSheet);
        }

        private void CreateNodeView(JasonNode node)
        {
            var nodeView = new JasonNodeView(node);
            AddElement(nodeView);
        }


    }
}