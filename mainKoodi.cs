using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainKoodi : MonoBehaviour
{
    
    public GameObject aarreNro = null;
    private GameObject aarreLoota = null;
    // jäljellä olevien pallojen määrä näytetään tällä:
    private GameObject pallojenLkm = null;
    
    void Start()
    {
        luoMontaAarretta(4);
        this.pallojenLkm = GameObject.Find("PallojenLkm");
    }

    void Update()
    {
        // Haetaan jäljellä oleva aika ja pisteet toisesta scriptistä:
        int aika = GameObject.Find("Koodivarasto").GetComponent<aikaJaPisteet>().getAika();
        int pisteet = GameObject.Find("Koodivarasto").GetComponent<aikaJaPisteet>().getPisteet();

        this.pallojenLkm.GetComponent<Text>().text = "Palloja jäljellä: " + naytaPallojenLkm();


        // Jos aika loppuu tai kaikki timantit on kerätty, siirrytään game over ruutuun:
        if (aika == -1)
        {
            PlayerPrefs.SetInt("pisteet", pisteet);
            SceneManager.LoadScene(2);
        }

        // Jos kaikki pallot on ammuttu, luodaan neljä lisää ja lisätään aikaa 
        // aikaJaPisteet scriptin metodilla lisaaAikaa:
        if(naytaPallojenLkm() == 0) {
            luoMontaAarretta(4);
            GameObject.Find("Koodivarasto").GetComponent<aikaJaPisteet>().lisaaAikaa();
        }
    }

    // Metodi luo uuden ammuttavan pallon:
    public void luoAarre() {
        this.aarreLoota = Instantiate(this.aarreNro, this.GetComponent<Transform>().position, Quaternion.identity);
    }

    // Metodilla luodaan parametrina annetun luvun mukainen määrä palloja:
    public void luoMontaAarretta(int kpl) {
        for(int i=0; i<kpl; i++) {
            luoAarre();
        }
    }

    // Metodi palauttaa arvonaan pelissä olevien pallojen lukumäärän:
    public int naytaPallojenLkm() {
        return GameObject.FindGameObjectsWithTag("tuhottava").Length;
    }
}
