using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverKoodi : MonoBehaviour
{

     void Start()
    {
        // Haetaan pisteet ja näytetään ne:
        int pisteet = PlayerPrefs.GetInt("pisteet");
        GameObject.Find("Teksti").GetComponent<Text>().text = "Pisteesi: " + pisteet;
    }
    void Update()
    {
        if(Input.anyKey) {
            SceneManager.LoadScene(0);
        }
    }
}
