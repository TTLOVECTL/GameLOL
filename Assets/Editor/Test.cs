using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Test : MonoBehaviour {
    [MenuItem("Help/TT/SetAnchorPos")]
    public static void SetAnchorPos()
    {  
        RectTransform gameRect=Selection.activeTransform as RectTransform;
        RectTransform parentRect = gameRect.parent as RectTransform;
        if ((gameRect==null) || (parentRect==null)) {
            return ;
        }
        Vector2 offsetMax = gameRect.offsetMax;
        Vector2 offsetMin = gameRect.offsetMin;
        Rect rect = parentRect.rect;
        float screenWidth = rect.size.x;
        float screenHeight = rect.size.y;
        gameRect.anchorMax += new Vector2(gameRect.offsetMax.x / screenWidth, gameRect.offsetMax.y / screenHeight);
        gameRect.anchorMin += new Vector2(gameRect.offsetMin.x / screenWidth, gameRect.offsetMin.y / screenHeight);
        gameRect.offsetMax = gameRect.offsetMin = new Vector2(0, 0);
    }

     
}
