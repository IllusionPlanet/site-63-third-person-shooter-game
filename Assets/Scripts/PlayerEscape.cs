using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerEscape : MonoBehaviour
{
    public GameObject player;
    bool isPlayerEscaped;
    public Text warningUI;
    public CanvasGroup escapedUI;
    float timer;
    float fadeDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerEscaped == true)
        {
            timer += Time.deltaTime;
            escapedUI.alpha = timer / fadeDuration;
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
            if (player.GetComponent<Dulake>().gotComputer == true)
                isPlayerEscaped = true;
            else
                warningUI.text = "需要获取机密物品才可逃离！";
        }
    }
}
