using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator anim;

    private float horisontaalinenPyorinta = 0;


    public float hyppyvoima = 0f;
    public float painovoima = 0f;

    private bool isGrounded = true;
    

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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Debug.Log("hyppy");
            
            nopeus.y += hyppyvoima;
            isGrounded = false;
        }

        nopeus.y = nopeus.y - painovoima * Time.deltaTime;

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

    
    /*
    void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.gameObject.name);
        if (collisionInfo.gameObject.name == "HumanoidBotAvatar_04")
        {
            Debug.Log("osuu");
            isGrounded = true;
        }
    }
    */
}
