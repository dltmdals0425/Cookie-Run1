using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //�̱��� : ������ ����
    //��ü�� 1���� ������ �����ǵ��� �����ϴ� ���.

    public static ScoreManager Instance;

    private int currentscore = 0;
    private int bestScore = 0;
    private const string BestScoreKey = "BestScore";
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        // �̱��� ����
        if (Instance != null)
        {
            return; 
        }
         Instance = this;
        LoadBestScore();
    }
    public void GameStart()
    {
        currentscore = 0;

        UpdateGameScoreUI();


    }
    public void AddScore(int Value)
    {
        currentscore += Value;
        UpdateGameScoreUI();
        Debug.Log($"{Value}���� �����Ͽ� ����{currentscore}��");
       
    }

    public int GetScore()
    {
        return currentscore; 
    }
    public int GetBestScore()
    { 
    return bestScore;
    }
    private void UpdateGameScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = currentscore.ToString();
        }
    }
    public void TryUpdateBestScore()
    {
        if (currentscore>bestScore)
        {
            bestScore = currentscore;
            //rom�����͸� ����
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
            PlayerPrefs.Save();
            Debug.Log($"��� ���� :{bestScore}");
        }
        else
        {
            Debug.Log($"��� ���� ����");
        }
    }
    private void LoadBestScore()
    { bestScore = PlayerPrefs.GetInt(BestScoreKey,0); }
}