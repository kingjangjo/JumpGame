using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(destroy());//일정 시간이 지날 시 파괴
    }
    public float speed = 5f;//속도

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;//좌측으로 이동
    }
    IEnumerator destroy()//파괴
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(this.gameObject);
    }
}
