using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator anim;

    private float horisontaalinenPyorinta = 0;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Eteen ja sivulle liikkuminen
        CharacterController hahmokontrolleri = GetComponent<CharacterController>();
        float horizontal = Input.GetAxis("Horizontal") * 3;
        float vertical = Input.GetAxis("Vertical") * 3;
        Vector3 nopeus = new Vector3(horizontal, 0, vertical);
        

        //hiiren x verran pyöriminen
        horisontaalinenPyorinta += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0);
        
        nopeus = transform.rotation * nopeus;
        hahmokontrolleri.Move(nopeus * Time.deltaTime);

        

        if (Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("Walk", true);
            
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }
}
