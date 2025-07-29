using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //싱글톤 : 디자인 패턴
    //객체가 1개만 유지만 유지되도록 강제하는 방식.

    public static ScoreManager Instance;

    private int currentScore = 0;

    [SerializeField] private Text scoreText;

    private void Awake()
    {
        // 싱글톤 설정
        if (Instance != null)
        {
            return; 
        }
         Instance = this;
    }

    public void AddScore(int Value)
    {
        currentScore += Value;
        Debug.Log($"{Value}점이 증가하여 최종{currentScore}점");
       
    }

    public int GetScore()
    {
        return currentScore; 
    }


}