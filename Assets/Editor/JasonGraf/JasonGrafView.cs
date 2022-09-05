using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace JasonGraf
{
    public class JasonGrafView : GraphView
    {
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
        }

        private void ImportUss()
        {
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/JasonGraf/JasonGrafEditor.uss");
            styleSheets.Add(styleSheet);
        }
    }
}