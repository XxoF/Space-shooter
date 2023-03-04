using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float xMin, xMax, zMin, zMax;

    public Transform firepoint;
    public GameObject bullet;

    public Transform explosionPoint;
    public GameObject explosionEffect;

    public float firerate;

    public AudioSource explosionSoundEffect;
    public AudioSource shootSoundEffect;

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
            shootSoundEffect.Play();

            // Reset cooldown
            nextfire = Time.time + firerate;
        }
    }

    // Player destroyed when hit asteroid
    public void Exploded()
    {
        // Remove explosion effect when its done.
        float timeout = 3.0f;

        var instance = Instantiate(explosionEffect, explosionPoint.position, explosionPoint.rotation);

        playExplosionSFX();

        Destroy(instance.gameObject, timeout);
        Destroy(this.gameObject);
    }

    void playExplosionSFX()
    {
        // Cant use explosionSFX.Play() cause we destoy asteroid gameObject
        AudioSource.PlayClipAtPoint(explosionSoundEffect.clip, transform.position);
    }
}
