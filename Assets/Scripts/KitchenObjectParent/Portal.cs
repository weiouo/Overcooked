using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : BaseCounter
{
    [SerializeField] private string levelName; 
    public override void Interact(Player player)
    {
        SceneManager.LoadScene(levelName);
    }
}
