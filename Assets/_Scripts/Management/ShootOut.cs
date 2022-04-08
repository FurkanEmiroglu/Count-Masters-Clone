using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootOut : MonoBehaviour
{
    private FriendlyArmy friendlyArmy;
    private EnemyArmy enemyArmy;
    private RadialFormation friendlyFormation;
    private RadialFormation enemyFormation;
    private GameObject enemyMain;
    private GameObject area;
    [SerializeField] bool isLast;



    // Start is called before the first frame update
    void Start() {
        friendlyFormation = ObjectPooler.Instance.formation;
        friendlyArmy = ObjectPooler.Instance.friendlyArmy;
        enemyFormation = ObjectPooler.Instance.enemyFormation;
        enemyArmy = ObjectPooler.Instance.enemyArmy;
        enemyMain = ObjectPooler.Instance.EnemyMain;
        area = ObjectPooler.Instance.area;

        // Subscriptions
        GameEvents.current.OnFightZoneTriggerEnter += startDyingAnimations;
    }

    void startDyingAnimations() {
        StartCoroutine(setDyingAnimationTriggers());
    }

    IEnumerator setDyingAnimationTriggers() {
        yield return new WaitForSecondsRealtime(1.15f);
        int lessAmount = Mathf.Min(enemyFormation._amount, friendlyFormation._amount);

        for (int i = 0; i < lessAmount; i++) {
            yield return new WaitForSecondsRealtime(0.4f);
            var friendlyUnit = friendlyArmy.spawnedUnits.ElementAt(i);
            var enemyUnit = enemyArmy.spawnedUnits.ElementAt(i);
            friendlyUnit.GetComponent<AnimationStateController>().setDyingTrigger();
            enemyUnit.GetComponent<EnemyAnimations>().setDyingTrigger();
        }

        if (friendlyFormation._amount > enemyFormation._amount) {
            yield return new WaitForSecondsRealtime(1f);
            friendlyFormation._amount -= enemyFormation._amount;
            enemyFormation._amount = 0;
        }
        else if (enemyFormation._amount > friendlyFormation._amount) {
            yield return new WaitForSecondsRealtime(1f);
            friendlyFormation._amount = 0;
        }
        else {
            yield return new WaitForSecondsRealtime(1f);
            friendlyFormation._amount = 0;
            enemyFormation._amount = 0;
        }

        if (isLast) {
            if (friendlyFormation._amount > 0) {
                GameEvents.current.LevelComplete();
            } 
            else {
                GameEvents.current.GameOver();
                // ToDo bir şeyler patlarsa bunu aşağıya ekle.
                //GameEvents.current.FightZoneTriggerExit();
            }
        }
        else if (!isLast) {
            if (friendlyFormation._amount > 0) {
                GameEvents.current.FightZoneTriggerExit();
            }
            else {
                GameEvents.current.GameOver();
                //ToDo bir şeyler patlarsa bunu aşağıya ekle.
                //GameEvents.current.FightZoneTriggerExit();
            }
        }
    }

    public void setIsLastTrue() {
        isLast = true;
    }


    // setting new fight zone for further shootouts.
    public void setNewArea(float distance, int amount) {
        area.transform.position = new Vector3
            (area.transform.position.x,area.transform.position.y, area.transform.position.z + distance);
        enemyFormation._amount = amount;
    }
}
