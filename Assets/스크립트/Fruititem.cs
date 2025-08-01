using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruititem : MonoBehaviour
{//di: 의존성 주입패턴을활용해야되는데
    //하드코딩방식으로 넣어줄거임
    // Start is called before the first frame update
    [SerializeField] private int scoreValue = 50;
    //IS Trigger상태일때 다른 컬리전과 중첩(겹쳐짐)이 되었다
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //tag를 확인 하는방식을 사용할거임
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{scoreValue} 점수 증가 ");//상태를 저장해두는거임
            ScoreManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);//자기자신의 오브젝트를 파괴한다


        }
    }
}
    //enter는 입장