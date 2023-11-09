using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPS1_Character : Base_Character
{
    [Header("DPS1_Property")]
    public GameObject enemy;
    public string enemyName = "Enemy";

    public void Start()
    {
        tauntValues.Add("Enemy", 1f);
        tauntValues.Add("T", 1f);
        tauntValues.Add("DPS1", 1f);

    }
    protected override void Update()
    {
        //Attack()���������Ҫ��Updateɾ���ģ������Ƿ�������������д�˸�����
        Attack();
        base.Update();
    }
    public override void Attack()
    {
        //Debug.Log("Here is TAttack");
        if (inAttackRange)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                CharacterObject[0].GetComponent<EnemyBase_Character>().GetHit(enemyName, attackValue, tauntAddValue);
                Debug.Log("here is attack");
            }
        }
    }
}
