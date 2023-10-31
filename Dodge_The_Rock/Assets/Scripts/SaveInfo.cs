using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.IO;

public class Stage
{
    public int idx;
    public int score;
    public void SetScore(int ktime, int curHp)
    {
        score = ktime * 10 + curHp * 5;
    }
}

public class SaveInfo
{
    public int m_highScore = 0;
    public int totalScore = 0;
    public int lastStage = 0;
    public List<Stage> stages = new List<Stage>();

    public void Initialize()
    {
        if(stages.Count == 0)
            stages.Add(new Stage());
        stages.Add(new Stage());
    }
    public void DeleteAll()
    {
        File.Delete("saveinfo.data");
        stages.Clear();
    }
    
    public void SaveData()
    {
        FileStream fs = new FileStream("saveinfo.data",FileMode.OpenOrCreate,FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Flush();
        int ncount = stages.Count;
        m_highScore = 0; totalScore = 0;
        lastStage = ncount;
        CalculateHighScore();
        bw.Write(m_highScore);
        bw.Write(totalScore);
        bw.Write(lastStage);
        bw.Write(ncount);
        for (int i = 0; i < ncount; i++)
        {
            bw.Write(stages[i].idx);
            bw.Write(stages[i].score);
        }
        bw.Close();
        fs.Close();
    }
    void CalculateHighScore()
    {
        for (int i = 0; i < stages.Count; i++)
        {
            totalScore += stages[i].score;
            if (m_highScore < stages[i].score)
            {
                m_highScore = stages[i].score;
            }
        }
    }
    public void LoadData()
    {
        try
        {
            FileStream fs = new FileStream("saveinfo.data", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            m_highScore = br.ReadInt32();
            totalScore = br.ReadInt32();
            lastStage = br.ReadInt32();
            int ncount = br.ReadInt32();
            stages.Clear();

            for (int i = 0; i < ncount; i++)
            {
                Stage st = new Stage();
                st.idx = br.ReadInt32();
                st.score = br.ReadInt32();
                stages.Add(st);
            }
            br.Close();
            fs.Close();
        }
        catch(Exception e)
        {
            Debug.LogException(e);
            Debug.Log("파일없음,게임초기화");
        }
    }

    public Stage GetStage(int iStage)
    {
        if( iStage > 0 && iStage <= stages.Count )
        {
            return stages[iStage-1];
        }
        return null;
    }
    public int CalculateScore(int stage, float keepTime, int curHp)
    {
        var kStage = GetStage(stage);
        if( kStage != null )
        {
            kStage.SetScore((int)keepTime, curHp);
            totalScore += kStage.score;
            return kStage.score;
        }
        return 0;
    }
    public int GetHighScore()
    {
        int highScore = 0;
        foreach( Stage st in stages )
        {
            if(highScore == 0)
            {
                highScore = st.score;
            }
            else if(highScore < st.score)
            {
                highScore = st.score;
            }
        }
        return highScore;
    }
    //public int CurCalculateScore()
    //{
    //    int stage = GameMgr.Inst.ginfo.GetCurrentStage();
    //    float keeptime = GameMgr.Inst.ginfo.m_keepTime;
    //    int curhp = GameMgr.Inst.ginfo.actorInfo.curHP;
    //    stages[stage - 1].SetScore((int)keeptime, curhp);
    //    totalScore += stages[stage - 1].score;
    //    return stages[stage - 1].score;
    //}

}
