using UnityEngine;
using UnityEngine.UI;

//This class has a custom GUI draw call. It can be found at the class ConditionalHide. 
public class AddLoadBehaviourToButton : MonoBehaviour
{
    private Button ThisButton = null;

    public bool AddRestartScene = false;
    public bool AddLoadScene = false;
    public string SceneName = null;


    // Start is called before the first frame update
    void Awake()
    {
        ThisButton = GetComponent<Button>();

        if (AddRestartScene)
        {
            ThisButton.onClick.AddListener(() => LevelLoader.instance.RestartCurrentScene());
        }

        else if (AddLoadScene)
        {
            ThisButton.onClick.AddListener(() => LevelLoader.instance.LoadScene(SceneName));
        }
    }
}
