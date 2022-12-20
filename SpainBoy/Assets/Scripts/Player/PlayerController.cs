using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private float raycastDistance = 1.5f;
    private float _speed = 5f;
    private float _slideSpeed = 3f;
    private bool moveController = true;

    private SkeletonAnimation skeletonAnimation;
    private Rigidbody rb;

    public UnityAction onPlayerSliding;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, rb.velocity.y);
            skeletonAnimation.AnimationName = "walk";
        }
        else
        {
            skeletonAnimation.AnimationName = "idle";
        }
    }

    private void Slide()
    {
        bool hit = Physics.Raycast(transform.position, Vector2.down, raycastDistance, LayerMask.GetMask("InclinedPlane"));

        if (hit)
        {
            moveController = false;
            rb.AddForce(new Vector2(_slideSpeed, _slideSpeed), ForceMode.Force);
            skeletonAnimation.AnimationName = "idle";
            onPlayerSliding.Invoke();
        }
        else
        {
            moveController = true;
        }
    }
}
