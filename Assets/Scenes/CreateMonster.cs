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
            float delay = Random.Range(1.0f-deldo, 2.0f-deldo);//장애물 출현 빈도
            int rand = Random.Range(0, 2);//장애물 종류 결정
            if (rand == 1)//긴 장애물 출현
            {
                yield return new WaitForSeconds(delay);
                deldo += 0.0002f;
                if (deldo > 1.0f)
                {
                    Time.timeScale = 0;
                }
                CRbig();
            }
            else//짧은 장애물 출현
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
    IEnumerator Crfly()//하늘을 나는 장애물 소환
    {
        float deldo = 0;
        while (true)
        {
            float delay = Random.Range(3.0f - deldo, 5.0f - deldo);//출현 빈도
            int rand = Random.Range(0, 2);//출현 정도
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
    IEnumerator CrWind()//바람 이펙트
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
    void CRbig()//긴 장애물 소환
    {
        Instantiate(big, new Vector2(13, -5), Quaternion.identity);
    }
    void CRlittle()//작은 장애물 소환
    {
        Instantiate(little, new Vector2(13, -5), Quaternion.identity);
    }
    void CRfly()//하늘을 나는 장애물 소환
    {
        Instantiate(fly, new Vector2(13, 0.3f), Quaternion.identity);
    }
    void CRWind()//바람 이펙트 소환
    {
        Instantiate(Wind, new Vector2(15, 2), Quaternion.identity);
    }
}
