[System.Serializable]
public sealed class PlayerInputZSerializer : ZSerializer.Internal.ZSerializer
{
    public UnityEngine.KeyCode forward;
    public UnityEngine.KeyCode back;
    public UnityEngine.KeyCode left;
    public UnityEngine.KeyCode right;
    public UnityEngine.KeyCode turnLeft;
    public UnityEngine.KeyCode turnRight;
    public System.Boolean sePuedeMover;
    public System.Boolean enemigosPuedenMover;
    public UnityEngine.GameObject camaraPlayer;
    public System.Single range;
    public System.Single rotationSpeed;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public PlayerInputZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         forward = (UnityEngine.KeyCode)typeof(PlayerInput).GetField("forward").GetValue(instance);
         back = (UnityEngine.KeyCode)typeof(PlayerInput).GetField("back").GetValue(instance);
         left = (UnityEngine.KeyCode)typeof(PlayerInput).GetField("left").GetValue(instance);
         right = (UnityEngine.KeyCode)typeof(PlayerInput).GetField("right").GetValue(instance);
         turnLeft = (UnityEngine.KeyCode)typeof(PlayerInput).GetField("turnLeft").GetValue(instance);
         turnRight = (UnityEngine.KeyCode)typeof(PlayerInput).GetField("turnRight").GetValue(instance);
         sePuedeMover = (System.Boolean)typeof(PlayerInput).GetField("sePuedeMover").GetValue(instance);
         enemigosPuedenMover = (System.Boolean)typeof(PlayerInput).GetField("enemigosPuedenMover").GetValue(instance);
         camaraPlayer = (UnityEngine.GameObject)typeof(PlayerInput).GetField("camaraPlayer").GetValue(instance);
         range = (System.Single)typeof(PlayerInput).GetField("range", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         rotationSpeed = (System.Single)typeof(PlayerInput).GetField("rotationSpeed", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(PlayerInput).GetField("forward").SetValue(component, forward);
         typeof(PlayerInput).GetField("back").SetValue(component, back);
         typeof(PlayerInput).GetField("left").SetValue(component, left);
         typeof(PlayerInput).GetField("right").SetValue(component, right);
         typeof(PlayerInput).GetField("turnLeft").SetValue(component, turnLeft);
         typeof(PlayerInput).GetField("turnRight").SetValue(component, turnRight);
         typeof(PlayerInput).GetField("sePuedeMover").SetValue(component, sePuedeMover);
         typeof(PlayerInput).GetField("enemigosPuedenMover").SetValue(component, enemigosPuedenMover);
         typeof(PlayerInput).GetField("camaraPlayer").SetValue(component, camaraPlayer);
         typeof(PlayerInput).GetField("range", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, range);
         typeof(PlayerInput).GetField("rotationSpeed", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, rotationSpeed);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}