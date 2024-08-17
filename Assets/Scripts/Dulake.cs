using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dulake : MonoBehaviour
{
    public AudioSource fireSound;
    public AudioSource hitSound;
    public AudioSource bgm;
    public Text ammoUI;
    Animator anim;
    Rigidbody rb;
    private float rotateSpeed = 150f;
    private float moveSpeed = 8;
    private int ammo = 12;
    public Camera camera;
    public bool gotComputer = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && anim.GetBool("IsAiming") == false)
        {
            anim.SetBool("IsRunning", true);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("IsRunning", false);
        }
        if (Input.GetKey(KeyCode.S) && anim.GetBool("IsAiming") == false)
        {
            anim.SetBool("IsRunning", true);
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("IsRunning", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,-rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("IsAiming", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("IsAiming", false);
        }
        if(anim.GetBool("IsAiming") == true && Input.GetMouseButtonDown(0))
        {
            if(ammo >= 1)
            {
                hitSound.Play();
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Robot")
                    {
                        Destroy(hit.collider.gameObject);
                        fireSound.Play();
                    }
                }
                ammo -= 1;
                ammoUI.text = "×Óµ¯£º" + ammo.ToString() + " / 12";
            }
        }
    }
}
