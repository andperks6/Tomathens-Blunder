using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasScaler))]
public class SystemMenuCanvas : MonoBehaviour
{
    void Awake()
    {
        // Get or add Canvas Scaler
        CanvasScaler scaler = GetComponent<CanvasScaler>();
        
        // Configure the Canvas Scaler for proper scaling
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080); // Match our project settings
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        scaler.matchWidthOrHeight = 1f; // Match height for landscape mode
        
        // Get RectTransform
        RectTransform rectTransform = GetComponent<RectTransform>();
        
        // Set to stretch and fill screen
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.sizeDelta = Vector2.zero;
        rectTransform.anchoredPosition = Vector2.zero;
    }
}