using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSerialize : MonoBehaviour
{
    [SerializeField] ParticleSystem[] particles = null;
    [SerializeField] float keeptime = 3.0f;
    [SerializeField] float nextDelayMin = 0.1f;
    [SerializeField] float nextDelayMax = 0.3f;
    [SerializeField] bool m_autoHide = true;
    float startTime = 0f;
    Coroutine m_coroutine = null;

    public void Play()
    {
        Stop();
        gameObject.SetActive(true);
        startTime = Time.time;
        m_coroutine = StartCoroutine(EnumPlay());

        if (m_autoHide)
        {
            Invoke("Stop", keeptime);
        }
    }
    public IEnumerator EnumPlay()
    {
        float fDelay = nextDelayMin;
        int count = 0;
        while (count < particles.Length)
        {
            ParticleSystem kParticle = particles[count];
            kParticle.gameObject.SetActive(true);
            if (!kParticle.main.playOnAwake)
                kParticle.Play();
            count++;
            int min = (int)(nextDelayMin * 100);
            int max = (int)(nextDelayMax * 100);
            int value = Random.Range(min, max);
            fDelay = value * 0.01f;
            yield return new WaitForSeconds(fDelay);
        }
        yield return null;
    }
    public void Stop()
    {
        if (m_coroutine != null)
            StopCoroutine(m_coroutine);

        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Stop();
            particles[i].gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
