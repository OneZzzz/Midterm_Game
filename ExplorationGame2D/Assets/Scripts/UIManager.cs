using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }
    private Text scoreText;
    private GameObject dia,tips,task;
    private Text diaText;
    private List<string> diaMessages;
    private int diaIndex;
    private Image life;

    public static bool isInDiaState;

    public int taskNumber=0;
    public int currentTaskNumber;

    private bool currentIsShow;


    private GameObject winUI, loseUI;

    private void Start()
    {
        isInDiaState = false;
        scoreText = transform.Find("score").GetComponent<Text>();
        dia = transform.GetChild(1).gameObject;
        tips = transform.GetChild(2).gameObject;
        task = transform.GetChild(3).gameObject;
        winUI = transform.GetChild(5).gameObject;
        loseUI = transform.GetChild(6).gameObject;
        diaText = dia.GetComponentInChildren<Text>();
        life = transform.Find("life").GetChild(0).GetComponent<Image>();
        dia.SetActive(false);
        ShowScore(0);
        ShowTaskMessage();
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.J) || Input.GetMouseButtonDown(0))
        {
            if (currentIsShow) return;
            ShowNextDiaMessage();
        }
        currentIsShow = false;
    }


    public void ShowScore(int score)
    {
        scoreText.text = "Score:" + score.ToString();
    }

    public void ShowDialo(List<string> messages)
    {
        if (dia.activeSelf) return;
        isInDiaState = true;
        diaMessages = messages;
        diaIndex = 0;
        ShowNextDiaMessage();
    }
    private void ShowNextDiaMessage()
    {
        if (!isInDiaState) return;
        currentIsShow = true;
        dia.SetActive(true);
        if (diaIndex >= diaMessages.Count)
        {
            diaText.text = "";
            isInDiaState = false;
            dia.SetActive(false);
        }
        else
        {
            diaText.text = diaMessages[diaIndex];
            diaIndex++;
        }

    }
    public void ShowTips(string message)
    {
        tips.SetActive(true);
        Text text = tips.GetComponentInChildren<Text>();
        text.text = message;
        Invoke("CloseTips", 3f);
    }
    private void CloseTips()
    {
        tips.SetActive(false);
    }

    public void FindTaskApple()
    {
       GameObject go=  Resources.Load<GameObject>("appleUI");
        Instantiate(go, task.transform.GetChild(0));
        currentTaskNumber++;
        ShowTaskMessage();
    }
    private void ShowTaskMessage()
    {
        Text te= task.GetComponent<Text>();
        if (taskNumber == 0)
            te.text = "";
        else if (currentTaskNumber < taskNumber)
            te.text = "Task:find " + (taskNumber - currentTaskNumber) + " apple";
        else
            te.text = "Mission accomplished!";
    }
    public void ShowLife(float hp)
    {
        life.fillAmount = hp;
    }
    public void ShowWinUI()
    {
        Time.timeScale = 0;
        winUI.SetActive(true);
    }
    public void ShowLoseUI()
    {
        Time.timeScale = 0;
        loseUI.SetActive(true);
    }
    public void ReturnButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void WinEnterNextLevel()
    {
        Time.timeScale = 1;
        winUI.SetActive(false);
        SceneController co = GameObject.FindObjectOfType<SceneController>();
        if (co == null) return;
        co.EndPointChangeScene();
    }
    public void LoseRestartLevel()
    {
        loseUI.SetActive(false);
        Time.timeScale = 1;
        PlayerController.instance.LoadPoint();
    }

}
