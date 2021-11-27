using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class GSN_SaveSystem


{

    public static void SavePlayer (GSN_Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.stats";
        FileStream stream = new FileStream(path, FileMode.Create);

        GSN_PlayerData data = new GSN_PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static GSN_PlayerData LoadPlayer ()

    {
        string path = Application.persistentDataPath + "/player.stats";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GSN_PlayerData data = formatter.Deserialize(stream) as GSN_PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        } 
    }
        


}
