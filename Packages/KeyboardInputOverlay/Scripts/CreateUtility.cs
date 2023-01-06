using System;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;


public static class CreateUtility
{
    
    [MenuItem("GameObject/Keyboard Input Overlay/Mouse")]
    public static void CreateKeyBoardMouse(MenuCommand menuCommand)
    {
        GameObject newObject = CreatePrefab("KeyBoardInputOverlay - Mouse");
        Debug.LogWarning("Note: You must attach the Keyboard to a Canvas.", newObject);
    }
    
    [MenuItem("GameObject/Keyboard Input Overlay/Keyboard - QWERTZ")]
    public static void CreateKeyBoardQWERTZ(MenuCommand menuCommand)
    {
        GameObject newObject = CreatePrefab("KeyBoardInputOverlay - QWERTZ");
        Debug.LogWarning("Note: You must attach the Keyboard to a Canvas.", newObject);
    }
    
    [MenuItem("GameObject/Keyboard Input Overlay/Keyboard - QWERTY")]
    public static void CreateKeyBoardQWERTY(MenuCommand menuCommand)
    {
        GameObject newObject = CreatePrefab("KeyBoardInputOverlay - QWERTY");
        Debug.LogWarning("Note: You must attach the Keyboard to a Canvas.", newObject);
    }

    private static GameObject CreatePrefab(string path)
    {
        GameObject newObject = PrefabUtility.InstantiatePrefab(Resources.Load(path)) as GameObject;
        Place(newObject);
        PrefabUtility.UnpackPrefabInstance(newObject, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
        return newObject;
    }

    private static GameObject CreateObject(string name, params Type[] types)
    {
        GameObject newObject = ObjectFactory.CreateGameObject(name, types);
        Place(newObject);
        return newObject;
    }

    private static void Place(GameObject gameObject)
    {
        Debug.Log("Creating: " + AssetDatabase.GetAssetPath(gameObject));

        // Find location
        SceneView lastView = SceneView.lastActiveSceneView;
        gameObject.transform.position = lastView ? lastView.pivot : Vector3.zero;

        // Make sure we place the object in the proper scene, with a relevant name
        StageUtility.PlaceGameObjectInCurrentStage(gameObject);
        GameObjectUtility.EnsureUniqueNameForSibling(gameObject);

        // Record undo, and select
        Undo.RegisterCreatedObjectUndo(gameObject, $"Create Object: {gameObject.name}");
        Selection.activeGameObject = gameObject;

        // For prefabs, let's mark the scene as dirty for saving
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}