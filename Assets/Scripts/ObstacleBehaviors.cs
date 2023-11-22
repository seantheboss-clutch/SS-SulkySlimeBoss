using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviors : MonoBehaviour
{
    public GameObject obstacle;
    public Vector3 startPos = new Vector3(140f, -500f, 930f);
    public int xMargin = 30;
    public int yMargin = 30;
    public int colCount = 1;
  
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 7; i++)
        {
            if (i <= 4)
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
}
