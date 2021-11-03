
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/Game", order = 0)]
public class GameSettings: ScriptableObject {
	public string mainCharacterName = "Alex";
	public LanguageType languageType = LanguageType.English;
}

public enum LanguageType {
	English,
	Mandarin,
}