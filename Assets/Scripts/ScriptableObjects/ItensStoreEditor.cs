using UnityEditor;

[CustomEditor(typeof(ItensStore))]
public class ItensStoreEditor : Editor
{
    #region SerializeProperties
    SerializedProperty itemName;
    SerializedProperty itemDescription;
    SerializedProperty itemValue;
    SerializedProperty alteraAgua;
    SerializedProperty alteraComida;
    SerializedProperty alteraComidaFixo;
    SerializedProperty alteraAguaFixo;
    SerializedProperty alteraComidaPorcentagem;
    SerializedProperty alteraAguaPorcentagem;
    SerializedProperty alteraVelocidadeBarraComidaSegundos;
    SerializedProperty alteraVelocidadeBarraComidaPorcentagem;
    SerializedProperty alteraVelocidadeBarraAguaSegundos;
    SerializedProperty alteraVelocidadeBarraAguaPorcentagem;
    SerializedProperty alteraConsumoComidaFixo;
    SerializedProperty alteraConsumoComidaPorcentagem;
    SerializedProperty alteraConsumoAguaFixo;
    SerializedProperty alteraConsumoAguaPorcentagem;
    #endregion
    
    void OnEnable()
    {
        itemName = serializedObject.FindProperty("itemName");
        itemDescription = serializedObject.FindProperty("itemDescription");
        itemValue = serializedObject.FindProperty("itemValue");
        alteraAgua = serializedObject.FindProperty("alteraAgua");
        alteraComida = serializedObject.FindProperty("alteraComida");
        alteraComidaFixo = serializedObject.FindProperty("alteraComidaFixo");
        alteraAguaFixo = serializedObject.FindProperty("alteraAguaFixo");
        alteraComidaPorcentagem = serializedObject.FindProperty("alteraComidaPorcentagem");
        alteraAguaPorcentagem = serializedObject.FindProperty("alteraAguaPorcentagem");
        alteraVelocidadeBarraComidaSegundos = serializedObject.FindProperty("alteraVelocidadeBarraComidaSegundos");
        alteraVelocidadeBarraComidaPorcentagem = serializedObject.FindProperty("alteraVelocidadeBarraComidaPorcentagem");
        alteraVelocidadeBarraAguaSegundos = serializedObject.FindProperty("alteraVelocidadeBarraAguaSegundos");
        alteraVelocidadeBarraAguaPorcentagem = serializedObject.FindProperty("alteraVelocidadeBarraAguaPorcentagem");
        alteraConsumoComidaFixo = serializedObject.FindProperty("alteraConsumoComidaFixo");
        alteraConsumoComidaPorcentagem = serializedObject.FindProperty("alteraConsumoComidaPorcentagem");
        alteraConsumoAguaFixo = serializedObject.FindProperty("alteraConsumoAguaFixo");
        alteraConsumoAguaPorcentagem = serializedObject.FindProperty("alteraConsumoAguaPorcentagem");
    }

    public override void OnInspectorGUI()
    {
        ItensStore _itensStore = (ItensStore)target;

        serializedObject.Update();

        EditorGUILayout.PropertyField(itemName);
        EditorGUILayout.PropertyField(itemDescription);
        EditorGUILayout.PropertyField(itemValue);
        EditorGUILayout.PropertyField(alteraAgua);
        EditorGUILayout.PropertyField(alteraComida);
        if (_itensStore.alteraAgua)
        {
            EditorGUILayout.PropertyField(alteraAguaFixo);
            EditorGUILayout.PropertyField(alteraAguaPorcentagem);
            EditorGUILayout.PropertyField(alteraVelocidadeBarraAguaSegundos);
            EditorGUILayout.PropertyField(alteraVelocidadeBarraAguaPorcentagem);
            EditorGUILayout.PropertyField(alteraConsumoAguaFixo);
            EditorGUILayout.PropertyField(alteraConsumoAguaPorcentagem);
        }
        if (_itensStore.alteraComida)
        {
            EditorGUILayout.PropertyField(alteraComidaFixo);
            EditorGUILayout.PropertyField(alteraComidaPorcentagem);
            EditorGUILayout.PropertyField(alteraVelocidadeBarraComidaSegundos);
            EditorGUILayout.PropertyField(alteraVelocidadeBarraComidaPorcentagem);
            EditorGUILayout.PropertyField(alteraConsumoComidaFixo);
            EditorGUILayout.PropertyField(alteraConsumoComidaPorcentagem);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
