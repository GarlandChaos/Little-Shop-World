using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb2D = null;

    private void FixedUpdate()
    {
        MoveRigidbody2D();    
    }

    void MoveRigidbody2D()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        float y = Input.GetAxis("Vertical") * Time.fixedDeltaTime;
        rb2D.MovePosition(rb2D.position + new Vector2(x, y));
    }
}
