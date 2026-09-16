using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AudioSource crashaudio;
    public AudioClip carcrash;
    public AudioSource bgmaudio;
    public AudioClip bgm;
    public GameObject fxFire;
    public GameObject fxSmoke;
    public GameObject fxExplosive;
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
        fxFire.SetActive(true);
        fxSmoke.SetActive(true);
        fxExplosive.SetActive(true);
        Time.timeScale = 0f;
    }
}