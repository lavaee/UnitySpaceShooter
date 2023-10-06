using UnityEngine;

[CreateAssetMenu]
public class ShipStats : ScriptableObject
{
    public string Savepath;
    public int MaxHealth;
    public int DamageAmount;
    public int RateOfFire;
    public int MovementSpeed;
    public int BulletSpeed;
    public int Score;

    private void OnEnable()
    {
        PlayerPrefs.SetString(JsonUtility.ToJson(this), Savepath);
    }

    private void OnDisable()
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(Savepath), this);
    }
}
