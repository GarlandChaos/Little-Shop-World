using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    LayerMask layerToInteract;
    Transform transformCurrentHit = null;
    [SerializeField]
    float raycastDistance = 0.2f;
    Vector3 direction = Vector3.zero;
    [SerializeField]
    DirectionIndicator directionIndicator = null;

    void Update()
    {
        TryToHit();
        TryToInteract();
    }

    void TryToHit()
    {        
        if (directionIndicator._CurrentDirection == Direction.Up)
            direction = Vector2.up;
        else if (directionIndicator._CurrentDirection == Direction.Down)
            direction = Vector2.down;
        else if (directionIndicator._CurrentDirection == Direction.Right)
            direction = Vector2.right;
        else if (directionIndicator._CurrentDirection == Direction.Left)
            direction = Vector2.left;

        Vector2 origin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, raycastDistance, layerToInteract);

        if(hit.transform != null)
        {
            if(hit.transform != transformCurrentHit)
            {
                hit.transform.GetComponent<IInteractable>().EnterInteractionArea();
                transformCurrentHit = hit.transform;
            }
        }
        else
        {
            if(transformCurrentHit != null)
            {
                transformCurrentHit.GetComponent<IInteractable>().ExitInteractionArea();
                transformCurrentHit = null;
            }
        }
    }

    void TryToInteract()
    {
        if (Input.GetKeyDown(KeyCode.X) && transformCurrentHit != null)
        {
            transformCurrentHit.GetComponent<IInteractable>().Interact();
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + direction * raycastDistance);
    }
#endif
}