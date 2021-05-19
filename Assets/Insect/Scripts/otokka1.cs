using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otokka1 : MonoBehaviour
{
    // Start is called before the first frame update

    int layer_index;


    public float horisontaalinenPyorinta = 0;

    void Start()
    {
        layer_index = LayerMask.GetMask("wall");
        layer_index = LayerMask.GetMask("bullet");
        print(layer_index);
    }

    // Update is called once per frame
    void Update()
    {
        //eteenpäin meno
        CharacterController hahmokontrolleri = GetComponent<CharacterController>();
        Vector3 nopeus = new Vector3(0, 0, 1);

        //kääntyminen
        transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0);
        nopeus = transform.rotation * nopeus;

        //kokonaisliikkuminen
        hahmokontrolleri.Move(nopeus * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {  
        int kaannos = Random.Range(90, 270);

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("wall"))
        {
            print("osuin seinaan");
            horisontaalinenPyorinta += kaannos;
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("bullet"))
        {
            print("minuun osui");
        }

        if (collision.gameObject.tag == "bullet")
        {
            print("minuun osui");
        }


    }

    


    }
