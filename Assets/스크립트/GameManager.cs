using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//��� ������ �����ϴ� ������ �ϴ� Ŭ����
public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Invoke("GameStart",3f);// Invoke Game Start��� �Ÿ� 3�ʵڿ� �������ְڴ�.3�� ����ó���� ���ؼ�GameStart()
       
    }
    private void GameStart()
    { 
        GameTimer.Instance.StartTimer();//�ð� ī��Ʈ ����
        PlayerController.Instance.GameStart(); //ĳ���� ���۽���
        ScoreManager.Instance.GameStart(); //���� ī��Ʈ ����.
        BackgroundScroller.Intance.GameStart();//��� ��ũ�� ����

    }

}
