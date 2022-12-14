using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        var d = other.GetComponent<Driver>();
        switch (gameObject.tag)
        {
            case "Boost":
                d.SetMoveSpeed(d.GetMoveSpeed() + 3f);
                break;
            case "Bump":
                d.SetMoveSpeed(d.GetMoveSpeed() - 3f);
                break;
            default:
                break;
        }
    }
}
