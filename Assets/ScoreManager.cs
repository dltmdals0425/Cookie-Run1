using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //�̱��� : ������ ����
    //��ü�� 1���� ������ �����ǵ��� �����ϴ� ���.

    public static ScoreManager Instance;

    private int currentScore = 0;

    [SerializeField] private Text scoreText;

    private void Awake()
    {
        // �̱��� ����
        if (Instance != null)
        {
            return; 
        }
         Instance = this;
    }

    public void AddScore(int Value)
    {
        currentScore += Value;
        Debug.Log($"{Value}���� �����Ͽ� ����{currentScore}��");
       
    }

    public int GetScore()
    {
        return currentScore; 
    }


}