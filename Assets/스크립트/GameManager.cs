using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//모든 게임의 시작하는 역할을 하는 클래스
public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Invoke("GameStart",3f);// Invoke Game Start라는 거를 3초뒤에 실행해주겠다.3초 지연처리를 통해서GameStart()
       
    }
    private void GameStart()
    { 
        GameTimer.Instance.StartTimer();//시간 카운트 시작
        PlayerController.Instance.GameStart(); //캐릭터 조작시작
        ScoreManager.Instance.GameStart(); //점수 카운트 시작.
        BackgroundScroller.Intance.GameStart();//배경 스크롤 시작

    }

}
