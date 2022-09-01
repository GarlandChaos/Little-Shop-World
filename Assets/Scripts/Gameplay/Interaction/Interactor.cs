using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour, IInteractor
{
    Vector3 direction = Vector3.zero; //check if need to be on the heap
    [SerializeField]
    LayerMask layerToInteract;

    // Update is called once per frame
    void Update()
    {
        TryToHit();
    }

    void TryToHit()
    {
        float horizontalValue = Input.GetAxis("Horizontal");
        if(horizontalValue != 0)
        {
            direction = (horizontalValue > 0) ? transform.right : -transform.right;
        }
        else
        {
            float verticalValue = Input.GetAxis("Vertical");
            if (verticalValue != 0)
                direction = (verticalValue > 0) ? transform.up : -transform.up;
        }

        Vector2 origin = transform.position + direction / 2;
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 1f, layerToInteract);

        if(hit.transform != null)
        {
            hit.transform.GetComponent<Interactable>().Interact();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + direction / 2, transform.position + direction / 2 + direction);
    }
}
