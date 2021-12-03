using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelController : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;

    // モデルをタップした時に用いる
    [SerializeField] Text dialogueText;
    [SerializeField] Material Material;

    // Start is called before the first frame update
    void Start()
    {
        // var dialogueTexts = new Dictionary<int, string>()
        // {
        //     {1, "「勝利して支配する」！それだけよ...それだけが満足感よ！"},
        //     {2, "このターンXすごいよ！さすが∀のお兄さん！！"},
        //     {3, "これって純情？正常？亀参上"},
        //     {4, "ならば私は、どこまでも生き抜いてみせる！誰よりも厳しく、戦士としてな！！"},
        //     {5, "不可能を可能にする男かな？俺は！"}
        // };

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TapDescription()
    {
        dialoguePanel.SetActive(true);
        RandamKoyasuVoice();
    }

    void RandamKoyasuVoice()
    {
        switch(Random.Range(1,5))
        {
            case 1:
                dialogueText.text = "「勝利して支配する」！\nそれだけよ...\nそれだけが満足感よ！";
                Material.color = new Color32(255,160,0,255);
                break;
            case 2:
                dialogueText.text = "このターンXすごいよ！\nさすが∀のお兄さん！！";
                Material.color = Color.green;
                break;
            case 3:
                dialogueText.text = "これって純情？\n正常？\n亀参上";
                Material.color = Color.yellow;
                break;
            case 4:
                dialogueText.text = "ならば私は、どこまでも生き抜いてみせる！\n誰よりも厳しく、戦士としてな！！";
                Material.color = new Color32(124,189,255,255);
                
                break;
            case 5:
                dialogueText.text = "不可能を可能にする男かな？\n俺は！";
                Material.color = new Color32(209,91,255,255);
                break;
            default:
                Debug.Log("予期せぬ値が入力されました");
                dialogueText.text = "予期せぬ値が入力されました";
                Material.color = Color.white;
                break;
        }
    }
    public void ModelReset()
    {
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        Material.color = Color.white;
    }
}
