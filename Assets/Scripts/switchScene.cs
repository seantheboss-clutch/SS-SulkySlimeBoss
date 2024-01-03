using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour
{
    public string naem;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButton
        SceneManager.LoadScene(1);*/
        
    }
    public void switchSwitchy()
    {
        SceneManager.LoadScene(naem);
    }
    /*On*/
}
