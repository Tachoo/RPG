using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class Player_CustomEditor : Editor {

    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }
    private void OnDestroy()
    {

    }

    public override void OnInspectorGUI()
    {
        Player Player = target as Player;

        //base.OnInspectorGUI();
        //
        #region Espacio en blanco
        EditorGUILayout.LabelField(" ");
        #endregion
        //
        #region Vida y Recurso Primario
        EditorGUILayout.LabelField("Vida y Recuso Primario");
        //
        #region Espacio en blanco
        EditorGUILayout.LabelField(" ");
        #endregion
        //
        Player.PuntosDeVida = EditorGUILayout.IntField(" Puntos de vida : ", Player.PuntosDeVida);
        Player.PuntosDeVida = EditorGUILayout.IntField(" Recurso Primario : ", Player.PuntosDeVida);
        #endregion
        
        #region Estadisticas del jugador
        //
        #region Espacio en blanco
        EditorGUILayout.LabelField(" ");
        #endregion
        //
        
        EditorGUILayout.LabelField("Estadisticas Primarias");
        //
        #region Espacio en blanco
        EditorGUILayout.LabelField(" ");
        #endregion
        //
        Player.Fuerza = EditorGUILayout.IntField(" Puntos de Fuerza : ", Player.Fuerza);
        Player.Destreza = EditorGUILayout.IntField(" Puntos de Destreza : ", Player.Destreza);
        Player.Inteligencia = EditorGUILayout.IntField(" Puntos de Inteligencia : ", Player.Inteligencia);
        Player.Fe = EditorGUILayout.IntField(" Puntos de Fe : ", Player.Fe);
        #endregion
        //
        #region Espacio en blanco
        EditorGUILayout.LabelField(" ");
        #endregion
        //
        EditorGUILayout.LabelField("Estadisticas Secundarias");
        //
        #region Espacio en blanco
        EditorGUILayout.LabelField(" ");
        #endregion
        //
        Player.Resistencia_Fisica = EditorGUILayout.IntField("Armadura : ", Player.Resistencia_Fisica);
        Player.Resistencia_Magica = EditorGUILayout.IntField("Resistencia Magica : ", Player.Resistencia_Magica);

        Player.Resistencia_Fuego = EditorGUILayout.IntField("Resistencia Fuego : ", Player.Resistencia_Fuego);
        Player.Resistencia_Agua = EditorGUILayout.IntField("Resistencia Agua : ", Player.Resistencia_Agua);
        Player.Resistencia_Hielo = EditorGUILayout.IntField("Resistencia Hielo : ", Player.Resistencia_Hielo);
        Player.Resistencia_Tierra = EditorGUILayout.IntField("Resistencia Tierra : ", Player.Resistencia_Tierra);
        Player.Resistencia_Viento = EditorGUILayout.IntField("Resistencia Viento : ", Player.Resistencia_Viento);
        Player.Resistencia_Relampago = EditorGUILayout.IntField("Resistencia Rayo : ", Player.Resistencia_Relampago);
        //
        #region Espacio en blanco
        EditorGUILayout.LabelField(" ");
        #endregion
        //
        EditorGUILayout.LabelField("Vida");
        //
        #region Espacio en blanco
        EditorGUILayout.LabelField(" ");
        #endregion
        //
        Player.Resistencia_Fisica = EditorGUILayout.IntField("Armadura : ", Player.Resistencia_Fisica);
    }
}
