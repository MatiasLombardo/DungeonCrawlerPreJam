[System.Serializable]
public sealed class EnemyMovementZSerializer : ZSerializer.Internal.ZSerializer
{
    public UnityEngine.Camera cam;
    public UnityEngine.Transform[] waypoints;
    public System.Boolean usaWaypoints;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public EnemyMovementZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         cam = (UnityEngine.Camera)typeof(EnemyMovement).GetField("cam").GetValue(instance);
         waypoints = (UnityEngine.Transform[])typeof(EnemyMovement).GetField("waypoints").GetValue(instance);
         usaWaypoints = (System.Boolean)typeof(EnemyMovement).GetField("usaWaypoints").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(EnemyMovement).GetField("cam").SetValue(component, cam);
         typeof(EnemyMovement).GetField("waypoints").SetValue(component, waypoints);
         typeof(EnemyMovement).GetField("usaWaypoints").SetValue(component, usaWaypoints);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}