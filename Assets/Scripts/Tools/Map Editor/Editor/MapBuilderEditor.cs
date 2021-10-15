using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapBuilder))]
public class MapBuilderEditor : Editor
{
    MapBuilder targ;

    SerializedProperty mapSize;
    SerializedProperty towerTileLayer;
    SerializedProperty tileStructure;
    SerializedProperty tileEnemyPath;
    SerializedProperty tileSpawn;
    SerializedProperty tileEnd;
    SerializedProperty tileOffset;
    SerializedProperty pathOrder;

    void OnEnable()
    {
        targ = (MapBuilder)base.target;

        mapSize = serializedObject.FindProperty("mapSize");
        towerTileLayer = serializedObject.FindProperty("towerTileLayer");
        tileStructure = serializedObject.FindProperty("tileStructure");
        tileEnemyPath = serializedObject.FindProperty("tileEnemyPath");
        tileSpawn = serializedObject.FindProperty("tileSpawn");
        tileEnd = serializedObject.FindProperty("tileEnd");
        tileOffset = serializedObject.FindProperty("tileOffset");
        pathOrder = serializedObject.FindProperty("pathOrder");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(mapSize);
        if (GUILayout.Button("Set Size"))
        {
            targ.map = new int[targ.mapSize, targ.mapSize];
        }

        EditorGUILayout.PropertyField(towerTileLayer);
        EditorGUILayout.PropertyField(tileStructure);
        EditorGUILayout.PropertyField(tileEnemyPath);
        EditorGUILayout.PropertyField(tileSpawn);
        EditorGUILayout.PropertyField(tileEnd);
        EditorGUILayout.PropertyField(tileOffset);
        
        
 
        EditorGUILayout.LabelField("Grey = Tower Space\nBlue = Enemy Path\nRed = Enemy Spawn\nGreen = Enemy End", GUILayout.Height(70));
        EditorGUILayout.LabelField("0,0 -->");
        EditorGUILayout.BeginHorizontal();
        for (int x = 0; x < targ.map.GetLength(0); x++)
        {
            EditorGUILayout.BeginVertical();

            for (int y = 0; y < targ.map.GetLength(1); y++)
            {
                
                GUI.backgroundColor = (targ.map[x, y] == 1) ? Color.blue : (targ.map[x, y] == 2) ? Color.red : (targ.map[x, y] == 3) ? Color.green : Color.grey;
                if(GUILayout.Button(string.Format("({1}, {2})", targ.map[x, y], x, y)))
                {
                    targ.map[x, y] = (targ.map[x, y] < 3) ? targ.map[x, y] + 1 : 0;
                    if(targ.map[x, y] == 1) { targ.pathOrder.Add(new Vector2(x, y)); }
                    else { targ.RemoveFromPathOrder(x, y); }
                }
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("Reset"))
        {
            targ.ClearMap();
        }

        EditorGUILayout.PropertyField(pathOrder);
        serializedObject.ApplyModifiedProperties();

        GUI.backgroundColor = Color.grey;
        if (GUILayout.Button("Build"))
        {
            targ.BuildMap();
        }


    }
}
