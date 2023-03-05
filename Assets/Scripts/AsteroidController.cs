using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AsteroidController : MonoBehaviour
{

    public float speed;
    public GameObject explosionEffect;
    public Transform explosionPoint;

    [SerializeField] public AudioSource explosionSFX;

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
        // Got shooted by player
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            this.Exploded();


            // Increment score
            GameObject GameController = GameObject.FindGameObjectWithTag("GameController");
            GameController.GetComponent<GameController>().addScore();
        }


        // Hit to player
        if (other.CompareTag("Player"))
        {
            this.Exploded();
            other.GetComponent<PlayerController>().Exploded();
            Debug.Log("Hitted");
            
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

        // Cant use explosionSFX.Play() cause we destoy asteroid gameObject
        AudioSource.PlayClipAtPoint(explosionSFX.clip, transform.position);
        

        Destroy(instance.gameObject, timeout);
        Destroy(this.gameObject);
    }

}
