using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo
{
    public class ActorInfo
    {
        private int currentHP = 100;
        private int maxHP = 100;
        
        public void HPDamaged(int kDamage)
        {
            currentHP -= kDamage;
            if(currentHP < 0 )
                currentHP = 0;
            GameMgr.Inst.gameScene.m_hudUI.playerHPUI.ChangedHP();
        }
        public void HpHealed(int kheal)
        {
            currentHP += kheal;
            if(currentHP > maxHP)
            {
                currentHP = maxHP;
            }
            GameMgr.Inst.gameScene.m_hudUI.playerHPUI.ChangedHP();
        }
        public void Initalize(int kHP)
        {
            currentHP = kHP;
            maxHP = kHP;
        }
        public float HPAmount()
        {
            return (float)currentHP / (float) maxHP;
        }
        public bool IsDead()
        {
            return currentHP <= 0;
        }
        public int curHP
        {
            get { return currentHP; }
        }
    }
    
    private int m_curstage = 1;
    private float fireDelayTime = 0;
    private float bulletAttack = 0;
    private float bulletSpeed = 0;
    private float itemAppearDelay = 0;
    private int turretcount = 0;
    //스테이지 
    private float curKeepTime = 0;
    private float keepTime = 0;

    private int stageScore = 0;
    private int score = 0;
    private int totalScore = 0;
    
    public AssetStage curAssetStage = null;
    public ActorInfo actorInfo = null;

    public void Initialize()
    {
        if (GameMgr.Inst.sinfo.lastStage != 0)
        {
            m_curstage = GameMgr.Inst.sinfo.lastStage;
        }
        else
        {
            m_curstage = 1;
        }
        curAssetStage = AssetMgr.Inst.GetAssetStage(m_curstage);
        fireDelayTime = curAssetStage.fireDelayTime;
        bulletAttack = curAssetStage.bulletAttack;
        bulletSpeed = curAssetStage.bulletSpeed;
        itemAppearDelay = curAssetStage.itemAppearDelay;
        turretcount = curAssetStage.TurretCount;
        keepTime = curAssetStage.keepTime;
        curKeepTime = 0;
        actorInfo = new ActorInfo();
        actorInfo.Initalize(curAssetStage.playerHp);
    }
    public void SetStage(int kstage)
    {
        m_curstage = kstage;
    }
    public int GetCurrentStage()
    {
        return m_curstage;
    }
    public void GotoNextStage()
    {
        int curstage = GetCurrentStage();
        SetStage(curstage+1);
    }
    public void OnUpdate(float fElapsdTime)
    {
        curKeepTime += fElapsdTime;

        if( curKeepTime >= keepTime)
        {
            GameMgr.Inst.gameScene.m_battleFSM.SetResultState();
        }
    }
    public float TimeAmount()
    {
        return curKeepTime / keepTime;
    }
    public float m_curKeepTime
    {
        get
        {
            return keepTime - curKeepTime;
        }
    }
    public float m_survivedTime
    {
        get { return curKeepTime; }
    }
    public float m_keepTime
    {
        get { return keepTime; }
    }

    public float CurCalculateScore()
    {
        SaveInfo kSaveInfo = GameMgr.Inst.sinfo;
        float score = kSaveInfo.CalculateScore(m_curstage, keepTime, actorInfo.curHP);
        return score;

     
    }
}
