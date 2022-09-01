using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += new Vector3(x, y);
    }
}
