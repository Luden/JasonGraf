using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace JasonGraf
{
    public class JasonGrafEditor : EditorWindow
    {
        private JasonGrafView _grafView;
        private JasonInspectorView _inspectorView;

        [MenuItem("Window/Cheats/Jason Graf")]
        public static void OpenJasonGraf()
        {
            JasonGrafEditor wnd = GetWindow<JasonGrafEditor>();
            wnd.titleContent = new GUIContent("Jason Graf");
        }

        public void CreateGUI()
        {
            ImportUxml();
            ImportUss();

            _grafView = rootVisualElement.Q<JasonGrafView>();
            _inspectorView = rootVisualElement.Q<JasonInspectorView>();
        }

        private void ImportUxml()
        {
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/JasonGraf/JasonGrafEditor.uxml");
            visualTree.CloneTree(rootVisualElement);
        }

        private void ImportUss()
        {
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/JasonGraf/JasonGrafEditor.uss");
            rootVisualElement.styleSheets.Add(styleSheet);
        }
    }
}