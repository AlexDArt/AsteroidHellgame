using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float tilt;
    public GameObject LaserShot;
    public Transform Cannon1Position, Cannon2Position;
    public float xMin, xMax, zMin, zMax;
    public float shotDelay;
    private float nextShot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton ("Fire1") && Time.time > nextShot)
        {
            Instantiate(LaserShot, Cannon1Position.position, Quaternion.identity);
            Instantiate(LaserShot, Cannon2Position.position, Quaternion.identity);
            nextShot = Time.time + shotDelay;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Rigidbody Ship = GetComponent<Rigidbody>();
        Ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        Ship.rotation = Quaternion.Euler(moveVertical * tilt, 0, -moveHorizontal * tilt);
        float xPosition = Mathf.Clamp(Ship.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(Ship.position.z, zMin, zMax);
        Ship.position = new Vector3(xPosition, Ship.position.y, zPosition);

    }
}
