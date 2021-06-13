using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalgaSpawnnerLeft : MonoBehaviour
{
    public GameObject dalga;
    public static int �lenK�yl�;
    public GameObject uyar�;
    private float zamanD�ng� = 0f;
    private float dalgaD�ng� = 0f;
    private float dalgaZaman� = 7f;
    public AudioSource dalgaSesi;
    private Vector3 gercekAc�;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        zamanD�ng� += Time.deltaTime;
        dalgaD�ng� += Time.deltaTime;
        if (zamanD�ng� >= 1)
        {

            //y�ld�r�mZaman� += y�ld�r�mH�z�;
            //y�ld�r�mH�z� += y�ld�r�m�vmesi;
            zamanD�ng� = 0f;
        }
        if (dalgaD�ng� >= dalgaZaman�)
        {
            spawnDalga();
            dalgaZaman� = dalgaZaman� - (dalgaZaman� / 65);
            dalgaD�ng� = 0f;
        }
    }
    void spawnDalga()
    {
        Vector3 position = new Vector3(Random.Range(-12.0f, -14.0f), Random.Range(-10.0f, 10.0f), 0);
        if (position.y < -7)
        {
            gercekAc� = new Vector3(0, 0, 300);
        }
        else if (position.y >= -7 && position.y <= 6)
        {
            gercekAc� = new Vector3(0, 0, 270);
        }
        else if (position.y > 6)
        {
            gercekAc� = new Vector3(0, 0, 240);
        }
        var clone = Instantiate(dalga, position, Quaternion.Euler(gercekAc�));
        dalgaSesi.Play();
    }
}
