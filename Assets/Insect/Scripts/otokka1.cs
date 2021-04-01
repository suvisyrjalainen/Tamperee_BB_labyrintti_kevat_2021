using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otokka1 : MonoBehaviour
{
    // Start is called before the first frame update

    int layer_index;
    //private float horisontaalinenPyorinta = 0;

    void Start()
    {
        layer_index = LayerMask.GetMask("wall");
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController hahmokontrolleri = GetComponent<CharacterController>();
        Vector3 nopeus = new Vector3(0, 0, 1);

        
        hahmokontrolleri.Move(nopeus * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {  
        print("tormays tapahtunut");

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("wall"))
        {
            print("osuin seinaan");
        }
    }


}
