using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    private float _speed = 3.75f;

    private Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        player.onPlayerSliding += ChangeColor;
    }


    void Update()
    {
        Pursue();
    }

    private void Pursue()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
    }

    // When player will slide, cube change color.
    private void ChangeColor()
    {
        material.color = Color.green;
    }
}
