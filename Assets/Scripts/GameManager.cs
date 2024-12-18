using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    PlayerInput inputs;
    
    void Awake(){
        inputs = new PlayerInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputs.UI.Pause.performed += ctx => pauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    void OnEnable()
    {
        inputs.Enable();
    }

    void OnDisable()
    {
        inputs.Disable();
    }
}
