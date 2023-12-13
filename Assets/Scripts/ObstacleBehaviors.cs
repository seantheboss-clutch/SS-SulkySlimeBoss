using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleBehaviors : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject[] obstacles;
    public Vector3 startPos = new Vector3(433.4f, 16.9061f, 2461.78f);
    public int xMargin = 30;
    public int yMargin = 30;
    public int colCount = 1;
    public int expect = 7;
    public int c;
    public int deathday;
    public bool odeath;
    public Vector3 newPos = new Vector3();
   

    // Start is called before the first frame update
    void Start()
    {
        for(c = 1; c < expect; c++)
        {
            if (c < 4)
            {
                Column(colCount);
                reSettle();
                colCount++;
            } else
            {
                Column(colCount);
                reSettle();
                colCount--;
            }
            
        }
        odeath = false;
    }
    void Column(int colCount)
    {
        for(int i = 0; i < colCount; i++)
        {
            Instantiate(obstacle, startPos, Quaternion.identity);
            
            startPos.y += yMargin;

        }
    }
    void reSettle()
    {
        //Column(colCount);
        startPos.x += xMargin;
        startPos.y -= (colCount * yMargin);
    }
    void Update()
    {
          if(odeath)
          {
            deathday--;
            odeath = false;
          }
    }
}
