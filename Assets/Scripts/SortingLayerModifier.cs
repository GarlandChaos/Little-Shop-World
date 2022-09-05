using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerModifier : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer = null;
    [SerializeField]
    int lowSortingLayer = -1;
    [SerializeField]
    int highSortingLayer = 5;
    [SerializeField]
    float yOffset = 0f;
    [SerializeField]
    Transform target = null;

    private void Update()
    {
        if(target != null)
        {
            if (transform.position.y + yOffset > target.position.y)
                spriteRenderer.sortingOrder = lowSortingLayer;
            else
                spriteRenderer.sortingOrder = highSortingLayer;
        }
    }

    public void SetTarget(Transform transformTarget)
    {
        target = transformTarget;
    }
}
