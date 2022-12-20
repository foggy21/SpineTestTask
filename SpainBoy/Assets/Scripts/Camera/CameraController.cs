using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    private float dumping = 1.5f;

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position= currentPosition;
        }
    }
}
