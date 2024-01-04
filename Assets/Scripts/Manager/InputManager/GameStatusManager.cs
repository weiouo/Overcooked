using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatusManager : MonoBehaviour
{
    [SerializeField] private GamePanelController panelController;
    private void Start()
    {
        GameInitialize();
    }
    public void GameInitialize()
    {
        panelController.ShowReadyGoPanel();
        Time.timeScale = 1f;
    }
    public void GameStart()
    {
        panelController.ShowGamePanel();
        Time.timeScale = 1f;
    }
    public void GameTimesUp()
    {
        panelController.ShowTimesUpPanel();
    }
    public void GameEnd()
    {
        panelController.ShowEndPanel();
        Time.timeScale = 0f;
    }
    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void GameTutorialOn()
    {
        panelController.ShowTutorialPanel();
        Time.timeScale = 0f;
    }
    public void GameTutorialOff()
    {
        panelController.HideTutorialPanel();
        Time.timeScale = 1f;
    }
}
