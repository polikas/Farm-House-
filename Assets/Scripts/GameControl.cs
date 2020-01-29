using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    Player player;
    const int TAX_AMOUNT = 500;
    bool isPaused;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Start()
    {
        isPaused = false;
        StartCoroutine(TaxMethod());
    }
    // Update is called once per frame
    void Update ()
    {
		if(player.getMoney() <= 0)
        {
            triggerGameOver();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            resumeGame();
        }
	}

    IEnumerator TaxMethod()
    {
        yield return new WaitForSeconds(10f);
        player.updateMoney(-TAX_AMOUNT);
        StartCoroutine(TaxMethod());
    }
    private void triggerGameOver()
    {
       
        PlayerUI UI = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerUI>();
        UI.screenText.text = "GAME OVER";
        UI.screenText.gameObject.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }
    void pauseGame()
    {
        PlayerUI UI = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerUI>();
        UI.screenText.text = "PAUSED";
        UI.screenText.gameObject.SetActive(true);
        UI.setHouseMenu(false);
      
        isPaused = true;
        Time.timeScale = 0;
    }
    void resumeGame()
    {
        PlayerUI UI = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerUI>();
        UI.screenText.text = "PAUSED";
        UI.screenText.gameObject.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }
}
