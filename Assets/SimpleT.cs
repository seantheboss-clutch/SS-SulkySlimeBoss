using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleT : MonoBehaviour
{
    public Text timer;
    public int time = 6;
    // Start is called before the first frame update
    void Start()
    {
        Timer();
        Invoke("Stat", 6f);
    }

    // Update is called once per frame
    void Stat()
    {
        SceneManager.LoadScene(2);
    }
    void Timer()
    {
       /* time -= Mathf.Round(Time.deltaTime);
        timer.text = time.ToString();*/

    }
}
