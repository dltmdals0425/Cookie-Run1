using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruititem : MonoBehaviour
{//di: ������ ����������Ȱ���ؾߵǴµ�
    //�ϵ��ڵ�������� �־��ٰ���
    // Start is called before the first frame update
    [SerializeField] private int scoreValue = 50;
    //IS Trigger�����϶� �ٸ� �ø����� ��ø(������)�� �Ǿ���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //tag�� Ȯ�� �ϴ¹���� ����Ұ���
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{scoreValue} ���� ���� ");//���¸� �����صδ°���
            ScoreManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);//�ڱ��ڽ��� ������Ʈ�� �ı��Ѵ�


        }
    }
}
    //enter�� ����