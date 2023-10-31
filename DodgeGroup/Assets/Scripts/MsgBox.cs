using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MsgBox : MonoBehaviour
{
    public Button m_BtnYes = null;
    public Button m_BtnNo = null;
    private void Start()
    {
        gameObject.SetActive(false);
        m_BtnNo.onClick.AddListener(OnClick_No);
        m_BtnYes.onClick.AddListener(OnClick_Yes);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(true);
        }
    }
    public void OnClick_Yes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Test06");
    }
    public void OnClick_No()
    {
        gameObject.SetActive(false);
    }
}
