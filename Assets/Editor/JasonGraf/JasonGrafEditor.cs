using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace JasonGraf
{
    public class JasonGrafEditor : EditorWindow
    {
        private JasonGrafView _grafView;
        private JasonInspectorView _inspectorView;
        private Button _loadButton;
        private Button _saveButton;
        private Button _saveAsButton;

        private JasonGrafDocument _document = new JasonGrafDocument();
        private string _fileName = "json_graph.json";

        [MenuItem("Window/Jason Graf")]
        public static void OpenJasonGraf()
        {
            JasonGrafEditor wnd = GetWindow<JasonGrafEditor>();
            wnd.titleContent = new GUIContent("Jason Graf");
        }

        public void CreateGUI()
        {
            LoadSchema();

            _grafView = rootVisualElement.Q<JasonGrafView>();
            _inspectorView = rootVisualElement.Q<JasonInspectorView>();
            _loadButton = rootVisualElement.Q<Button>("load-button");
            _saveButton = rootVisualElement.Q<Button>("save-button");
            _saveAsButton = rootVisualElement.Q<Button>("save-as-button");

            _loadButton.clicked += OnLoadButtonClicked;
            _saveButton.clicked += OnSaveButtonClicked;
            _saveAsButton.clicked += OnSaveAsButtonClicked;

            _grafView.PopulateView(_document);
        }

        private void LoadSchema()
        {
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/JasonGraf/JasonGrafEditor.uxml");
            visualTree.CloneTree(rootVisualElement);
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/JasonGraf/JasonGrafEditor.uss");
            rootVisualElement.styleSheets.Add(styleSheet);
        }

        private void SaveToFile(string fileName)
        {
            var data = _document.Serialize();
            var str = JsonFacade.JsonToString(data);
            System.IO.File.WriteAllText(fileName, str);
        }

        private void SetFileName(string fileName)
        {
            _fileName = fileName;
            titleContent = new GUIContent($"Jason Graf: {_fileName}");
        }

        private void OnLoadButtonClicked()
        {
            var fileName = EditorUtility.OpenFilePanel("Open JSON file", ".", "json");
            if (string.IsNullOrEmpty(fileName))
                return;
            try
            {
                var fileContent = System.IO.File.ReadAllText(fileName);
                var data = JsonFacade.StringToJson(fileContent);
                _document.Parse(data);
                _grafView.PopulateView(_document);
                SetFileName(fileName);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }

        private void OnSaveButtonClicked()
        {
            SaveToFile(_fileName);
        }

        private void OnSaveAsButtonClicked()
        {
            var fileName = EditorUtility.SaveFilePanel("Save as JSON file", ".", "json_graph", "json");
            if (string.IsNullOrEmpty(fileName))
                return;
            SaveToFile(fileName);
            SetFileName(fileName);
        }
    }
}