using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<Character>() != null)
        {
            GlobalData.Instance.lb = 100;
            GlobalData.Instance.berserker = false;
            GlobalData.Instance.archer = false;
            SceneManager.LoadScene(2);
        }
   
    }
}
