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

public class RenamerMenu: EditorWindow {
  // Visual Elements
  public VisualElement _rootView;
  private static Label _titleLabel;
  private static Image _imageLogo;
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

  public static UnityEngine.GameObject publicObj;

  private static bool _IsOn;
  public static bool IsOn {
    get {
      return _IsOn;
    }
    set {
      _IsOn = value;
    }
  }

  [MenuItem("byeoon/HierarchyRenamer")]
  public static void ShowWindow() {
    RenamerMenu wnd = GetWindow < RenamerMenu > ();
    wnd.titleContent = new GUIContent("HierarchyRenamer");
  }

  private void CreateGUI() {
    _rootView = rootVisualElement;
    _rootView.Add(TitleLabel());
    _rootView.Add(ImageThing());
    _rootView.Add(RenamerInput());
    _rootView.styleSheets.Add((StyleSheet) Resources.Load("RenamerWindow"));
  }

  private void RenameButtonClicked() {
    Debug.Log("[byeoon] Successfully renamed with suffix: " + publicSuffixName);
    if (enableColoring) {
      IsOn = !IsOn;
      EditorApplication.RepaintHierarchyWindow();
    }

    publicObj.name = publicObj.name + " " + publicSuffixName;
    Undo.RegisterFullObjectHierarchyUndo(publicObj, "Recursive Rename");
    AddSuffixToAllChildren(publicObj.transform, " " + publicSuffixName);
  }

  private VisualElement RenamerInput() {
    _authorNameField = new TextField("Suffix: ");
    _objectSelector = new ObjectField("Object: ") {
      objectType = typeof (GameObject),
    };
    _checkboxColor = new Toggle("Enable Color Highlight:");
    _colorPicker = new ColorField("Color: ");
    _colorPicker.visible = false;
    enableColoring = false;

    _renameButton = new Button(RenameButtonClicked) {
      text = "Rename & Apply",
        name = "action-button"
    };

    _authorNameField.RegisterValueChangedCallback((evt) => {
      publicSuffixName = evt.newValue;
    });

    _objectSelector.RegisterValueChangedCallback((evt) => {
      publicObj = (GameObject) evt.newValue;
    });

    _checkboxColor.RegisterValueChangedCallback((evt) => {
      _colorPicker.visible = evt.newValue;
      enableColoring = evt.newValue;
    });

    _colorPicker.RegisterValueChangedCallback((evt) => {
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

  private VisualElement TitleLabel() {
    _titleLabel = new Label(" \nHierarchyRenamer");
    return _titleLabel;
  }

  [MenuItem("byeoon/Reset Hierarchy Colors")]
  static void ResetColors() {
    ResetColoring();
  }

  private VisualElement ImageThing() {
    _imageLogo = new Image() {};
    return _imageLogo;
  }

  [MenuItem("byeoon/Other/About")]
  static void OpenAboutMessage() {
    EditorUtility.DisplayDialog("HierarchyRenamer", "HierarchyRenamer is currently running version 1.0.1", "OK");
  }

  [MenuItem("byeoon/Other/Open GitHub Repository")]
  static void OpenRepositoryLink() {
    System.Diagnostics.Process.Start("explorer.exe", "http://github.com/byeoon/HierarchyRenamer");
  }

  private static void AddSuffixToAllChildren(Transform parent, string suffix) {
    if (parent == null) return;

    if (!parent.name.EndsWith(suffix)) {
      parent.name += suffix;
    }

    foreach(Transform child in parent) {
      AddSuffixToAllChildren(child, suffix);
    }
  }

  [InitializeOnLoadMethod]
  static void InitColorHighlighting() {
    EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
  }

  private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect) {
    if (!IsOn || !enableColoring || publicObj == null) return;

    GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
    if (obj == null) return;

    if (IsPartOfHierarchy(publicObj.transform, obj.transform)) {
      EditorGUI.DrawRect(selectionRect, rgbThing);
      EditorGUI.LabelField(selectionRect, obj.name, new GUIStyle() {
        normal = new GUIStyleState() {
            textColor = Color.black
          },
          fontStyle = FontStyle.Bold
      });
    }
  }

  private static bool IsPartOfHierarchy(Transform root, Transform target) {
    if (target == null) return false;
    if (target == root) return true;

    Transform current = target.parent;
    while (current != null) {
      if (current == root)
        return true;
      current = current.parent;
    }

    return false;
  }

  private static void ResetColoring() {
    enableColoring = false;
    IsOn = false;
    rgbThing = Color.clear;

    if (_checkboxColor != null) _checkboxColor.value = false;
    if (_colorPicker != null) _colorPicker.value = Color.clear;

    EditorApplication.RepaintHierarchyWindow();
  }

}
