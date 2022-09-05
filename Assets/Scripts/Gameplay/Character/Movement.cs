using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb2D = null;
    [SerializeField]
    float speed = 2f;
    float x = 0f;
    float y = 0f;

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if(PauseManager.instance != null)
        {
            if (!PauseManager.instance._Paused)
                MoveRigidbody2D();
        }
    }

    void MoveRigidbody2D()
    {
        Vector2 newPos = new Vector2(x * speed * Time.fixedDeltaTime, y * speed * Time.fixedDeltaTime);
        rb2D.MovePosition(rb2D.position + newPos);
    }
}
