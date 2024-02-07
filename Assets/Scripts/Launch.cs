using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Launch : MonoBehaviour
{
    public GameObject player;
    public GameObject pf;
    public GameObject cylinder;
    public Rigidbody playerRb;
    public GameObject g1;
    public GameObject g2;
    //public Rigidbody cylRb;
    public Text hRotation;
    public Text vRotation;
    public Text multT;
    public int speed;
    public int mult = 100;
    public Vector3 startPos;
    public bool launched;
    public Quaternion rotation;
    public Vector3 force;
    public float xQuat = 0;
    public float yQuat = 0;
    public int score;
    public Text scoreText;
    public bool reset;
    public int count = 1;

    // Start is called before the first frame update
    void Start()
    {
         /*levelSwitch = false;*/
        startPos = transform.position;
        launched = false;
        force = new Vector3(0f, 60f, 0f);
       

    }

    // Update is called once per frame
    void Update()
    {
        vRotation.text = yQuat.ToString();
        hRotation.text = xQuat.ToString();
        multT.text = mult.ToString();
        if (launched == false)
        {
            if (Input.GetKey("left"))
            {
                if(xQuat != -45)
                {
                    xQuat--;
                    CrotationY(-1);
                }
               /* print(yQuat);*/
            }
            if (Input.GetKey("right"))
            {
                if(xQuat != 45)
                {
                    xQuat++;
                    CrotationY(1);
                }
                
/*                print(yQuat);
*/            }
        }

        if (Input.GetMouseButtonDown(1) && mult < 20)
        {
            mult += 1;
            count += 1;
/*            print(count);
*/        }
        if (Input.GetKey("up"))
        {
            if (yQuat != 45)
            {
                yQuat++;
                CrotationX(-1);
            }
        }
        if(xQuat > 0)
        {
            g1.SetActive(false);
        } else if(xQuat < 0)
        {
            g2.SetActive(false);
        } else if(xQuat == 0)
        {
            g1.SetActive(true);
            g2.SetActive(true);
        }
        if (Input.GetKey("down"))
        {
            if (yQuat != 0)
            {
                yQuat--;
                CrotationX(1);
            }
        }
        if(Input.GetKey("escape"))
        {
            xQuat = 0;
            yQuat = 0;
            RotateRespawn();
        }
        //The player launches
        if (Input.GetMouseButtonDown(0) && count >= 0)
        {
            launched = true;
                cylinder.SetActive(false);
/*            print(count);
*/            count = 0;
/*            print(count);
*/            rotation = Quaternion.Euler(-yQuat,xQuat, 0f);
            print(rotation);
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
        cylinder.SetActive(true);
        if(cond == true)
        {
            player.GetComponent<LivesManager>().death = true;
        }
        count = 0;
    }
    void CrotationX(float r)
    {
        //cylinder.transform.Rotate(Vector3.right*r);
        player.transform.Rotate(Vector3.right * r);
    }
    void CrotationY(float r)
    {
        //cylinder.transform.Rotate(Vector3.up * r);
        pf.transform.Rotate(Vector3.up * r);
    }
    void RotateRespawn()
    {
        pf.transform.rotation = Quaternion.Euler(0f,0f,0f);
    }

}