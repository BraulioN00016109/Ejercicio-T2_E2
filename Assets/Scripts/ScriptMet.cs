using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMet : MonoBehaviour
{
    public float velocidad = 8f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;



    private int muerte = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (muerte <= 0)
        {

            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "bala")
        {
            muerte = muerte - 1;

        }
        if (collision.gameObject.tag == "bala2")
        {
            muerte = muerte - 3;

        }
        if (collision.gameObject.tag == "Bala3")
        {
            Destroy(gameObject);

        }
    }

}
