using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMega : MonoBehaviour
{
    public float velocidadCorrer = 10;
    private Animator animator;
    private Rigidbody2D rb;
    public float fuerzaSalto = 10f;



    private Transform tr;


    private SpriteRenderer sr;
    private const int Animacion_Quieto = 0;
    private const int Animacion_Correr = 1;
    private const int Animacion_Saltar = 2;
    private const int Animacion_Disparar = 3;

    private int estadoBala = 0;

    public Transform BalaTransform;
    public GameObject Pbala;
    public GameObject Mbala;
    public GameObject Gbala;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {



            if (Input.GetKey(KeyCode.RightArrow))
            {
                MovimientoDerecha();
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                MovimientoIzquierda();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Saltar();
            }
             else if (Input.GetKeyUp(KeyCode.X))
             {

            CambiarAnimacion(Animacion_Disparar);

            if (estadoBala > 50)
            {

                Instantiate(Gbala, BalaTransform.position, Quaternion.identity);
                estadoBala = 0;

            }
            else if (estadoBala > 30)
            {

                Instantiate(Mbala, BalaTransform.position, Quaternion.identity);
                estadoBala = 0;

            }
            else if (estadoBala > 0)
            {

                Instantiate(Pbala, BalaTransform.position, Quaternion.identity);
                estadoBala = 0;

            }
        }
        else if (Input.GetKey(KeyCode.X))
            {
            estadoBala++;


            }
        else
            {
                EstarQuieto();
            }

    }

    private void CambiarAnimacion(int animation)
    {
        animator.SetInteger("estado", animation);
    }

    private void Saltar()
    {
        rb.velocity = Vector2.up * fuerzaSalto;
        CambiarAnimacion(Animacion_Saltar);
    }

    private void MovimientoIzquierda()
    {
        tr.localScale = new Vector3(-10f, 10f, 10);
        rb.velocity = new Vector2(-velocidadCorrer, rb.velocity.y);
        CambiarAnimacion(Animacion_Correr);
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Saltar();
        }
    }

    private void MovimientoDerecha()
    {
        tr.localScale = new Vector3(10f, 10f, 1);
        rb.velocity = new Vector2(velocidadCorrer, rb.velocity.y);
        CambiarAnimacion(Animacion_Correr);
       

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Saltar();
        }
    }

    private void EstarQuieto()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        CambiarAnimacion(Animacion_Quieto);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Suelo")
        {
            Debug.Log("aaaaaa");
        }

    }

}
