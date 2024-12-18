using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    PlayerInput inputs;
    public float score;
    public float time = 60;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreTextOver;
    [SerializeField] GameObject gameOver;
    private IEnumerator coroutine;
    
    void Awake(){
        inputs = new PlayerInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputs.UI.Pause.performed += ctx => pauseMenu();
        coroutine = timerUp(1f);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();

        if (time == 0)
        {
            gameOver.SetActive(true);
            scoreTextOver.text = score.ToString();
        }
    }

    void updateScore(){
        scoreText.text = score.ToString();
    }

    public void pauseMenu(){
        GameObject pausePanel = pauseCanvas.transform.GetChild(0).gameObject; 
        pausePanel.SetActive(!pausePanel.activeSelf);
        if (pausePanel.activeSelf)
        {
            Time.timeScale = 0;
        }else{
            Time.timeScale = 1;
        }
    }

    public void toMain(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void retry(){
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    void OnEnable()
    {
        inputs.Enable();
    }

    void OnDisable()
    {
        inputs.Disable();
    }

    IEnumerator timerUp(float waktu){
        while (time > 0)
        {
            yield return new WaitForSeconds(waktu);
            time--;
            timerText.text = time.ToString();
        }
    }
}
