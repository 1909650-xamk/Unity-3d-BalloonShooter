using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aikaJaPisteet : MonoBehaviour
{
    private int pistemaara; // pelaajan pisteet
    private int aikaraja; // laskurin aika

    // pistemaara näytetään tällä objektilla:
    private GameObject pisteetKentta = null; 
    // aikaraja näytetään tällä:
    private GameObject aikaKentta = null;
    
    void Start()
    {
        this.pistemaara = 0;
        this.aikaraja = 3000;
        this.pisteetKentta = GameObject.Find("Pisteet");
        this.aikaKentta = GameObject.Find("Aika");
    }

    void Update() {
        this.pisteetKentta.GetComponent<Text>().text = "Pisteet: " + this.pistemaara;
        this.aikaKentta.GetComponent<Text>().text = "Aikaa jäljellä: " + (this.aikaraja / 100);
        pienennaAikaa();
    }
     public void kasvataPisteita()
    {
        this.pistemaara++;
    }

    public void pienennaAikaa()
    {
        this.aikaraja--;
    }

    public int getPisteet()
    {
        return this.pistemaara;
    }

    public int getAika()
    {
        return this.aikaraja;
    }

    public void lisaaAikaa() {
        this.aikaraja += 1500;
    }
}
