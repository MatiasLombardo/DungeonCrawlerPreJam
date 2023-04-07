[System.Serializable]
public sealed class PlayerControllerZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Boolean smoothTransition;
    public System.Single transitionSpeed;
    public System.Single transitionRotationSpeed;
    public UnityEngine.Vector3 targetGridPos;
    public UnityEngine.Vector3 targetRotation;
    public System.Boolean playerIsMoving;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public PlayerControllerZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         smoothTransition = (System.Boolean)typeof(PlayerController).GetField("smoothTransition").GetValue(instance);
         transitionSpeed = (System.Single)typeof(PlayerController).GetField("transitionSpeed").GetValue(instance);
         transitionRotationSpeed = (System.Single)typeof(PlayerController).GetField("transitionRotationSpeed").GetValue(instance);
         targetGridPos = (UnityEngine.Vector3)typeof(PlayerController).GetField("targetGridPos").GetValue(instance);
         targetRotation = (UnityEngine.Vector3)typeof(PlayerController).GetField("targetRotation").GetValue(instance);
         playerIsMoving = (System.Boolean)typeof(PlayerController).GetField("playerIsMoving").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(PlayerController).GetField("smoothTransition").SetValue(component, smoothTransition);
         typeof(PlayerController).GetField("transitionSpeed").SetValue(component, transitionSpeed);
         typeof(PlayerController).GetField("transitionRotationSpeed").SetValue(component, transitionRotationSpeed);
         typeof(PlayerController).GetField("targetGridPos").SetValue(component, targetGridPos);
         typeof(PlayerController).GetField("targetRotation").SetValue(component, targetRotation);
         typeof(PlayerController).GetField("playerIsMoving").SetValue(component, playerIsMoving);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}