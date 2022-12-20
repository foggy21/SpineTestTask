using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float raycastDistance = 4f;
    private float _speed = 5f;
    private float _slideSpeed = 2f;
    private SkeletonAnimation skeletonAnimation;
    private bool moveController = true;

    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        skeletonAnimation= GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Slide();
    }

    private void Move()
    {
        if (moveController && Mathf.Abs(Input.GetAxis("Horizontal")) > 0) {
            rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, rb2D.velocity.y);
            skeletonAnimation.AnimationName = "walk";
        }
        else
        {
            skeletonAnimation.AnimationName = "idle";
        }
    }

    private void Slide()
    {
        Physics2D.queriesStartInColliders = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, LayerMask.GetMask("InclinedPlane"));

        if (hit.collider != null)
        {
            moveController = false;
            rb2D.AddForce(new Vector2(_slideSpeed, _slideSpeed), ForceMode2D.Force);
            skeletonAnimation.AnimationName = "idle";
        }
        else
        {
            moveController = true;
        }
    }
}
