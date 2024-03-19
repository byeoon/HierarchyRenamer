using UnityEngine;

public class HierarchyColoring : MonoBehaviour
{
    public static Color DefaultColor = new Color(0.2196079f, 0.2196079f, 0.2196079f, 1f);
    public static Color DefaultColorSelect = new Color(0.243f, 0.4901f, 0.9058f, 1f);
    [ContextMenuItem("Reset Background Color", "ResetColor")]
    public Color Background_Color = DefaultColor;

    public HierarchyColoring() { 
            
    }

    public HierarchyColoring(Color backgroundColor)
    {
        this.Background_Color = backgroundColor;
    }

    public void ResetColor() 
    { 
        Background_Color = DefaultColor; 
    }


}
