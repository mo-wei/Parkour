using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �ϰ��������
/// </summary>
public class ObstacleCreator : MonoBehaviour
{

    //���������ϰ����Ԥ����
    public GameObject[] obstacles;
    public GameObject[] coins;
    //�����ϰ�ʱ����Ʊ���
    public float obstacleCreatorTime;
    private float lastObstacleCreatorTime;

    private Level level;

    private float flyCoinCreatTime;
    public bool isfly;

    //�Ѷ�
    enum Level
    {
        EASY,
        MIDDLE,
        DIFFICULT
    };

    private void Start()
    {
        level = Level.EASY;
    }


    private void Update()
    {
        CreatFlyCoin();
        if (Time.time - lastObstacleCreatorTime > obstacleCreatorTime)
        {
            CreatObstacle();
        }

        if(Time.time > 30f)
        {
            level = Level.MIDDLE;
        }
        else if(Time.time > 60f)
        {
            level = Level.DIFFICULT;
        }
        
    }

    private void CreatObstacle()
    {
        int RoadIndex = Random.Range(0, 3);
        int obstacleIndex = Random.Range(0, obstacles.Length);
        int RoadIndex_No = Random.Range(0, 3);
        int obstaclesIndexOne = Random.Range(0, obstacles.Length), obstaclesIndexTwo = Random.Range(0, obstacles.Length);
        int coinsIndex = Random.Range(0, coins.Length);
        int coinRoadIndex = Random.Range(0, 2);
        //���·�����Ʒ����
        switch (level)
        {
            
            //���Ѷ�
            case Level.EASY:
               
                if (RoadIndex == 0)
                {
                    Instantiate(obstacles[obstacleIndex], new Vector3(-4, 0.4f, 70), Quaternion.identity);
                    if(coinRoadIndex == 0)
                    {
                        Instantiate(coins[coinsIndex], new Vector3(0, 1f, 70), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(coins[coinsIndex], new Vector3(4, 1f, 70), Quaternion.identity);

                    }
                }
                else if (RoadIndex == 1)
                {
                    Instantiate(obstacles[obstacleIndex], new Vector3(0, 0.4f, 70), Quaternion.identity);
                    if (coinRoadIndex == 0)
                    {
                        Instantiate(coins[coinsIndex], new Vector3(-4, 1f, 70), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(coins[coinsIndex], new Vector3(4, 1f, 70), Quaternion.identity);

                    }
                }
                else if (RoadIndex == 2)
                {
                    Instantiate(obstacles[obstacleIndex], new Vector3(4, 0.4f, 70), Quaternion.identity);
                    if (coinRoadIndex == 0)
                    {
                        Instantiate(coins[coinsIndex], new Vector3(0, 1f, 70), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(coins[coinsIndex], new Vector3(-4, 1f, 70), Quaternion.identity);

                    }
                }
                break;

            //�е��Ѷ�
            case Level.MIDDLE:
                if (RoadIndex_No == 0)
                {
                    Instantiate(obstacles[obstaclesIndexOne], new Vector3(0, 0.4f, 70), Quaternion.identity);
                    Instantiate(obstacles[obstaclesIndexTwo], new Vector3(4, 0.4f, 70), Quaternion.identity);

                    Instantiate(coins[coinsIndex], new Vector3(-4, 1, 70), Quaternion.identity);

                }
                else if (RoadIndex_No == 1)
                {
                    Instantiate(obstacles[obstaclesIndexOne], new Vector3(4, 0.4f, 70), Quaternion.identity);
                    Instantiate(obstacles[obstaclesIndexTwo], new Vector3(-4, 0.4f, 70), Quaternion.identity);

                    Instantiate(coins[coinsIndex], new Vector3(0, 1, 70), Quaternion.identity);


                }
                else if (RoadIndex_No == 2)
                {
                    Instantiate(obstacles[obstaclesIndexOne], new Vector3(-4, 0.4f, 70), Quaternion.identity);
                    Instantiate(obstacles[obstaclesIndexTwo], new Vector3(0, 0.4f, 70), Quaternion.identity);

                    Instantiate(coins[coinsIndex], new Vector3(4, 1, 70), Quaternion.identity);

                }
                break;

            //���� 
            case Level.DIFFICULT:
                obstacleCreatorTime = 1f;
                if (RoadIndex_No == 0)
                {
                    Instantiate(obstacles[obstaclesIndexOne], new Vector3(0, 0.4f, 70), Quaternion.identity);
                    Instantiate(obstacles[obstaclesIndexTwo], new Vector3(4, 0.4f, 70), Quaternion.identity);

                    Instantiate(coins[coinsIndex], new Vector3(-4, 1, 70), Quaternion.identity);


                }
                else if (RoadIndex_No == 1)
                {
                    Instantiate(obstacles[obstaclesIndexOne], new Vector3(4, 0.4f, 70), Quaternion.identity);
                    Instantiate(obstacles[obstaclesIndexTwo], new Vector3(-4, 0.4f, 70), Quaternion.identity);

                    Instantiate(coins[coinsIndex], new Vector3(0, 1, 70), Quaternion.identity);

                }
                else if (RoadIndex_No == 2)
                {
                    Instantiate(obstacles[obstaclesIndexOne], new Vector3(-4, 0.4f, 70), Quaternion.identity);
                    Instantiate(obstacles[obstaclesIndexTwo], new Vector3(0, 0.4f, 70), Quaternion.identity);

                    Instantiate(coins[coinsIndex], new Vector3(4, 1, 70), Quaternion.identity);
                }
                break;
        }
        lastObstacleCreatorTime = Time.time;
    }


    private void CreatFlyCoin()
    {
        if(isfly)
        {
            flyCoinCreatTime = 10f;
            isfly = false;
        }
        else
        {
            flyCoinCreatTime -= Time.deltaTime;
        }
        if (flyCoinCreatTime > 0 && (Time.time - lastObstacleCreatorTime) > obstacleCreatorTime)
        {
            int indexCoinOne = Random.Range(0, coins.Length);
            int indexCoinTwo = Random.Range(0, coins.Length);

            int indexRoad = Random.Range(0, 3);
            if(indexRoad == 0)
            {
                Instantiate(coins[indexCoinOne], new Vector3(0, 10.5f, 40), Quaternion.identity);
                Instantiate(coins[indexCoinTwo], new Vector3(4, 10.5f, 40), Quaternion.identity);

            }
            if (indexRoad == 1)
            {
                Instantiate(coins[indexCoinOne], new Vector3(-4, 10.5f, 40), Quaternion.identity);
                Instantiate(coins[indexCoinTwo], new Vector3(4, 10.5f, 40), Quaternion.identity);

            }
            if (indexRoad == 2)
            {
                Instantiate(coins[indexCoinOne], new Vector3(-4, 10.5f, 40), Quaternion.identity);
                Instantiate(coins[indexCoinTwo], new Vector3(0, 10.5f, 40), Quaternion.identity);

            }

        }



    }

}