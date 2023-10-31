using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.IO;

public class SaveInfo
{
    public int highScore = 0;
    public int accumulateScore = 0;
    public int lastStage = 0;
    public List<Stage> m_stage = new List<Stage>();


    public void Initialize()
    {
        if(m_stage.Count == 0)
        {
            m_stage.Add(new Stage());
        }
        m_stage.Add(new Stage());
        //1이 끝났는데 stage가 2개있으므로 세이브할 때 lastStage가 2로 저장됨

    }
    public void DeleteAll()
    {
        File.Delete("saveinfo.data");
        m_stage.Clear();
    }
    public void SaveFile()
    {

        FileStream fs = new FileStream("saveinfo.data", FileMode.OpenOrCreate, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Flush();
        int ncount = m_stage.Count;
        if (GameMgr.Inst.ginfo.actorInfo.IsDead())
        {
            ncount -= 1;
            m_stage.RemoveAt(m_stage.Count - 1);
        }
        highScore = 0; accumulateScore = 0; 
        lastStage = ncount;
        for (int i = 0; i < ncount; i++)
        {
            accumulateScore += m_stage[i].score;
            if (highScore < m_stage[i].score)
            {
                highScore = m_stage[i].score;
            }
        }
        bw.Write(highScore);
        bw.Write(accumulateScore);
        bw.Write(lastStage);
        bw.Write(ncount);
        for (int i = 0; i < ncount; i++)
        {
            bw.Write(m_stage[i].idx);
            bw.Write(m_stage[i].score);
        }
        bw.Close();
        fs.Close();
    }
    public void LoadFile()
    {
        try
        {
            FileStream fs = new FileStream("saveinfo.data", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            highScore = br.ReadInt32();
            accumulateScore = br.ReadInt32();
            lastStage = br.ReadInt32();
            int ncount = br.ReadInt32();
            m_stage.Clear();

            for (int i = 0; i < ncount; i++)
            {
                Stage st = new Stage();
                st.idx = br.ReadInt32();
                st.score = br.ReadInt32();
                m_stage.Add(st);
            }
            br.Close();
            fs.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }
    public int accScore
    {
        get
        {
            return accumulateScore;
        }
    }
    public int CurCalculateScore()
    {
        int stage = GameMgr.Inst.ginfo.GetCurrentStage();
        float keeptime = GameMgr.Inst.ginfo.m_keepTime;
        int curhp = GameMgr.Inst.ginfo.actorInfo.curHP;
        m_stage[stage - 1].SetScore((int)keeptime, curhp);
        accumulateScore += m_stage[stage - 1].score;
        return m_stage[stage - 1].score;
    }
}

public class Stage
{
    public int idx=0;
    public int score=0;
    public void SetScore(int ktime, int curhp)
    {
        score = ktime * 10 + curhp * 5;
    }
}
