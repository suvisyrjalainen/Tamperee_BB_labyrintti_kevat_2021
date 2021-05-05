using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammu : MonoBehaviour
{
    public float luodinNopeus = 10f;
    public GameObject luotiPrefab;
    private GameObject ammus = null;
    public Camera FPSCamera;

    // Start is called before the first frame update
    void Start()
    {
        //FPSCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ammus = Instantiate(luotiPrefab, transform.position, Quaternion.identity);
            ammus.GetComponent<Rigidbody>().AddForce(FPSCamera.transform.forward * luodinNopeus, ForceMode.Impulse);

        }

    }
}
