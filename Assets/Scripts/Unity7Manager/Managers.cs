using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(Timer))] // Add this line to require Timer component

public class Managers : MonoBehaviour {
	public static PlayerManager Player {get; private set;}
	public static InventoryManager Inventory {get; private set;}
	public static Timer Timer {get; private set;} // Add reference to Timer script

	private List<IGameManager> startSequence;
	
	void Awake() {
		Player = GetComponent<PlayerManager>();
		Inventory = GetComponent<InventoryManager>();
		Timer = GetComponent<Timer>(); // Assign reference to Timer component

		startSequence = new List<IGameManager>();
		startSequence.Add(Player);
		startSequence.Add(Inventory);

		StartCoroutine(StartupManagers());
	}

	private IEnumerator StartupManagers() {
		foreach (IGameManager manager in startSequence) {
			manager.Startup();
		}

		yield return null;

		int numModules = startSequence.Count;
		int numReady = 0;

		while (numReady < numModules) {
			int lastReady = numReady;
			numReady = 0;

			foreach (IGameManager manager in startSequence) {
				if (manager.status == ManagerStatus.Started) {
					numReady++;
				}
			}

			if (numReady > lastReady)
				Debug.Log($"Progress: {numReady}/{numModules}");
			
			yield return null;
		}
		
		Debug.Log("All managers started up");

		// Start the timer when all managers are initialized
        Timer.StartTimer();
	}
}
