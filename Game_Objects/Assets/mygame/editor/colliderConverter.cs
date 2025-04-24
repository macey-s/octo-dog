using UnityEngine;
using UnityEditor;
using System.IO;

public class ColliderConverter : EditorWindow
{
    string folderPath = "Assets/Prefabs";

    [MenuItem("Tools/Convert 3D Colliders to 2D")]
    public static void ShowWindow()
    {
        GetWindow<ColliderConverter>("Collider Converter");
    }

    void OnGUI()
    {
        GUILayout.Label("Batch Convert BoxColliders to BoxCollider2D", EditorStyles.boldLabel);
        folderPath = EditorGUILayout.TextField("Prefab Folder Path", folderPath);

        if (GUILayout.Button("Convert All Prefabs"))
        {
            ConvertColliders(folderPath);
        }
    }

    static void ConvertColliders(string folder)
    {
        string[] prefabGuids = AssetDatabase.FindAssets("t:Prefab", new[] { folder });

        foreach (string guid in prefabGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            GameObject instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;

            bool modified = false;

            foreach (var collider in instance.GetComponentsInChildren<BoxCollider>())
            {
                GameObject go = collider.gameObject;

                // Save collider settings
                Vector3 size = collider.size;
                Vector3 center = collider.center;

                DestroyImmediate(collider);
                BoxCollider2D newCol = go.AddComponent<BoxCollider2D>();
                newCol.size = new Vector2(size.x, size.y);
                newCol.offset = new Vector2(center.x, center.y);

                modified = true;
            }

            if (modified)
            {
                PrefabUtility.SaveAsPrefabAsset(instance, path);
                Debug.Log($"Updated prefab: {path}");
            }

            DestroyImmediate(instance);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Collider conversion complete!");
    }
}