using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(destroy());//���� �ð��� ���� �� �ı�
    }
    public float speed = 5f;//�ӵ�

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;//�������� �̵�
    }
    IEnumerator destroy()//�ı�
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(this.gameObject);
    }
}
