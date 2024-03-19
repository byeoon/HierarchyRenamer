using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using UnityEditor;
using UnityEngine;


public class HierarchyRenamer
{
    [InitializeOnLoadMethod]
    static void OnLoad()
    {
        UnityEngine.Debug.Log("[byeoon] HierarchyRenamer has loaded successfully!");
    }

    [MenuItem("byeoon/HierarchyRenamer")]
    static void OpenWindowFunc()
    {
        RenamerMenu.ShowWindow();
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
