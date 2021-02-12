using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public float CheckDist = 5f;
    public bool IsGrounded;

    public LayerMask GroundMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, CheckDist, GroundMask);

        if (IsGrounded)
        {
            Debug.DrawRay(transform.position, Vector2.down * CheckDist, Color.red);
        }
    }
}
