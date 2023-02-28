using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    public float speed;


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

    private void OnTriggerEnter(Collider other)
    {
        // Destroy Asteroid when shooted
        if (other.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void autoMove()
    {
        Vector3 backwardVector = new Vector3(0, 0, -1);
        transform.Translate(backwardVector * speed * Time.deltaTime);
    }


}
