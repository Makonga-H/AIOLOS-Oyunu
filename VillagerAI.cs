using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerAI : MonoBehaviour
{
    private float enSonY�nDe�i�tirmeZaman�;
    private Rigidbody2D rb2d;
    private float y�nDe�i�tirmeZaman�;
    private float karakterH�z = 2f;
    private Vector2 hareketY�n�;
    private Vector2 saniyedehareket ;

    private Vector2 ItmeVektoru;
    private Vector3 ItmeYonu;
    private float �tmeGucu = 6f;
    private float mesafe;
    private bool etkiS�n�r�ndaM� = false;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        y�nDe�i�tirmeZaman� = Random.Range(3f, 4f);
        enSonY�nDe�i�tirmeZaman� = 0f;
        calcuateNewMovementVector();
    }


    void Update()
    {
        if (Time.time - enSonY�nDe�i�tirmeZaman� > y�nDe�i�tirmeZaman�)
        {
            enSonY�nDe�i�tirmeZaman� = Time.time;
            y�nDe�i�tirmeZaman� = Random.Range(2f, 3f);
            calcuateNewMovementVector();
        }

        if (Input.GetMouseButton(0) && etkiS�n�r�ndaM�)
        {
            rb2d.AddForce(ItmeVektoru * �tmeGucu * Time.deltaTime , ForceMode2D.Impulse);
        }else
        {
            transform.position = new Vector2(transform.position.x + (saniyedehareket.x * Time.deltaTime),
            transform.position.y + (saniyedehareket.y * Time.deltaTime));
            if ( saniyedehareket.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (saniyedehareket.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ruzgar")
        {
            ItmeYonu = transform.position - collision.transform.position;
            mesafe = Mathf.Sqrt(ItmeYonu.x * ItmeYonu.x + ItmeYonu.y * ItmeYonu.y);
            ItmeVektoru = new Vector2(ItmeYonu.x / mesafe, ItmeYonu.y / mesafe);
            etkiS�n�r�ndaM� = true;
        }
        if (collision.tag == "sahil")
        {
            SpawnLightning.�lenK�yl� += 1;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ruzgar")
        {
            etkiS�n�r�ndaM� = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dalga")
        {
            SpawnLightning.�lenK�yl� += 1;
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="y�ld�r�m")
        {
            SpawnLightning.�lenK�yl� += 1;
           // Debug.Log(SpawnLightning.�lenK�yl�);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "kuzey")
        {
            Yukar�CarpmaVektor();
        }
        else if (collision.gameObject.tag == "g�ney")
        {
            Assag�CarpmaVektor();
        }
        else if (collision.gameObject.tag == "bat�")
        {
            SolaCarpmaVektor();
        }
        else if (collision.gameObject.tag == "do�u")
        {
            SagaCarpmaVektor();
        }
        else
        {
            calcuateNewMovementVector();
        }
    }
    void calcuateNewMovementVector()
    {
        hareketY�n� = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        saniyedehareket = hareketY�n� * karakterH�z;
    }
    
    void SagaCarpmaVektor()
    {
        hareketY�n� = new Vector2(Random.Range(-1.0f, 0f), Random.Range(-1.0f, 1.0f)).normalized;
        saniyedehareket = hareketY�n� * karakterH�z;
    }
    void SolaCarpmaVektor()
    {
        hareketY�n� = new Vector2(Random.Range(0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        saniyedehareket = hareketY�n� * karakterH�z;
    }
    void Assag�CarpmaVektor()
    {
        hareketY�n� = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(0f, 1.0f)).normalized;
        saniyedehareket = hareketY�n� * karakterH�z;
    }
    void Yukar�CarpmaVektor()
    {
        hareketY�n� = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 0f)).normalized;
        saniyedehareket = hareketY�n� * karakterH�z;
    }
}
