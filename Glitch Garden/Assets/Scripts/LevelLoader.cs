using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelLoader : MonoBehaviour
{
    static LevelLoader instance = null;

    const float TIME_TO_WAIT = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            // Not the first one
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        SceneManager.activeSceneChanged += OnSceneWasChanged;
        SceneManager.sceneLoaded += OnSceneWasLoaded;

        SceneManager.LoadScene("SplashScreen");
    }

    /// <summary>
    /// Method is called when the scene is finished loading (not necessarily switched to)
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void OnSceneWasLoaded(Scene scene, LoadSceneMode mode)
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        if (activeSceneName == "SplashScreen")
        {
            StartCoroutine(InitialLoad("Title"));
            //LoadScene("Title");
        }
    }

    /// <summary>
    /// Method is called when switching scenes
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    void OnSceneWasChanged(Scene current, Scene next)
    {

    }

    IEnumerator InitialLoad(string name)
    {
        //GameObject.Find("Loading Music").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3);

        LoadScene(name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
