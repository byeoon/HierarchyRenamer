using System.Linq;
using UnityEngine;
using UnityEditor;
// todo: make the color thing work in the Renamer part, making it an option instead of it being an extension.
// this is basically a base for until i get home and continue testing on it or just a proof of concept


namespace HierarchyColoring {

    [InitializeOnLoad]
    public class HierarchyColoringUtil
    {
    public static Color DefaultColor = new Color(0.2196079f, 0.2196079f, 0.2196079f, 1f);
    public static Color DefaultColorSelect = new Color(0.243f, 0.4901f, 0.9058f, 1f);
        static HierarchyColoringUtil()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= HierarchySelectOnGUI;
            EditorApplication.hierarchyWindowItemOnGUI += HierarchySelectOnGUI;
        }

        public static void HierarchySelectOnGUI(int id, Rect rect)
        {
            GameObject objectLabel = EditorUtility.InstanceIDToObject(id) as GameObject;
            if(objectLabel != null)
            {
                HierarchyRenamer customLabel = objectLabel.GetComponent<HierarchyRenamer>();
                if (customLabel != null && Event.current.type == EventType.Repaint) {
                    bool selected = Selection.instanceIDs.Contains(id);
                    Color setBackgroundColor = customLabel.Background_Color;
                    Rect customRect = new Rect(rect.position + new Vector2(2f, 0f), rect.size);

                    if (setBackgroundColor.a > 0f)
                    {
                        Rect customRectOffset = new Rect(rect.position, rect.size);
                        if (customLabel.Background_Color.a < 1f || selected) {
                            EditorGUI.DrawRect(customRectOffset, DefaultColorSelect);
                        }
                        if (selected) {
                            EditorGUI.DrawRect(customRectOffset, Color.Lerp(GUI.skin.settings.selectionColor, setBackgroundColor, 0.3f));
                        }    
                        else {
                            EditorGUI.DrawRect(customRectOffset, setBackgroundColor); 
                        }
                            
                    }
                    EditorApplication.RepaintHierarchyWindow();
                }
        }
    }
    }
}