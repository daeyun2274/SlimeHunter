using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Monster[] slime;
    [SerializeField] private float damage;
    private Monster curSlime;
    public int curmoney;
    public Monster isDead;
    public Monster getmoney;
    public void SpawnSlime()
    {
        int spawnIndex = UnityEngine.Random.Range(0, slime.Length);
        GameObject newSlime = Instantiate(slime[spawnIndex].gameObject);
        curSlime = newSlime.GetComponent<Monster>();
    }

    private void Update()
    {
        if (curSlime == null)
        {
            SpawnSlime();
        }
    }

    public void HitSlime()
    {
        //������ ���� �ɷ� ��ȭ�ϸ� Ȯ�� �ö󰡰� �����
        int critical = UnityEngine.Random.Range(0, 10);
        if (curSlime != null)
        {
            if (critical == 0)
            {
                curSlime.OnHit(damage + 10); //�������� ������ ���� ũ��Ƽ�� ������ ��ȭ �����ϰ� �����
                Debug.Log("Critical!");
            }

            else
            {
                curSlime.OnHit(damage);
            }
            Money();
        }

    }

    public void Money()
    {
        if (curSlime.IsDead)
        {
            curmoney += curSlime.getmoney;
            Debug.Log("get money! : " + curSlime.getmoney);
            Debug.Log("curent money :" + curmoney);
        }
    }
}
