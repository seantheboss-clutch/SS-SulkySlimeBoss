using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capLaunch : MonoBehaviour
{
    public GameObject capsule;
    public bool level;
    public float xFloat;
    public float yFloat;
    public float zFloat;
    public float lmult;
    public float lspeed;
    // Start is called before the first frame update
    void Start()
    {
        lspeed = level == true ? lmult = 1.5f : lmult = 1;
        xFloat = Random.Range(200*lmult,900*lmult);
        yFloat = Random.Range(200*lmult, 900*lmult);
        zFloat = Random.Range(200*lmult, 400);
        Instantiate(capsule, new Vector3(xFloat, yFloat, zFloat), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
