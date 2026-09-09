using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AudioSource crashaudio;
    public AudioClip carcrash;
    public AudioSource bgmaudio;
    public AudioClip bgm;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        bgmaudio.clip = bgm;
        bgmaudio.loop = true;
        bgmaudio.Play();
    }
    public void OnPlayerHit()
    {
        Debug.Log("โดนของหล่นใส่! Game Over");
        crashaudio.PlayOneShot(carcrash);
        bgmaudio.Stop();
        Time.timeScale = 0f;
    }
}