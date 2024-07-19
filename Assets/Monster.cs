using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] private HpBar hpBar;
    [SerializeField] private Text nameText;

    [SerializeField] private string monsterName;
    [SerializeField] private float maxHp;
    private float CurHp;
    public int getmoney;

    private bool isDead = false;
    private Animator animator;
    

    private void Awake()
    {
        CurHp = maxHp;
        animator = GetComponent<Animator>();
        nameText.text = monsterName;
        getmoney = UnityEngine.Random.Range(1, 11);

    }

    public void OnHit(float damage)
    {
        CurHp -= damage;
        if (CurHp <= 0)
        {
            CurHp = 0;
            isDead = true;
        }
        animator.SetTrigger("Hit");
        Debug.Log("slime Hit!, Current Hp :" +  CurHp);
        hpBar.ChangeHpBarAmount(CurHp / maxHp);

        if (isDead)
        {
            Debug.Log("slime is Dead");
            animator.SetTrigger("Death");
            Destroy(gameObject, 1.5f);
           
        }
    }
    public bool IsDead
    {
        get { return isDead; }
    }
}


