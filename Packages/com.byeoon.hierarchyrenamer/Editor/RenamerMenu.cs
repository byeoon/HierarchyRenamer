using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class RenamerMenu : EditorWindow
{
    // Visual Elements
    public VisualElement _rootView;
    private static Label _titleLabel;
    private Button _renameButton;
    private static TextField _authorNameField;

    private static Toggle _checkboxColor;
    private static ColorField _colorPicker;
    private static ObjectField _objectSelector;

    // Variables
    public static bool enableColoring = true;

    public static string publicObjectName;
    public static string publicSuffixName;
    public static Color rgbThing;



    [MenuItem("byeoon/HierarchyRenamer")]
    public static void ShowWindow()
    {
        RenamerMenu wnd = GetWindow<RenamerMenu>();
        wnd.titleContent = new GUIContent("HierarchyRenamer");
    }

    private void CreateGUI()
    {
        _rootView = rootVisualElement;
        _rootView.Add(RenamerInput());
        _rootView.styleSheets.Add((StyleSheet)Resources.Load("RenamerWindow"));
    }

    private void RenameButtonClicked()
    {

        Debug.Log("Debug: " + "obj: " + publicObjectName + "sufix: " +  publicSuffixName);
        if (enableColoring)
        {
            EditorApplication.RepaintHierarchyWindow();
            Debug.Log("[byeoon] Finished with colored hierarchy.");
            
        }
        Debug.Log(_objectSelector);
    }

    private VisualElement RenamerInput()
    {
        _authorNameField = new TextField("Suffix: ");
        _objectSelector = new ObjectField("Object: ")
        {
            objectType = typeof(GameObject),
        };
        _checkboxColor = new Toggle("Enable Color Highlight:");
        _colorPicker = new ColorField("Color: ");
        _colorPicker.visible = false;
        enableColoring = false;
        _renameButton = new Button(RenameButtonClicked)
        {
            text = "Rename & Apply",
            name = "action-button"
        };

        _authorNameField.RegisterValueChangedCallback((evt) =>
        {
            Debug.Log($"Window author name is {evt.newValue}");
            publicSuffixName = evt.newValue;

            EditorApplication.RepaintHierarchyWindow();
        });

        _objectSelector.RegisterValueChangedCallback((evt) =>
       {
           publicObjectName = evt.newValue;
           Debug.Log($"Name of object: {evt.newValue}");
       });

        _checkboxColor.RegisterValueChangedCallback((evt) =>
        {
            _colorPicker.visible = evt.newValue;
            enableColoring = evt.newValue;

        });

        _colorPicker.RegisterValueChangedCallback((evt) =>
          {
              rgbThing = evt.newValue;
          });

        var box = new Box();
        box.Add(_authorNameField);
        box.Add(_objectSelector);
        box.Add(_checkboxColor);
        box.Add(_colorPicker);
        box.Add(_renameButton);
        return box;
    }

    [MenuItem("byeoon/Other/About")]
    static void OpenAboutMessage()
    {
        EditorUtility.DisplayDialog("HierarchyRenamer", "HierarchyRenamer is currently running version 1.0", "OK");
    }

    [MenuItem("byeoon/Other/Open GitHub Repository")]
    static void OpenRepositoryLink()
    {
        System.Diagnostics.Process.Start("explorer.exe", "http://github.com/byeoon/HierarchyRenamer");
    }

}
