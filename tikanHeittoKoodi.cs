using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tikanHeittoKoodi : MonoBehaviour
{
    // Tikan prefab tänne:
    public GameObject tikkaNro1 = null;
    // Instanssi tänne:
    private GameObject tikkalaatikko = null;

    private float voima = 1000f;
    private float kiertovoima = 1000f;

    private Vector3 kiertokerroin = new Vector3(0f, 1f, 1f);

    void Start()
    {
    }

    void Update()
    {
        if(Input.GetButtonUp("Fire1")) {
            
            float x = this.GetComponent<Transform>().position.x;
            float y = this.GetComponent<Transform>().position.y;
            float z = this.GetComponent<Transform>().position.z;

            this.tikkalaatikko = Instantiate(this.tikkaNro1, GameObject.Find("tikanLahtoPaikka").GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);

            this.tikkalaatikko.name = "Heitetty";
            this.tikkalaatikko.GetComponent<Rigidbody>().AddForce(this.GetComponent<Transform>().forward * this.voima);
            this.tikkalaatikko.GetComponent<Rigidbody>().AddTorque(this.kiertokerroin * this.kiertovoima);
            // Soitetaan ääni:
            GameObject.Find("Soundivarasto").GetComponents<AudioSource>()[0].Play();

            Destroy(this.tikkalaatikko, 10f);
        }
        
    }
}
