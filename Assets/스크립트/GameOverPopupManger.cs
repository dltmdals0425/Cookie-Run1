using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//게임오버발생하면 팝업 띄워주는 역할.
//팝업 열릴때 기록 갱신했는지 체크ui표기
//게임 재시작하는 기능, 타이틀 씬 되돌아 가는 역할
public class GameOverPopupManger : MonoBehaviour
{
    public static GameOverPopupManger Intance;
    [SerializeField] private GameObject overPopup;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private Button reTryBtn;
    [SerializeField] private Button returnTitle;

    private void Awake()
    {
        if (Intance==null)
        {
            Intance = this;
        }
        else 
            Destroy(gameObject);
        //람다식 문법
        reTryBtn.onClick.AddListener(() => {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });//AddListener 유니티 엔진에서 반응해 줄 코드
        //현재 열린 씬을 다시 불러 들이기하겠다.
        //해당 버튼이 클릭이 되었을때 실행되어야 하는 코드.
        returnTitle.onClick.AddListener(() => {
            Time.timeScale = 0;
            SceneManager.LoadScene(0); });//0번 씬
        //해당 버튼이 클릭이 되었을때 실행되어야 하는 코드.
    }

    public void ShowGameOverPopup()
    { //게임 종료시 팝업 열어주는 역할.
        ScoreManager.Instance.TryUpdateBestScore();//현게임의 점수가 best를 갱신했는지 체크.
        finalScoreText.text = $"BestScore: {ScoreManager.Instance.GetScore()}";
        bestScoreText.text = $"CurrentScore: {ScoreManager.Instance.GetBestScore()}";
        overPopup.transform.localScale = Vector3.one;   



    }
}
