using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Reference")]
    [SerializeField] private GameObject redHood;
    [SerializeField] private GameObject wolf;
    public AudioSource backgroundMusic;
    public AudioClip[] stageMusic;

    [Header("Stage")]
    [SerializeField] private int currentStage = -1;
    [SerializeField] private Transform[] stageCheckPoint;

    [Header("Game Requirement")]
    public bool FirstKey {get; set; }

    private void Awake()
    {
        Instance = this;   
    }

    void Start(){
        backgroundMusic.clip = stageMusic[0];
        backgroundMusic.Play();
    }

    public void NextStage()
    {
        currentStage++;
        redHood.transform.position = stageCheckPoint[currentStage].position;
        wolf.transform.position = stageCheckPoint[currentStage].position;

        if (currentStage < stageMusic.Length) 
        {
            backgroundMusic.clip = stageMusic[currentStage + 1];
            backgroundMusic.Play();
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
