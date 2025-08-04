using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//���ӿ����߻��ϸ� �˾� ����ִ� ����.
//�˾� ������ ��� �����ߴ��� üũuiǥ��
//���� ������ϴ� ���, Ÿ��Ʋ �� �ǵ��� ���� ����
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
        //���ٽ� ����
        reTryBtn.onClick.AddListener(() => {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });//AddListener ����Ƽ �������� ������ �� �ڵ�
        //���� ���� ���� �ٽ� �ҷ� ���̱��ϰڴ�.
        //�ش� ��ư�� Ŭ���� �Ǿ����� ����Ǿ�� �ϴ� �ڵ�.
        returnTitle.onClick.AddListener(() => {
            Time.timeScale = 0;
            SceneManager.LoadScene(0); });//0�� ��
        //�ش� ��ư�� Ŭ���� �Ǿ����� ����Ǿ�� �ϴ� �ڵ�.
    }

    public void ShowGameOverPopup()
    { //���� ����� �˾� �����ִ� ����.
        ScoreManager.Instance.TryUpdateBestScore();//�������� ������ best�� �����ߴ��� üũ.
        finalScoreText.text = $"BestScore: {ScoreManager.Instance.GetScore()}";
        bestScoreText.text = $"CurrentScore: {ScoreManager.Instance.GetBestScore()}";
        overPopup.transform.localScale = Vector3.one;   



    }
}
