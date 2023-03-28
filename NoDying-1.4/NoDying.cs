using Modding;

namespace NoDying;

public class NoDying : Mod, ITogglableMod
{
    public override string GetVersion() => "1.0.0.0";
    
    public override void Initialize() => ModHooks.Instance.TakeHealthHook += DontAllowDying; 
    public void Unload() => ModHooks.Instance.TakeHealthHook -= DontAllowDying;
    private static int DontAllowDying(int damage) => PlayerData.instance.health - damage <= 0 ? 0 : damage;
}