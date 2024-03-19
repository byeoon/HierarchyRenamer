using UnityEditor;
using System.Diagnostics;

public class ExampleEditorScript
{
    [MenuItem("byeoon/HierarchyRenamer")]
    static void RunMainScript()
    {
        EditorUtility.DisplayDialog("HierarchyRenamer", "Hello world!", "Hello there!!");
    }

    [MenuItem("byeoon/Other/About")]
    static void GetAbout()
    {
        EditorUtility.DisplayDialog("HierarchyRenamer", "HierarchyRenamer is currently running version 1.0", "OK");
    }

      [MenuItem("byeoon/Other/Open GitHub Repository")]
    static void openRepository  ()
    {
        System.Diagnostics.Process.Start("explorer.exe", "http://github.com/byeoon/HierarchyRenamer");
    }
}
