using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AssemblySlotGrid : MonoBehaviour, IPointerUpHandler
{
    public float snapSize = 64;

    public Vector2Int gridSize;
    public bool[][] grid;

    public Vector2 Snap(Vector2 position)
    {
        return new Vector2(Mathf.Round(position.x / snapSize) * snapSize, Mathf.Round(position.y / snapSize) * snapSize);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        AssemblySlotObject assemblySlotObject = eventData.pointerDrag ? eventData.pointerDrag.GetComponent<AssemblySlotObject>() : null;

        if (assemblySlotObject)
        {
            RectTransform rectTransform = assemblySlotObject.rectTransform;
            rectTransform.position = Snap(rectTransform.position);
            // get grid position
            Vector2Int gridPosition = new Vector2Int(Mathf.RoundToInt(rectTransform.position.x / snapSize), Mathf.RoundToInt(rectTransform.position.y / snapSize));
            // check if grid position is valid
            if (gridPosition.x >= 0 && gridPosition.x < gridSize.x && gridPosition.y >= 0 && gridPosition.y < gridSize.y)
            {
                rectTransform.position = (Vector2)gridPosition;
            }
            else
            {
                rectTransform.position = eventData.pressPosition;
            }
        }
    }
}
