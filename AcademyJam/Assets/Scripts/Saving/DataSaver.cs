using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Saving
{
    public class DataSaver : MonoBehaviour
    {
        public SavedData savedData = new();
        private const string FILE_NAME = "/Player.dat";

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            Load();
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.buildIndex > savedData.LevelPart)
            {
                savedData.LevelPart = scene.buildIndex;
                Save();
            }
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void Save()
        {
            FileStream file = new FileStream(Application.persistentDataPath
                                             + FILE_NAME, FileMode.OpenOrCreate);

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(file, savedData);

            file.Close();
        }

        private void Load()
        {
            try
            {
                FileStream file = new FileStream(Application.persistentDataPath
                                                 + FILE_NAME, FileMode.Open);

                BinaryFormatter binaryFormatter = new BinaryFormatter();

                savedData = (SavedData)binaryFormatter.Deserialize(file);

                file.Close();
            }
            catch (Exception e)
            {
            }
        }

        public void ClearInfo()
        {
            try
            {
                string path = Application.persistentDataPath + FILE_NAME;

                using (FileStream fs = new FileStream(path, FileMode.Truncate))
                {
                }

                savedData = new();
            }
            catch (Exception e)
            {
            }
        }
    }
}