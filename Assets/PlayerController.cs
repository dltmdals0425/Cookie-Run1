using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;//������ ��
    private Rigidbody2D rb;//�ش� ������Ʈ�� ������ ����
    private bool isGruond = true;//�ٴڿ� ��� �ִ����� üũ
    private Vector3 origianlScale = Vector3.one;//ĳ������ ���� ũ��
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation= true;
        origianlScale = transform.localScale;
        anim = GetComponentInChildren<Animator>();
       
    }

      private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)&& isGruond)
        {
            rb.velocity = new Vector2(0f, jumpForce);      //���ν�Ƽ�� ����� �ӵ��� ����������
            isGruond=false;//������ ������ �����ʵ��� ����.
            
        }
        anim.SetBool("jumping", !isGruond);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gruond"))
        {
            isGruond = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("���� ����");
            Time.timeScale = 0f;//timeScale ������ ���� �ӵ�(�ð��� �帧) �������ټ��ִ°� �⺻���� 1, 2����� 2, �����Կ��ϸ� 0�������� ���ָ��
            
         }
    }
}
