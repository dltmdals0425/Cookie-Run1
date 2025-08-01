using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //싱글톤 : 디자인 패턴
    //객체가 1개만 유지만 유지되도록 강제하는 방식.

    public static ScoreManager Instance;

    private int currentscore = 0;
    private int bestScore = 0;
    private const string BestScoreKey = "BestScore";
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        // 싱글톤 설정
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
        Debug.Log($"{Value}점이 증가하여 최종{currentscore}점");
       
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
            //rom데이터를 저장
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
            PlayerPrefs.Save();
            Debug.Log($"기록 갱신 :{bestScore}");
        }
        else
        {
            Debug.Log($"기록 갱신 실패");
        }
    }
    private void LoadBestScore()
    { bestScore = PlayerPrefs.GetInt(BestScoreKey,0); }
}