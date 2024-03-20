using UnityEngine;

namespace HierarchyRenamer {
    
public class HierarchyColoring : MonoBehaviour
{
    public static readonly Color DefaultColor = new Color(0.2196079f, 0.2196079f, 0.2196079f, 1f);
    public static readonly Color DefaultColorSelect = new Color(0.243f, 0.4901f, 0.9058f, 1f);

    [ContextMenuItem("Reset Background Color", "ResetColor")]
    public Color Background_Color = DefaultColor;

    public HierarchyColoring() { 
            
    }

    public HierarchyColoring(Color bgColor)
    {
        this.Background_Color = bgColor;
    }

    public void ResetColor() 
    { 
        Background_Color = DefaultColor; 
    }
}
}
