using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public GameObject enemyArea;
    public GameObject enemy;
    public GameObject losePanel;

    private void Start()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Score", 0);
        losePanel.SetActive(false);
        UpdateText();


        SpawnEnemys();
    }

    public float everyxt = 5f;
    public float time;

    public void Update()
    {
        time += Time.deltaTime;
        
        if(time > everyxt + time)
            Debug.Log(time);
    }

    public void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + 1);
        UpdateText();
    }

    private void UpdateText()
    {
        score.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }

    public void Lose()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SpawnEnemys()
    {
        int count = enemyArea.transform.childCount;

        for (int i = 0; i < count; i++)
        {

            Instantiate(
                enemy,
                enemyArea.transform.GetChild(i).gameObject.transform.position,
                Quaternion.Euler(0, 0, 0)
            );

        }
    }
}
