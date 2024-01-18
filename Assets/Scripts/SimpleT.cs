using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleT : MonoBehaviour
{
    public Text timer;
    public float time = 6;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Stat",6f);

    }
    void Stat()
    {
        SceneManager.LoadScene(2);
    }
}
