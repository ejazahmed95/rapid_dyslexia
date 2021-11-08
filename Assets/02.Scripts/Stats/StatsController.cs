using _02.Scripts.Stats;
using Activity;
using EAUtils;
using UnityEngine;

public class StatsController: MonoBehaviour {
	[SerializeField] private float stressMeter = 0f;
	[SerializeField] private PlayerStats _currentStats;
	[SerializeField] private MentalStatus _mentalStatus = MentalStatus.normal;

	private static StatsController instance = null;
	#region MonoBehaviour Methods
	private void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
			DI.Register(instance);
			UpdateStress(DI.Get<StatsController>().stressMeter);
		} else if (instance != this) {
			Destroy(this);
		}
	}
	#endregion

	private void Start() {
		
	}

	public void UpdateActivityScore(ActivityType type, float performance) {
		
	}
	
	public MentalStatus GetMentalStatus() {
		Log.e("Stats Controller", $"Getting the mental status as {_mentalStatus}");
		return _mentalStatus;
	}

	public void UpdateStress(float newStress) {
		stressMeter = newStress;

		if (stressMeter < 10) {
			_mentalStatus = MentalStatus.normal;
		} else if (stressMeter < 40) {
			_mentalStatus = MentalStatus.worrying;
		} else if (stressMeter < 70) {
			_mentalStatus = MentalStatus.pain;
		} else if (stressMeter <= 100) {
			_mentalStatus = MentalStatus.breakdown;
		}
	}
}