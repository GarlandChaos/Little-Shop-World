using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField]
    Texture2D textureCursorDefault = null;
    [SerializeField]
    Texture2D textureCursorInteractable = null;
    [SerializeField]
    Texture2D textureCursorNotInteractable = null;

    public void ChangeCursorToInteractable()
    {
        Cursor.SetCursor(textureCursorInteractable, Vector2.zero, CursorMode.Auto);
    }

    public void ChangeCursorToNotInteractable()
    {
        Cursor.SetCursor(textureCursorNotInteractable, Vector2.zero, CursorMode.Auto);
    }

    public void ChangeCursorToDefault()
    {
        Cursor.SetCursor(textureCursorDefault, Vector2.zero, CursorMode.Auto);
    }
}
