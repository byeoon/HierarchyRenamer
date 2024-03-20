using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;


[UnityEditor.InitializeOnLoad]
#endif
public class RealHierarchyShit
{
    private static Vector2 offset = new Vector2(20, 1);

    static RealHierarchyShit()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
    }

    private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {

        var obj = EditorUtility.InstanceIDToObject(instanceID);
        if (obj != null)
        {
            Color backgroundColor = Color.white;
            Color textColor = Color.white;
            Texture2D texture = null;
             Debug.Log("TEST? " + obj);

            if (obj.name == RenamerMenu.publicObjectName)
            {
                backgroundColor = RenamerMenu.rgbThing;
                textColor = new Color(0.9f, 0.9f, 0.9f);
                obj.name += RenamerMenu.publicSuffixName;
                Debug.Log("Not Null? " + obj);
            }
            if(!RenamerMenu.enableColoring)
            {
                backgroundColor = new Color(0.9f, 0.9f, 0.0f, 0.01f);
                textColor = new Color(0.9f, 0.9f, 0.9f, 0.01f);
            }

            if (backgroundColor != Color.white)
            {
                Rect offsetRect = new Rect(selectionRect.position + offset, selectionRect.size);
                Rect bgRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.width + 50, selectionRect.height);

                EditorGUI.DrawRect(bgRect, backgroundColor);
                EditorGUI.LabelField(offsetRect, obj.name, new GUIStyle()
                {
                    normal = new GUIStyleState() { textColor = textColor },
                    fontStyle = FontStyle.Bold
                }
                );

                if (texture != null)
                    EditorGUI.DrawPreviewTexture(new Rect(selectionRect.position, new Vector2(selectionRect.height, selectionRect.height)), texture);
            }
        }
    }
}