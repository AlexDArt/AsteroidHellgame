using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject Asteroid;
    public float minDelay, maxDelay;
    private float nextLaunch;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextLaunch)
            {
                nextLaunch = Time.time + Random.Range(minDelay, maxDelay);
                float yPosition = transform.position.y;
                float zPosition = transform.position.z;
                float xPosition = Random.Range(
                    -transform.localScale.x/2, transform.localScale.x/2
                );
                Instantiate(Asteroid, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);
            }
    }
}
