using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intronKoodi : MonoBehaviour
{
    
    public void kaynnistaPeli() {
        SceneManager.LoadScene(1);
    }

    public void lopetaPeli() {
        Application.Quit();
    }

    void Update() {
        if(Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
        if(Input.anyKey) {
            SceneManager.LoadScene(1);
        }
    }
}
