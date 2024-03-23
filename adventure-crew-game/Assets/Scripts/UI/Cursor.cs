using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursor : MonoBehaviour
{
    public List<Vector2> positions;
    private RectTransform rt;
    private int index;
    Keyboard kb;
    public UIMenu parentMenu;

    private void Start()
    {
        kb = Keyboard.current;
        rt = gameObject.GetComponent<RectTransform>();
        index = 0;
        UpdateCursor();
    }

    private void Update()
    {
        if (kb.downArrowKey.wasPressedThisFrame || kb.sKey.wasPressedThisFrame)
        {
            // Move the cursor down
            Descend();

        }
        if (kb.upArrowKey.wasPressedThisFrame || kb.wKey.wasPressedThisFrame)
        {
            // Move the cursor up
            Ascend();
        }
        if (kb.enterKey.wasPressedThisFrame)
        {
            parentMenu.CursorOrder(index);
        }
    }

    private void Descend()
    {
        index++;
        if (index >= positions.Count)
        {
            index = 0;
        }
        UpdateCursor();
    }

    private void Ascend()
    {
        index--;
        if (index < 0)
        {
            index = positions.Count - 1;
        }
        UpdateCursor();
    }

    private void UpdateCursor()
    {
        rt.localPosition = positions[index];
    }
}
