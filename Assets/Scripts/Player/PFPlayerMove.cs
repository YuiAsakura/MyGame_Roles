using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFPlayerMove : MonoBehaviour
{
    [SerializeField]
    public float speed;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        //Debug.Log("UpdateTest");
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Put A");
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Put D");
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Put W");
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Put S");
            dir.y = -1;
            animator.SetInteger("Direction", 0);
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().linearVelocity = speed * dir;
    }
}
