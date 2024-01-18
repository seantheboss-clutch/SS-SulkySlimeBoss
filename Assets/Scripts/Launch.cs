using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Launch : MonoBehaviour
{
    public GameObject player;
    public Rigidbody playerRb;
    public Text hRotation;
    public Text vRotation;
    public Text multT;
    public int speed;
    public int mult = 70;
    public Vector3 startPos;
    public bool launched;
    public Quaternion rotation;
    public Vector3 force;
    public float xQuat = 0;
    public float yQuat = 0;
    public int score;
    public Text scoreText;
    public bool reset;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
         /*levelSwitch = false;*/
        startPos = transform.position;
        launched = false;
        force = new Vector3(60f, 0f, 0f);
       

    }

    // Update is called once per frame
    void Update()
    {
        hRotation.text = yQuat.ToString();
        vRotation.text = xQuat.ToString();
        multT.text = mult.ToString();
        if (launched == false)
        {
            if (Input.GetKey("left"))
            {
                yQuat--;
               /* print(yQuat);*/
            }
            if (Input.GetKey("right"))
            {
                yQuat++;
/*                print(yQuat);
*/            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            mult += 1;
            count += 1;
/*            print(count);
*/        }
        if (Input.GetKey("up"))
        {
            xQuat++;
/*            print(xQuat);
*/        }
        if (Input.GetKey("down"))
        {
            xQuat--;
/*            print(xQuat);
*/        }
        //The player launches
        if (Input.GetMouseButtonDown(0) && count >= 1)
        {
/*            print(count);
*/            count = 0;
/*            print(count);
*/            rotation = Quaternion.Euler(-xQuat, yQuat, 0f);
            force = Vector3.forward;
            force = rotation * force;
            playerRb.velocity = transform.TransformDirection(force * speed * mult);
            playerRb.useGravity = true;
            /*Invoke("reSpawn", 4f);*/

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            mult = 0;
            score += 100;
            count = 0;
            scoreText.text = score.ToString();
            if (score >= 600)
            {
                scoreText.color = Color.yellow;
            } else if (score >= 400 && score <= 599)
            {
                scoreText.color = Color.grey;
            } else if (score >= 200 && score <= 399)
            {
                scoreText.color = Color.red;
            }
            //player.GetComponent<ObstacleBehaviors>().odeath = true;
            Destroy(collision.gameObject);
            reSpawn(false);

        }
        else
        {
            reSpawn(true);
        }
        if(collision.gameObject.tag == "quad")
        {
            reSpawn(true);
            score += 50;
        }
        if (collision.gameObject.tag == "collectable")
        {
          score += 500;
/*            SceneManager.LoadScene("Level2");
*/       }
       if(score >= 500)
       {
            Scene sc = SceneManager.GetActiveScene();
            if(sc.name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            } else
            {
                SceneManager.LoadScene("Menu");
            }
            
            score = 0;
        }
    }
 
    void reSpawn(bool cond)
    {
        launched = false;
        playerRb.velocity = Vector3.zero;
        playerRb.useGravity = false;
        player.transform.position = startPos;
        if(cond == true)
        {
            player.GetComponent<LivesManager>().death = true;
        }
        count = 0;
    }

}