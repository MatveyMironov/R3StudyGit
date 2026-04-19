namespace CustomUISystem.Implementations
{
    public class GameObjectActiveSelfBoolDisplayerMB : ABoolDisplayerMB
    {
        public override void DisplayBool(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}