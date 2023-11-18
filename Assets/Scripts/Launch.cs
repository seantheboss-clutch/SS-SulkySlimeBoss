using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public GameObject player;
    public Rigidbody playerRb;
    public int speed;
    public int mult;
    public Vector3 startPos;
    public bool launched;
    public Quaternion rotation;
    public Vector3 force;
    public float xQuat = 0;
    public float yQuat = 0;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        launched = false;
        force = new Vector3(60f, 0f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (launched == false)
        {
            if (Input.GetKey("left"))
            {
                yQuat--;
                print(yQuat);
            }
            if (Input.GetKey("right"))
            {
                yQuat++;
                print(yQuat);
            }
        }

        if (Input.GetMouseButton(0))
        {
            mult += 1/10;
        }
        if (Input.GetMouseButton(1))
        {
            xQuat++;
            print(xQuat);
        }

        if (mult >= 100 || Input.GetMouseButtonUp(0) || xQuat >= 358)
        {
            rotation = Quaternion.Euler(-xQuat, yQuat, 0f);
            force = Vector3.forward;
            force = rotation * force;
            playerRb.velocity = transform.TransformDirection(force * speed * mult);
        }
        if (this.CompareTag("terrain"))
        {
            Destroy(player);
            launched = false;
            Instantiate(player, startPos, this.transform.rotation);
            this.GetComponent<LivesManager>().death = true;
        }
    }
    //IEnumerator 

}