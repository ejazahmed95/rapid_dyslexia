using _02.Scripts.Stats;
using Activity;
using EAUtils;
using UnityEngine;
using UnityEngine.Events;

public class StatsController: MonoBehaviour {
	[SerializeField] private float stressMeter = 0f;
	[SerializeField] private PlayerStats _currentStats;
	[SerializeField] private MentalStatus _mentalStatus = MentalStatus.normal;

	public UnityEvent<float> _onStressUpdate = new UnityEvent<float>();
	
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

	public float GetStressMeter(){
		return stressMeter;
	}
	
	public MentalStatus GetMentalStatus() {
		Log.e("Stats Controller", $"Getting the mental status as {_mentalStatus}");
		return _mentalStatus;
	}

	public void UpdateStress(float newStress) {
		stressMeter = Mathf.Clamp(newStress, 0, 100);

		if (stressMeter < 10) {
			_mentalStatus = MentalStatus.normal;
		} else if (stressMeter < 30) {
			_mentalStatus = MentalStatus.worrying;
		} else if (stressMeter < 50) {
			_mentalStatus = MentalStatus.pain;
		} else if (stressMeter <= 100) {
			_mentalStatus = MentalStatus.breakdown;
		}
		
		_onStressUpdate.Invoke(stressMeter);
	}
}