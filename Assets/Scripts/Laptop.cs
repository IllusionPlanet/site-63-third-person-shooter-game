using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laptop : MonoBehaviour
{
    public GameObject player;
    public Text criticalItemText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        player.GetComponent<Dulake>().gotComputer = true;
        criticalItemText.text = "已获取机密物品";
        Destroy(this.gameObject);
    }
}
