using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    public float speed;
    public GameObject explosionEffect;
    public Transform explosionPoint;

    // Start is called before the first frame update
    void Start()
    {
        //selfRotation(1);
    }

    // Update is called once per frame
    void Update()
    {
        //selfRotation(Time.deltaTime);
        autoMove();
    }

    // Destroy Asteroid when collided
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            this.Exploded();
        }


        if (other.CompareTag("Player"))
        {
            this.Exploded();
            other.GetComponent<PlayerController>().Exploded();
            
        }
    }

    private void autoMove()
    {
        Vector3 backwardVector = new Vector3(0, 0, -1);
        transform.Translate(backwardVector * speed * Time.deltaTime);
    }

    private void Exploded()
    {
        float timeout = 3.0f;

        var instance = Instantiate(explosionEffect, explosionPoint.position, explosionPoint.rotation);
        Destroy(instance.gameObject, timeout);
        Destroy(this.gameObject);
    }

}
