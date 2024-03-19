using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

    public class RenamerMenu : EditorWindow
    {
        // VisualElements
        private static VisualElement _rootView;
        private static Button _refreshButton;
        private static Button _createButton;
        private static Button _resolveButton;
        private static Box _manifestInfo;
        private static Label _manifestLabel;
        private static Label _manifestInfoText;
        private static VisualElement _manifestPackageList;
        private static Color _colorPositive = Color.green;
        private static Color _colorNegative = new Color(1, 0.3f, 0.3f);
        private static Button _actionButton;
        private static TextField _authorUrlField;

        // Variables
        public static bool suffixMode = true;
        public static bool enableColoring = true;

        [MenuItem("byeoon/HierarchyRenamer")]
        public static void ShowWindow()
        {
            RenamerMenu wnd = GetWindow<RenamerMenu>();
            wnd.titleContent = new GUIContent("HierarchyRenamer");
            _rootView = rootVisualElement;
            _rootView.Add(RenamerButton());
            _rootView.styleSheets.Add((StyleSheet) Resources.Load("RenamerWindow"));
            
        }


       private VisualElement RenamerButton()
        {
            _actionButton = new Button(RenamerButtonPress)
            {
                text = "Rename",
                name = "action-button"
            };
            return _actionButton;
        }

        private void RenamerButtonPress()
        {
                if(suffixMode == true)
                {
                    UnityEngine.Debug.Log("[byeoon] You are now running with suffix mode enabled.");
                }
                else
                {
                    UnityEngine.Debug.Log("[byeoon] You are now running with suffix mode disabled.");
                }
        }

    }
