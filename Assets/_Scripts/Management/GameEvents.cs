using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    // . . for accessing GameEvents
    public static GameEvents current;
    [SerializeField] private WelcomeActivation welcomeScript;


    // . . events

    // . . start the game
    public event Action onStartGame;


    // . . Starting and ending fights
    public event Action OnFightZoneTriggerEnter;
    public event Action OnFightZoneTriggerExit;


    // . . Level Complete event
    public event Action onLevelComplete;
    public event Action onLevelEndingTriggerExit;


    // . . player failed
    public event Action onGameOver;


    // . . we need this for checkgameover
    private RadialFormation _formation;

    #region Public Static
    private void Awake()
    {
        current = this;
    }
    #endregion


    private void OnEnable() {
        _formation = ObjectPooler.Instance.formation;
        PauseGame();
        onStartGame += ResumeGame;
        onGameOver += PauseGameWithDelay;
    }

    // . . checking game over or not every frame
    private void Update() {
        CheckGameOver();
    }


    public void StartGame() {
        onStartGame.Invoke();
    }

    private void CheckGameOver() {
        if (_formation._amount <= 0) {
            GameOver();
        }
    }

    public void GameOver() {
        onGameOver.Invoke();
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void PauseGame() {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    private void PauseGameWithDelay() {
        StartCoroutine(PauseGameRoutine());
    }

    #region coroutine
    private IEnumerator PauseGameRoutine() {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 0;
    }
    #endregion

    public void RestartCurrentLevel() {
        // . . used in retry button
        welcomeScript.setRestarted();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel() {
        welcomeScript.setNotRestarted();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FightZoneTriggerEnter()
    {
        OnFightZoneTriggerEnter?.Invoke();
    }

    public void FightZoneTriggerExit()
    {
        OnFightZoneTriggerExit?.Invoke();
    }

    public void LevelComplete() {
        onLevelComplete.Invoke();
    }

    public void LevelEndingTriggerExit() {
        onLevelEndingTriggerExit.Invoke();
    }
}
