using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceResolution : MonoBehaviour
{
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        SetResolution();
    }

    private void SetResolution()
    {
        // Calculate the width to maintain a 9:16 aspect ratio
        float targetAspect = 9f / 16f;
        float windowAspect = (float)Display.main.renderingWidth / (float)Display.main.renderingHeight;
        float scaleHeight = windowAspect / targetAspect;

        // If the calculated height is less than the current height, add pillar boxes
        if (scaleHeight < 1.0f)
        {
            Rect rect = Camera.main.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            Camera.main.rect = rect;
        }
        else
        {
            // If the calculated width is less than the current width, add letterboxing
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = Camera.main.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            Camera.main.rect = rect;
        }
    }
}
