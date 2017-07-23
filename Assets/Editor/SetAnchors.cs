using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SetAnchors : MonoBehaviour {

    [MenuItem("UGUI Tools/Anchors to Corners %[")]
    static void AnchorsToCorners()
    {
        RectTransform t = Selection.activeTransform as RectTransform;
        RectTransform pt = Selection.activeTransform.parent as RectTransform;

        if (t == null || pt == null)
            return;

        t.anchorMin = new Vector2(t.anchorMin.x + t.offsetMin.x / pt.rect.width, t.anchorMin.y + t.offsetMin.y / pt.rect.height);
        t.anchorMax = new Vector2(t.anchorMax.x + t.offsetMax.x / pt.rect.width, t.anchorMax.y + t.offsetMax.y / pt.rect.height);

        t.offsetMin = t.offsetMax = new Vector2(0, 0);
    }

    [MenuItem("UGUI Tools/Corners to Anchors %]")]
    static void CornersToAnchors()
    {
        RectTransform t = Selection.activeTransform as RectTransform;

        if (t == null)
            return;

        t.offsetMin = t.offsetMax = new Vector2(0, 0);
    }

    [MenuItem("UGUI Tools/Anchors to Center %;")]
    static void AnchorsToCenter()
    {
        RectTransform gameRect = Selection.activeTransform as RectTransform;
        RectTransform parentRect = gameRect.parent as RectTransform;
        if ((gameRect == null) || (parentRect == null))
        {
            return;
        }
        Vector2 offsetMax = gameRect.offsetMax;
        Vector2 offsetMin = gameRect.offsetMin;
        Rect rect = parentRect.rect;
        float screenWidth = rect.size.x;
        float screenHeight = rect.size.y;
        Vector2 pos = gameRect.rect.size;
        gameRect.anchorMax += new Vector2(gameRect.offsetMax.x / screenWidth, gameRect.offsetMax.y / screenHeight);
        gameRect.anchorMin += new Vector2(gameRect.offsetMin.x / screenWidth, gameRect.offsetMin.y / screenHeight);
        gameRect.offsetMax = gameRect.offsetMin = new Vector2(0, 0);

        gameRect.anchorMax -= new Vector2(pos.x / 2 / screenWidth, pos.y / 2 / screenHeight);
        gameRect.anchorMin += new Vector2(pos.x / 2 / screenWidth, pos.y / 2 / screenHeight);
        gameRect.offsetMax = pos / 2;
        gameRect.offsetMin = -pos / 2;

    }

    [MenuItem("UGUI Tools/Move To Anchors Center %'")]
    static void MoveToAnchorsCenter()
    {
        RectTransform t = Selection.activeTransform as RectTransform;

        if (t == null)
            return;

        t.anchoredPosition = t.localScale;
    }

    [MenuItem("UGUI Tools/Mirror Horizontally Around Anchors #[")]
    static void MirrorHorizontallyAnchors()
    {
        MirrorHorizontally(false);
    }

    [MenuItem("UGUI Tools/Mirror Horizontally Around Parent Center #]")]
    static void MirrorHorizontallyParent()
    {
        MirrorHorizontally(true);
    }

    static void MirrorHorizontally(bool mirrorAnchors)
    {
        foreach (Transform transform in Selection.transforms)
        {
            RectTransform t = transform as RectTransform;
            RectTransform pt = Selection.activeTransform.parent as RectTransform;

            if (t == null || pt == null) return;

            if (mirrorAnchors)
            {
                Vector2 oldAnchorMin = t.anchorMin;
                t.anchorMin = new Vector2(1 - t.anchorMax.x, t.anchorMin.y);
                t.anchorMax = new Vector2(1 - oldAnchorMin.x, t.anchorMax.y);
            }

            Vector2 oldOffsetMin = t.offsetMin;
            t.offsetMin = new Vector2(-t.offsetMax.x, t.offsetMin.y);
            t.offsetMax = new Vector2(-oldOffsetMin.x, t.offsetMax.y);

            t.localScale = new Vector3(-t.localScale.x, t.localScale.y, t.localScale.z);
        }
    }

    [MenuItem("UGUI Tools/Mirror Vertically Around Anchors #;")]
    static void MirrorVerticallyAnchors()
    {
        MirrorVertically(false);
    }

    [MenuItem("UGUI Tools/Mirror Vertically Around Parent Center #'")]
    static void MirrorVerticallyParent()
    {
        MirrorVertically(true);
    }

    static void MirrorVertically(bool mirrorAnchors)
    {
        foreach (Transform transform in Selection.transforms)
        {
            RectTransform t = transform as RectTransform;
            RectTransform pt = Selection.activeTransform.parent as RectTransform;

            if (t == null || pt == null)
                return;

            if (mirrorAnchors)
            {
                Vector2 oldAnchorMin = t.anchorMin;
                t.anchorMin = new Vector2(t.anchorMin.x, 1 - t.anchorMax.y);
                t.anchorMax = new Vector2(t.anchorMax.x, 1 - oldAnchorMin.y);
            }

            Vector2 oldOffsetMin = t.offsetMin;
            t.offsetMin = new Vector2(t.offsetMin.x, -t.offsetMax.y);
            t.offsetMax = new Vector2(t.offsetMax.x, -oldOffsetMin.y);

            t.localScale = new Vector3(t.localScale.x, -t.localScale.y, t.localScale.z);
        }
    }


    [MenuItem("UGUI Tools/Mirror Vertically Around Parent Center %Q")]
    static void setUP() {
        RectTransform t = Selection.activeTransform as RectTransform;
        RectTransform pt = Selection.activeTransform.parent as RectTransform;

        if (t == null || pt == null)
            return;
        t.anchoredPosition = new Vector2(0, 1);
        //t.anchorMin = new Vector2(t.anchorMin.x + t.offsetMin.x / pt.rect.width, t.anchorMin.y + t.offsetMin.y / pt.rect.height);
        //t.anchorMax = new Vector2(t.anchorMax.x + t.offsetMax.x / pt.rect.width, t.anchorMax.y + t.offsetMax.y / pt.rect.height);

        //t.offsetMin = t.offsetMax = new Vector2(0, 0);
    }
}
