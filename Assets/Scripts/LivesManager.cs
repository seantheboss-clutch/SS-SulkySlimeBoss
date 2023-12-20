using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LivesManager : MonoBehaviour
{
    public GameObject[] livesLeft;
    public bool death;
    public bool nextLevel;
    public int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        death = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(lives > 0)
        {
            if (death)
            {
                lives--;
                
                livesLeft[lives].SetActive(false);
                death = false;
            }
            
        } else
        {
           
                SceneManager.LoadScene(0);
        }
    }
}
