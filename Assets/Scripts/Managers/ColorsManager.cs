using UnityEngine;
public class ColorsManager 
{
    public static Color getColor(string colorHex)
    {
        Color color;
        ColorUtility.TryParseHtmlString(colorHex, out color);
        return color;
    }

}
