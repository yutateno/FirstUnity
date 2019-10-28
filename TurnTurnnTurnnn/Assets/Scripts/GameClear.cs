using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    public GameObject gameClearLogo;
    public GameObject toTitleLogo;
    private GameObject player;
    private PlayerController controller;


    // Start is called before the first frame update
    void Start()
    {
        gameClearLogo.SetActive(false);
        toTitleLogo.SetActive(false);

        player = GameObject.Find("Player");
        controller = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        controller.gameEnd = true;

        gameClearLogo.SetActive(true);
        toTitleLogo.SetActive(true);
    }

    public void Totitle()
    {
        SceneManager.LoadScene("Title");
    }
}
