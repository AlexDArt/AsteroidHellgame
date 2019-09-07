using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public static int score = 0;
    private GameObject scoreText;
    public float rotationSpeed;
    public float minSpeed, maxSpeed;
    public GameObject AsteroidExplosion, PlayerExplosion;
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText");
        Rigidbody Asteroid = GetComponent<Rigidbody>();
        Asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        Asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateScore()
    {
        
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid" || other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, transform.position, Quaternion.identity);
        } else
        {
            score += 10;
            UpdateScore();
        }
        Instantiate(AsteroidExplosion, transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
