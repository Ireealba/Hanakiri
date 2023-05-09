using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBaseState : State
{
    //how long this state should be active for before moving on
    public float duration;
    //animator component used to call each attacks animation as well as used for firing off animation trigger events
    protected Animator animator;
    //bool to check wether or not the next attack in the sequence should be played or not
    protected bool shouldCombo;
    //the place in the sequence of attacks this state is in
    protected int attackIndex;

    //The damage it takes to enemy
    protected int damage;
    protected Transform controlDamage;
    protected float radioDamage;

    //The cached hit collider component of this attack
    protected Collider2D hitCollider;
    //Cached already struck objects of said attack to avoid overlapping attacks on same target
    private List<Collider2D> collidersDamaged;
    //The hit Effect to Spawn on the afflicted Enemy
    //private GameObject HitEffectPrefab;

    //input buffer Timer
    private float AttackPressedTimer = 0;
    


    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator = GetComponent<Animator>();
        collidersDamaged = new List<Collider2D>();
        hitCollider = GetComponent<ComboCharacter>().hitbox;
        //HitEffectPrefab = GetComponent<ComboCharacter>().Hiteffect;
        damage = GetComponent<ComboCharacter>().damage;
        controlDamage = GetComponent<ComboCharacter>().controlDamage;
        radioDamage = GetComponent<ComboCharacter>().radioDamage;

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        AttackPressedTimer -= Time.deltaTime;



        if(Input.GetButtonDown("Fire1"))//CAMBIAR TECLA A FIRE1
        {
            AttackPressedTimer = 2;
        }

        if(AttackPressedTimer > 0)
        {
            shouldCombo = true;
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    protected void Attack()
    {
        Debug.Log("Ataque iniciado");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controlDamage.position, radioDamage);

        foreach (Collider2D colisionador in objetos)
        {
            Debug.Log("Colisionando con " + colisionador.gameObject.name);
            if (colisionador.CompareTag("Enemy"))
            {
                colisionador.transform.GetComponent<Enemy>().TakeDamage(damage);
            }
        }

        /*
        Collider2D[] collidersToDamage = new Collider2D[10];
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = true;
        int colliderCount = Physics2D.OverlapCollider(hitCollider, filter, collidersToDamage);
        for(int i = 0; i < colliderCount; i++)
        {
            if (!collidersDamaged.Contains(collidersToDamage[i]))
            {
                TeamComponent hitTeamComponent = collidersToDamage[i].GetComponentInChildren<TeamComponent>();

                //Only check colliders with a valid Team Component attached
                if(hitTeamComponent && hitTeamComponent.teamIndex == TeamIndex.Enemy)
                {
                    //GameObject.Instantiate(HitEffectPrefab, collidersToDamage[i].transform);
                    Debug.Log("Enemy Has Taken:" + attackIndex + "Damage");
                    collidersDamaged.Add(collidersToDamage[i]);
                }
            }
        }
        */
    }

    
}
