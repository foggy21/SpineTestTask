using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    private float _speed = 3.75f;

    void Update()
    {
        Pursue();
    }

    private void Pursue()
    {
        Debug.Log(player.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
    }
}
