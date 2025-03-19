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
        Time.timeScale = 1;//씬이 시작됐을때 시작
        rbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (isgrounded && Input.GetKey(KeyCode.Space))//스페이스 키를 누를 시/플레이어가 땅에 붙어 있을때 점프
        {
            rbody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isgrounded = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))//장애물과 닿을 시 멈추고 다음 씬으로 넘긴다
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("Die");
        }
        if (other.gameObject.CompareTag("Ground"))//땅에 닿았는지 확인
        {
            isgrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)//땅에 닿지 않았는지 확인
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isgrounded = false;
        }
    }
}
