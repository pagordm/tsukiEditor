using OdinSerializer;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


    public class TsukiSave
    {
    //CastleSave starts here
    [OdinSerialize]
    public Int32 language;
    [OdinSerialize]
    public Int32 cloudSaveID;
    [OdinSerialize]
    public bool cloudDisabled;
    [OdinSerialize]
    public bool cloudSavedBefore;
    [OdinSerialize]
    public double lastCloudSaveOA;
    [OdinSerialize]
    public double firstSaved;
    [OdinSerialize]
    public double lastSaved;
    [OdinSerialize]
    public float musicVolume;
    [OdinSerialize]
    public float sfxVolume;
    [OdinSerialize]
    public bool minimalSFX;
    [OdinSerialize]
    public Int32 notificationsStatus;
    [OdinSerialize]
    public Int32 lastSavedVersion;
    [OdinSerialize]
    public Int64 lastCloudSavedProgress;
    [OdinSerialize]
    public bool hasLastKnownLegitTime;
    [OdinSerialize]
    public bool bypassBackup;
    [OdinSerialize]
    public double lastLegitTimeOA;

    //TsukiSave starts here
    [OdinSerialize]
    public Int32 location;
    [OdinSerialize]
    public Int32 tutorials;
    [OdinSerialize]
    public double gameStartOA;
    [OdinSerialize]
    public Int32 carrots;

    [OdinSerialize]
    public List<NPCSave> npcSaves;
    [OdinSerialize]
    public ItemInventory items;
    [OdinSerialize]
    public List<DiarySave> diarySaves;
    [OdinSerialize]
    public List<SublocationSave> sublocationSaves;
    [OdinSerialize]
    public Punchcard punchcard;
    [OdinSerialize]
    public Int32[] lastPunchcardFurniture;
    [OdinSerialize]
    public Int32 punchcardsClaimed;
    [OdinSerialize]
    public Int32 carrotsSpent;
    [OdinSerialize]
    public Int32 carrotsEarned;
    [OdinSerialize]
    public Int32 carrotsGiven;
    [OdinSerialize]
    public Int32 carrotsBought;
    [OdinSerialize]
    public Int32 furnitureBought;
    [OdinSerialize]
    public Int32 furnitureSold;
    [OdinSerialize]
    public Int32 itemsBought;
    [OdinSerialize]
    public Int32 itemsSold;
    [OdinSerialize]
    public Int32 fishCaught;
    [OdinSerialize]
    public Int32 unluckiness;
    [OdinSerialize]
    public Int32 gachaRolled;
    [OdinSerialize]
    public Int32 newspapersRead;
    [OdinSerialize]
    public bool conserveBattery;
    [OdinSerialize]
    public bool reduceMotion;
    [OdinSerialize]
    public List<LocationLock> locationsOnPhone;
    [OdinSerialize]
    public Int32 tutorialStep;
    [OdinSerialize]
    public PhoneSave phoneSave;

}

public class FurnitureSave
{
    [OdinSerialize]
    public double placedOA;
}

public class SimpleGrid
{
    //Do we need to serialize Static fields? Seems not
    [OdinSerialize]
    public int x;
    [OdinSerialize]
    public int y;
}

public class GridPointer
{
    [OdinSerialize]
    public PointerType pointerType;
    [OdinSerialize]
    public SimpleGrid grid;
    [OdinSerialize]
    public Int32 groupPointer;

    public enum PointerType
    {
        Room,
        Placement,
        Invalid
    }
}

public class FurnitureRef
{
    [OdinSerialize]
    public Int32 id;
    [OdinSerialize]
    public Int32 orientation;
}
[Serializable]
public class WallGroupPosition : IGroupPosition
{
    [OdinSerialize]
    public SimpleGrid grid;
    [OdinSerialize]
    public Int32 groupNum;
    [OdinSerialize]
    public bool flipped;
}


public interface IGroupPosition
{

}

public class FurniturePlacement
{
    [OdinSerialize]
    public Int32 placementID;
    [OdinSerialize]
    public FurnitureRef reference;
    [OdinSerialize]
    public IGroupPosition groupPosition;
    [OdinSerialize]
    public GridPointer position;
    [OdinSerialize]
    public FurnitureSave furnSave;
}
public class WallPlacement
{
    [OdinSerialize]
    public Int32 placementID;
    [OdinSerialize]
    public Int32 furnitureID;
    [OdinSerialize]
    public GridPointer position;
    [OdinSerialize]
    public WallGroupPosition groupPosition;
    [OdinSerialize]
    public FurnitureSave furnSave;
}

