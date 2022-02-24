using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private float minvelocity = 0.1f;
    private Vector3 lastmousepos;
    private Vector3 mousevelo;
    private Collider2D collider;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        setbladetomouse();
    }
    private void setbladetomouse()
    {
        var mousepos = Input.mousePosition;

        mousepos.z = 10f;

        rb.position =  Camera.main.ScreenToWorldPoint(mousepos);
    }
    private bool IsMouseMoving()
    {
        Vector3 curmousepos = transform.position;
        float traveled = (lastmousepos - curmousepos).magnitude;
        lastmousepos = curmousepos;
        if(traveled>minvelocity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void FixedUpdate()
    {
        collider.enabled = IsMouseMoving();
        
    }
}
