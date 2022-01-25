using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aarteenKoodi : MonoBehaviour
{
   private float nopeus = 1f; // objektin liikkumisnopeus
   private bool suuntaYlos; // tällä tarkistetaan mihin suuntaan objekti liikkuu

    void Start()
    {
        // Arvotaan objektin sijaintikoordinaatit:
        this.transform.position = new Vector3(Random.Range(-52f,50f), Random.Range(1.5f, 2.0f), Random.Range(-46f,33f));
        this.suuntaYlos = true;
    }

    void Update()
    {
        // Jos korkeus on yli 2, vaihdetaan suunta:
        if(this.GetComponent<Transform>().position.y > 2f) {
            suuntaYlos = false;
        }
        // ja sama päinvastoin alaspäin mentäessä:
        if(this.GetComponent<Transform>().position.y < 1.5f) {
            suuntaYlos = true;
        }

        // Jos suuntaYlos on totta, kasvatetaan korkeutta:
        if(suuntaYlos) {
            this.GetComponent<Transform>().Translate(0f, this.nopeus * Time.deltaTime, 0f);
        } else { // muuten pienennetään sitä:
            float miinus = this.nopeus * Time.deltaTime;
            miinus -= miinus * 2;
            this.GetComponent<Transform>().Translate(0f, miinus, 0f);
            // tuon pienennyksen olisi varmaan voinut tehdä jotenkin tehokkaamminkin,
            // mutta näin puolenyön aikaan ei keksitty muuta...
        }
    }

    // Jos havaitaan törmäys toiseen objektiin:
    void OnCollisionEnter(Collision osuma)
    {     
        // Tuhotaan itsensä
        Destroy(this.gameObject);
        // Soitetaan ääni:
        GameObject.Find("Soundivarasto").GetComponents<AudioSource>()[1].Play();
        // ja kasvatetaan pisteitä:
        GameObject.Find("Koodivarasto").GetComponent<aikaJaPisteet>().kasvataPisteita();
    }
}
