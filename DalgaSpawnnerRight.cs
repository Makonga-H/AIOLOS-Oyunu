using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalgaSpawnnerRight : MonoBehaviour
{
    public GameObject dalga;
    public static int ölenKöylü;
    public GameObject uyarı;
    private float zamanDöngü = 0f;
    private float dalgaDöngü = 0f;
    private float dalgaZamanı = 6f;
    public AudioSource dalgaSesi;
    private Vector3 gercekAcı;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        zamanDöngü += Time.deltaTime;
        dalgaDöngü += Time.deltaTime;
        if (zamanDöngü >= 1)
        {

            //yıldırımZamanı += yıldırımHızı;
            //yıldırımHızı += yıldırımİvmesi;
            zamanDöngü = 0f;
        }
        if (dalgaDöngü >= dalgaZamanı)
        {
            spawnDalga();
            dalgaZamanı = dalgaZamanı - (dalgaZamanı / 75);
            dalgaDöngü = 0f;
        }
    }
    void spawnDalga()
    {
        Vector3 position = new Vector3(Random.Range(12.0f, 14.0f), Random.Range(-10.0f, 10.0f), 0);
        if (position.y < -7)
        {
            gercekAcı = new Vector3(0, 0, 60);
        }
        else if (position.y >= -7 && position.y <= 6)
        {
            gercekAcı = new Vector3(0, 0, 90);
        }
        else if (position.y > 6)
        {
            gercekAcı = new Vector3(0, 0, 120);
        }
        var clone = Instantiate(dalga, position, Quaternion.Euler(gercekAcı));
        dalgaSesi.Play();
    }
}
