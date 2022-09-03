using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb2D = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    Move();
    //}

    private void FixedUpdate()
    {
        MoveRigidbody2D();    
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += new Vector3(x, y);
    }

    void MoveRigidbody2D()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        float y = Input.GetAxis("Vertical") * Time.fixedDeltaTime;
        rb2D.MovePosition(rb2D.position + new Vector2(x, y));
    }
}
