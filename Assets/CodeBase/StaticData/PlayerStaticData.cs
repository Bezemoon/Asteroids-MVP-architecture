using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "StaticData/PlayerData", order = 0)]
    public class PlayerStaticData : ScriptableObject
    {
        [Header("Ship Health Config")]
        [Range(1, 10)] public int Health = 5;

        [Header("Ship Rotation Config")] 
        [Range(180, 360)] public float MaxAngleRotation = 360f;
        [Range(200, 500)] public float SpeedRotation = 350f;

        [Header("Ship Movement Config")] 
        [Range(10, 30)] public float Acceleration = 20f;
        [Range(10, 30)] public float Inertia = 10f;
        public Vector2 SpeedRange = new Vector2(0, 10f);

        public GameObject Prefab;
    }
}