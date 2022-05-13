using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public PlayerData playerData = PlayerData.data;

    private void Start()
    {
        Load();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        PlayerData.SaveData();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        PlayerData.LoadData();
    }
}
