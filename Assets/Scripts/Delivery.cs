using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColour = new Color32(8, 255, 0, 255);
    [SerializeField] Color32 noPackageColour = new Color32(255, 255, 255, 255);
    [SerializeField] float packageDestroyDelay = 0.5f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;
    Driver driver;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        driver = gameObject.GetComponent<Driver>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "WorldObstacle")
        {
            Debug.Log("Car slowing as obstacle hit");
            driver.moveSpeed = driver.slowSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColour;
            Destroy(other.gameObject, packageDestroyDelay);
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColour;
        }
        else if (other.tag == "Boost")
        {
            Debug.Log("Speed boost!");
            driver.moveSpeed = driver.boostSpeed;
        }
    }
}
