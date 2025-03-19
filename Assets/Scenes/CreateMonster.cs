using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score
{
    public int score;
}
public class CreateMonster : MonoBehaviour
{
    public GameObject big;
    public GameObject little;
    public GameObject fly;
    public GameObject Wind;
    public Text text;
    void Start()
    {
        Score score = new Score();
        StartCoroutine(SelectScore());
        StartCoroutine(Create());
        StartCoroutine(Crfly());
        StartCoroutine(CrWind());
    }
    IEnumerator SelectScore()
    {
        Score score = new Score();
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            score.score++;
            text.text = "Score:"+score.score.ToString();
        }
    }
    IEnumerator Create()
    {
        float deldo = 0;
        while (true)
        {
            float delay = Random.Range(1.0f-deldo, 2.0f-deldo);//��ֹ� ���� ��
            int rand = Random.Range(0, 2);//��ֹ� ���� ����
            if (rand == 1)//�� ��ֹ� ����
            {
                yield return new WaitForSeconds(delay);
                deldo += 0.0002f;
                if (deldo > 1.0f)
                {
                    Time.timeScale = 0;
                }
                CRbig();
            }
            else//ª�� ��ֹ� ����
            {
                yield return new WaitForSeconds(delay);
                deldo += 0.002f;
                if (deldo > 1.0f)
                {
                    Time.timeScale = 0;
                }
                CRlittle();
            }
            
        }
    }
    IEnumerator Crfly()//�ϴ��� ���� ��ֹ� ��ȯ
    {
        float deldo = 0;
        while (true)
        {
            float delay = Random.Range(3.0f - deldo, 5.0f - deldo);//���� ��
            int rand = Random.Range(0, 2);//���� ����
            if (rand == 1)
            {
                yield return new WaitForSeconds(delay);
                deldo += 0.0002f;
                if (deldo > 1.0f)
                {
                    Time.timeScale = 0;
                }
                CRfly();
            }
        }
    }
    IEnumerator CrWind()//�ٶ� ����Ʈ
    {
        float deldo = 0;
        while (true)
        {
            float delay = Random.Range(2.0f - deldo, 4.0f - deldo);
            int rand = Random.Range(0, 2);
            if (rand == 1)
            {
                yield return new WaitForSeconds(delay);
                CRWind();
            }
        }
    }
    void CRbig()//�� ��ֹ� ��ȯ
    {
        Instantiate(big, new Vector2(13, -5), Quaternion.identity);
    }
    void CRlittle()//���� ��ֹ� ��ȯ
    {
        Instantiate(little, new Vector2(13, -5), Quaternion.identity);
    }
    void CRfly()//�ϴ��� ���� ��ֹ� ��ȯ
    {
        Instantiate(fly, new Vector2(13, 0.3f), Quaternion.identity);
    }
    void CRWind()//�ٶ� ����Ʈ ��ȯ
    {
        Instantiate(Wind, new Vector2(15, 2), Quaternion.identity);
    }
}
