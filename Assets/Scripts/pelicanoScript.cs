using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pelicanoScript : MonoBehaviour
{

    public GameObject luz;
    public GameObject player;
    private float distance;


    void Start()
    {
        InvokeRepeating("HideShowGameobject", 3, 3);
    }
    

    void HideShowGameobject()
    {
        luz.SetActive(!luz.activeSelf);
    }


    void Update()
    {
        if (luz.activeSelf == true)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < 3.5)
            {
                SceneManager.LoadScene("GameOverScreen");
            }
        }
        
    }
    

}
