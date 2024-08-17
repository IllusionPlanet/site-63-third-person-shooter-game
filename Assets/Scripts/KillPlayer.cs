using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    bool isPlayerInRange = false;
    public CanvasGroup getKilledUI;
    float timer;
    float fadeDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange == true)
        {
            timer += Time.deltaTime;
            getKilledUI.alpha = timer / fadeDuration;
            if (timer > fadeDuration + 1f)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerInRange = true;
            player.GetComponent<Animator>().SetBool("IsKilled", true);
        }
    }
}
