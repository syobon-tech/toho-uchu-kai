using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject Logs;
    // Start is called before the first frame update
    void Start()
    {
        Logs.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f3"))
        {
            if (Logs.activeInHierarchy)
            {
                Logs.SetActive(false);
            }
            else
            {
                Logs.SetActive(true);
            }
        }
    }
}
