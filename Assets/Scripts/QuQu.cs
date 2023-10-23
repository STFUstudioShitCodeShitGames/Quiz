using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz", fileName = "questions")]
public class QuQu : ScriptableObject
{
    public TextAsset TextAsset;
    public Chud Chudat;

    [ContextMenu("Parse")]
    public void Shmarts()
    {
        Chudat = JsonUtility.FromJson<Chud>(TextAsset.text);
    }

    [Serializable]
    public class Chud
    {
        public Shumka[] questions;
    }
    
    [Serializable]
    public class Shumka
    {
        public string question;
        public string[] options;
        public string correct_answer;
    }
}