using UnityEngine;

public class JsonSavingSystem<T>
{
    public void Save(string key, T data)
    {
        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    public T Load(string key)
    {
        string json = PlayerPrefs.GetString(key);

        return JsonUtility.FromJson<T>(json);
    }

    public bool KeyIsNull(string key)
    {
        string json = PlayerPrefs.GetString(key);

        if (JsonUtility.FromJson<T>(json) == null)
            return true;

        return false;
    }
}
