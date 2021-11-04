using UnityEngine;

namespace _02.Scripts.Stats {
	[CreateAssetMenu(fileName = "PlayerStats", menuName = "Game/PlayerStats", order = 0)]
	public class PlayerStats: ScriptableObject {
		public Vector2 position;
		public float stressMeter;
	}
}