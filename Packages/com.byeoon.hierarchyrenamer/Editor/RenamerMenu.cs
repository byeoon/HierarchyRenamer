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

        [MenuItem("byeoon/HierarchyRenamer")]
        public static void ShowWindow()
        {
            RenamerMenu wnd = GetWindow<RenamerMenu>();
            wnd.titleContent = new GUIContent("HierarchyRenamer");
        }


       private VisualElement CreateInitialButton()
        {
            _actionButton = new Button(OnActionButtonPressed)
            {
                text = "Rename",
                name = "action-button"
            };
            return _actionButton;
        }

        private void OnActionButtonPressed()
        {
            bool result = EditorUtility.DisplayDialog("HierarchyRenamer",
                $"This will rename everything inside of this asset to what you selected.",
                "Ok", "Wait, not yet.");
            if (result)
            {
                UnityEditor.PackageManager.Client.Resolve();
            }
        }

    }
