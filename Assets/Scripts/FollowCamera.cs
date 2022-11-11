using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The camera should be the same as the Car's position.
 */
public class FollowCamera : MonoBehaviour
{
    [SerializeReference]
    private GameObject player;   
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