public class PlacementSave
{
    [OdinSerialize]
    public Dictionary<int, FurniturePlacement> furniture;
    [OdinSerialize]
    public Dictionary<int, WallPlacement> wallFurniture;
    [OdinSerialize]
    public Dictionary<int, int> wallpapers;
    [OdinSerialize]
    public Dictionary<int, int> floors;
}
public class AnchorData
{
    [OdinSerialize]
    public Int32 anchorID;
    [OdinSerialize]
    public Int32 furnitureID;
}

public class SLocationID
{
    [OdinSerialize]
    public Int32 sublocationID;
    [OdinSerialize]
    public Int32 localLocationID;
}

public class BaseRoomSave
{
    [OdinSerialize]
    public SLocationID locationID;
    [OdinSerialize]
    public List<FurniturePlacement> furniturePlacements;
    [OdinSerialize]
    public AnchorData[] wallpaperAnchors;
    [OdinSerialize]
    public AnchorData[] floorAnchors;
    [OdinSerialize]
    public List<WallPlacement> wallPlacements;
}

public class SceneObjectSave
{
    [OdinSerialize]
    public Int32 objectID;
}

public class SublocationSave : PlacementSave
{
    [OdinSerialize]
    public Int32 currSLocData;
    [OdinSerialize]
    public Int32 slocation;
    [OdinSerialize]
    public BaseRoomSave roomSave;
    [OdinSerialize]
    public List<SceneObjectSave> sceneObjectSaves;
    [OdinSerialize]
    public Int32 version;
    [OdinSerialize]
    public BaseActivitySave tsukiActivity;
    [OdinSerialize]
    public bool dictionaryUpgrade;
    [OdinSerialize]
    public bool anchorsUpgrade;
    [OdinSerialize]
    public Dictionary<int, FurnitureSave> extraFurnitureSaves;
}

public class DiarySave
{
    [OdinSerialize]
    public Int32 num;
    [OdinSerialize]
    public Int32 diaryArchievedOA;
    [OdinSerialize]
    public bool night;
    [OdinSerialize]
    public Int32 state;
}

public class BaseInventory
{
    public virtual int Size { get; }

    public enum InvType
    {
        ITEM,
        FURN
    }
}

public class ItemInventory : BaseInventory
{
    // BaseInventory_Fields:
    //   1. Inventory_ItemInventorySlot_Fields: super
    // Inventory_ItemInventorySlot_Fields:
    //   1. Inventory_Fields: super
    //   2. List<T>: slots - we assume the type is ItemInventorySlot based on extracted save files
    // Inventory_Fields: (empty)
    List<ItemInventorySlot> slots;

    List<ItemInventorySlot> hiddenItems;
}
public class ItemInventorySlot
{
    [OdinSerialize]
    public Int32 ID;
    [OdinSerialize]
    public Int32 quantity;
    [OdinSerialize]
    public Int32 invType;
    [OdinSerialize]
    public double lastModified;
    [OdinSerialize]
    public ISlotSave slotSave;
}

public interface ISlotSave
{

}

public class NPCSave
{
    [OdinSerialize]
    public Int32 character;
    //TODO: Check if BaseActivitySave is enough to serialize and import save
    [OdinSerialize]
    public BaseActivitySave activitySave; //This can also be FurnitureBoundActivitySave, maybe something else? 
    
    [OdinSerialize]
    public double lastTalkOA;
    [OdinSerialize]
    public Int32 friendship;
    [OdinSerialize]
    public Int32 lastFriendshipDay;
    [OdinSerialize]
    public List<TempValue> tempValues;
    [OdinSerialize]
    public Trip trip;
}
public class BaseActivitySave
{
    [OdinSerialize]
    public Int32 ActivityID;
    [OdinSerialize]
    public Int32 NpcID;
    [OdinSerialize]
    public double ActivityStart;
    [OdinSerialize]
    public bool Valid;
    [OdinSerialize]
    public bool Seen;
    [OdinSerialize]
    public Int32 Pester;
}
public class TempValue
{
    [OdinSerialize]
    public Int32 day;
    [OdinSerialize]
    public String ID;
    [OdinSerialize]
    public Int32 value;
}

public class Trip
{
    [OdinSerialize]
    public Int32 start;
    [OdinSerialize]
    public Int32 end;
    [OdinSerialize]
    public Int32 trainDay;
    [OdinSerialize]
    public Int32 trainNumber;
    [OdinSerialize]
    public bool tripStarted;
    [OdinSerialize]
    public bool tripEnded;
}
