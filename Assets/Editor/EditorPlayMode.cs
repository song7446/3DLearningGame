using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public static class EditorPlayMode
{
    static EditorPlayMode()
    {
        EditorApplication.playModeStateChanged += OnChangedState;
    }

    private static void OnChangedState(PlayModeStateChange playMode)
    {
        switch (playMode)
        {
            case PlayModeStateChange.EnteredEditMode:
                {
                    string prePath = EditorPrefs.GetString("PrevScencePath");

                    if (string.IsNullOrEmpty(prePath))
                        return;

                    EditorSceneManager.OpenScene(prePath);

                    EditorPrefs.DeleteKey("PrevScenePath");
                }
                break;
            case PlayModeStateChange.ExitingEditMode:
                {
                    if (EditorSceneManager.GetActiveScene().buildIndex >= 0)
                    {

                        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                        {
                            EditorPrefs.SetString("PrevScencePath", EditorSceneManager.GetActiveScene().path);

                            // 빌드 세팅의 첫번째 씬 로드 
                            EditorSceneManager.OpenScene(EditorBuildSettings.scenes[0].path);

                            return;
                        }

                        EditorApplication.isPlaying = false;
                    }
                }
                break;
            case PlayModeStateChange.EnteredPlayMode:
                {

                }
                break;
            case PlayModeStateChange.ExitingPlayMode:
                {

                }
                break;
            default:
                break;

        }
    }
}
