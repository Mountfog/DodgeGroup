using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test06Dlg : MonoBehaviour
{
    public List<Button> m_buttons = new List<Button>();

    private void Start()
    {
        for(int i=0; i<m_buttons.Count; i++)
        {
            int idx = i;
            m_buttons[i].onClick.AddListener(()=>OnClick_SceneOpen(idx));
        }
    }
    public void OnClick_SceneOpen(int idx)
    {
        SceneManager.LoadScene(idx);
    }
    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Test06");
        }
    }

}
