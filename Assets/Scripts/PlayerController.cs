using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float xMin, xMax, zMin, zMax;

    public Transform firepoint;
    public GameObject bullet;

    public float firerate;

    float nextfire;

    void FixedUpdate()
    {
        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().velocity = new Vector3(hor, 0, ver) * speed;

        // Moving the player's ship and avoid the ship to leave the game area (always visible).
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            0,
            Mathf.Clamp(transform.position.z, zMin, zMax)
            );



        // Rotation the ship when moving to horizontal velocity
        // Debug.Log(hor);

        if (hor == 0)
        {
            // If not moving then no rotation
            Vector3 rotationVector = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.Euler(rotationVector);
        }

        if (hor > 0)
        {
            // Rotate to the right 45 degrees when moving to right
            Vector3 rotationVector = new Vector3(0, 0, -45);
            transform.rotation = Quaternion.Euler(rotationVector);

        }

        if (hor < 0)
        {
            // Rotate to the left 45 degrees when moving to left
            Vector3 rotationVector = new Vector3(0, 0, 45);
            transform.rotation = Quaternion.Euler(rotationVector);
        }
                 
    }

    public void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Set delay to fire
        if (Time.time > nextfire)
        {
            // Create bullet
            Instantiate(bullet, firepoint.position, firepoint.rotation);

            // Reset cooldown
            nextfire = Time.time + firerate;
        }
    }
}
