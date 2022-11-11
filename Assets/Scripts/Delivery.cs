using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    // Components
    private SpriteRenderer _spriteRenderer;

    // States
    private bool _hasPackage;
    
    // Serializable States
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 255);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 255);

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Package":
                if (_hasPackage)
                {
                    Debug.Log("You have to delivery the package you have first!");
                    return;
                }

                _hasPackage = true;
                _spriteRenderer.color = hasPackageColor;
                Destroy(other.gameObject, 1f);
                break;
            case "Customer":
                if (!_hasPackage)
                {
                    Debug.Log("You need a package to delivery first!");
                    return;
                }

                _hasPackage = false;
                _spriteRenderer.color = noPackageColor;
                Debug.Log("Delivered to the customer!");
                Destroy(other.gameObject, 1f);
                break;
            default:
                break;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {

    }
}
