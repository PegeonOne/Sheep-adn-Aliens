using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogoAbilitiesMenu : MonoBehaviour
{
    public List<RectTransform> AbilitiesButtons;
    Vector2 startPosition;
    Vector2[] targetPositions;
    bool isBegin;
    int id = 0;

    private void Start()
    {
        transform.gameObject.SetActive(false);
        startPosition = new Vector2(0, 0);
        targetPositions = new Vector2[5]{
            new Vector2(0, 90),
            new Vector2(90, 0),
            new Vector2(60, -90),
            new Vector2(-60, -90),
            new Vector2(-90, 0)
        };
    }
    private void OnEnable()
    {
        isBegin = true;
        id = 0;
    }
    private void OnDisable()
    {
        isBegin = false;
        foreach (RectTransform pos in AbilitiesButtons)
        {
            pos.localPosition = startPosition;
        }
    }
    private void Update()
    {
        if (isBegin && id != 5)
        {
            MenuAnim();
        }
    }

    void MenuAnim()
    {
        AbilitiesButtons[id].localPosition = Vector2.MoveTowards(AbilitiesButtons[id].localPosition, targetPositions[id], 1000 * Time.deltaTime);
            /*for (float i = 0; i <= 1; i = i + 0.01f)
            {
                pos.localPosition = Vector2.Lerp(startPosition, targetPositions[id], i * Time.deltaTime);
            }
            Debug.Log("Finish: " + pos.gameObject.name);
            */
        if (Vector2.Distance(AbilitiesButtons[id].localPosition, targetPositions[id]) <= 0)
        {
            id++;
        }           
    }
}
