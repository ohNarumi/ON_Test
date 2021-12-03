using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    // パネル
    [SerializeField] GameObject topPanel;
    [SerializeField] GameObject statusPanel;
    [SerializeField] GameObject taskPanel;
    [SerializeField] GameObject taskSettingPanel;
    // Start is called before the first frame update

    // スクリプト
    [SerializeField] ModelController modelController;

    [SerializeField] AppController appController;
    void Start()
    {
        BackToTop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // トップ画面への遷移
    public void BackToTop()
    {
        topPanel.SetActive(true);
        statusPanel.SetActive(false);
        taskPanel.SetActive(false);
        taskSettingPanel.SetActive(false);

        modelController.ModelReset();
        appController.TopCameraSetting();
    }
    // ステータス画面への遷移
    public void SelectStatusDescription()
    {
        topPanel.SetActive(false);
        statusPanel.SetActive(true);
        taskPanel.SetActive(false);
        taskSettingPanel.SetActive(false);

        modelController.ModelReset();
        appController.StatusCameraSetting();
    }
    // タスク画面への遷移
    public void SelectTaskDescription()
    {
        topPanel.SetActive(false);
        statusPanel.SetActive(false);
        taskPanel.SetActive(true);
        taskSettingPanel.SetActive(false);

        modelController.ModelReset();
    }
    // タスク設定画面への遷移
    public void SelectTaskSettingDescription()
    {
        topPanel.SetActive(false);
        statusPanel.SetActive(false);
        taskPanel.SetActive(false);
        taskSettingPanel.SetActive(true);

        modelController.ModelReset();
    }

    // ゲームへの遷移
    public void AppToGame()
    {
        modelController.ModelReset();
        SceneManager.LoadScene("Game1");
    }
}
