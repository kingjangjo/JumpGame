using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump : MonoBehaviour
{
    [SerializeField]
    float jumpforce = 5.0f;
    [SerializeField]
    Rigidbody2D rbody;
    bool isgrounded = false;
    void Start()
    {
        Time.timeScale = 1;//���� ���۵����� ����
        rbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (isgrounded && Input.GetKey(KeyCode.Space))//�����̽� Ű�� ���� ��/�÷��̾ ���� �پ� ������ ����
        {
            rbody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isgrounded = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))//��ֹ��� ���� �� ���߰� ���� ������ �ѱ��
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("Die");
        }
        if (other.gameObject.CompareTag("Ground"))//���� ��Ҵ��� Ȯ��
        {
            isgrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)//���� ���� �ʾҴ��� Ȯ��
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isgrounded = false;
        }
    }
}
