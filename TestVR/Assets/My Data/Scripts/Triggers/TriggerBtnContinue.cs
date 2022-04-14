using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TriggerBtnContinue : GazeTrigger
{
    [SerializeField] private TextMeshProUGUI btnColor; //для обращения к цвету текста

    void Start()
    {
        if (PlayerPrefs.GetInt("PassLevel") == 0) //Серый цвет кнопки "Продолжить", если сохранений нет
            btnColor.color = new Color32(50, 50, 50, 255);
        else //Белый цвет кнопки "Продолжить", если сохранения есть
            btnColor.color = new Color32(255, 255, 255, 255);
    }

    public override void Activate()
    {
        switch (PlayerPrefs.GetInt("PassLevel"))
        {
            case 1:
                SceneManager.LoadScene("SceneAfterFirst");
                break;

            case 2:
                SceneManager.LoadScene("SceneAfterSecond");
                break;

            case 3:
                SceneManager.LoadScene("SceneAfterThird");
                break;

            case 4:
                SceneManager.LoadScene("SceneAfterFourth");
                break;
        }
    }
}
