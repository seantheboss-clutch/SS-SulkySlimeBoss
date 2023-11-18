using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LivesManager : MonoBehaviour
{
    public GameObject[] livesLeft;
    public bool death;
    public int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        death = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(death)
        {
            lives--;
            Destroy(livesLeft[lives-1]);
        }
    }
}
