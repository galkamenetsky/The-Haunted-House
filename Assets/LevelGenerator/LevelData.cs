using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class LevelData : ScriptableObject
{
    public string levelName;
    public LevelItem DoorInfo;
    public LevelItem KeyInfo;
    public LevelItem PlayerInfo;
    public LevelItem[] CoinsInfo;
    public PlatformItem[] PlatformsInfo;
    public LevelItem[] TrapsInfo;
}
[Serializable]
public class LevelItem
{
    public Vector3 position;
    public Quaternion rotation;
    public LevelItem(Vector3 position, Quaternion rotation)
    {
        this.position = position;
        this.rotation = rotation; 
    }
}
[Serializable]
public class PlatformItem : LevelItem
{
    public Vector3 size;
    public PlatformItem(Vector3 position, Quaternion rotation, Vector3 size) : base(position,rotation)
    {
        this.size = size;
    }
}
