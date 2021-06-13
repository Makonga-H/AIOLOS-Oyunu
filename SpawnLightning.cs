using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class SpawnLightning : MonoBehaviour
{
    public static float �lenK�yl� =0f;
    public GameObject Lightning;
    public GameObject uyar�;
    public AudioSource lightingSound;
    private bool uyar�Control;
    private float y�ld�r�mD�ng� = 0f;
    //private float y�ld�r�m�vmesi = 0.2f;
    //private float y�ld�r�mH�z� = 0f;
    private float y�ld�r�mZaman� = 3f;

    private void Start()
    {
        �lenK�yl� = 0;
    }


    void Update()
    {
        y�ld�r�mD�ng� += Time.deltaTime;

        if (y�ld�r�mD�ng� >= y�ld�r�mZaman�)
        {
            StartCoroutine(spawnLightning());
            if (y�ld�r�mZaman�>0.4f)
            { 
                y�ld�r�mZaman� = y�ld�r�mZaman� - (y�ld�r�mZaman� /50);
            }
            y�ld�r�mD�ng� = 0f;
        }
        /*
        timeLeft -= 1;
        if (timeLeft % 1000 == 0)
        {
            StartCoroutine(spawnLightning());
        }
        */
    }
    public IEnumerator spawnLightning()
    {
        Vector3 position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0);
        var clone = Instantiate(Lightning, position, Quaternion.identity);
        clone.SetActive(false);
        var uyar�Clone = Instantiate(uyar�, clone.transform.position, Quaternion.identity);
        uyar�Control = true;
        Object.Destroy(uyar�Clone, 3.0f);
        yield return new WaitForSeconds(3);
        uyar�Control = false;
        if(uyar�Control == false)
        {
            lightingSound.Play();
            clone.SetActive(true);
        }
        Object.Destroy(clone, 0.2f);
    }
}
