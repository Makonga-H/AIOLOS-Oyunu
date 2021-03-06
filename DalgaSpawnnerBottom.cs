using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalgaSpawnnerBottom : MonoBehaviour
{
    public GameObject dalga;
    public static int ölenKöylü;
    public GameObject uyarı;
    private float zamanDöngü = 0f;
    private float dalgaDöngü = 0f;
    private float dalgaZamanı = 9f;
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
            dalgaZamanı = dalgaZamanı - (dalgaZamanı / 60);
            dalgaDöngü = 0f;
        }
    }
    void spawnDalga()
    {
        Vector3 position = new Vector3(Random.Range(-11.0f, 11.0f), Random.Range(-12.0f, -14.0f), 0);
        if(position.x<-6)
        {
            gercekAcı = new Vector3(0, 0, -30);
        }else if(position.x >=-6 && position.x <=7)
        {
            gercekAcı = new Vector3(0, 0, 0);
        }else if ( position.x >7)
        {
            gercekAcı = new Vector3(0, 0, 30);
        }
        var clone = Instantiate(dalga, position, Quaternion.Euler(gercekAcı));
        dalgaSesi.Play();
    }
}
