using UnityEngine;
using TMPro;
using Mohammad.Code;

public class AddNumber : MonoBehaviour
{
    public int[] number;
    public int[] code;
    [SerializeField] TextMeshProUGUI[] numberText;
    [SerializeField] GameObject prize;
    [SerializeField] GameObject puzzle;

    public void NumberAdder(int a)
    {
        number[a-1] = (number[a - 1]+1) % 10;
        numberText[a-1].text = number[a - 1].ToString();
        valueCheck();
    }
    private void valueCheck()
    {
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] != code[i])
                return;
        }
        prize.SetActive(true);
        puzzle.SetActive(false);   
    }
    public void prizeClick()
    {
        var sceneLoader = FindObjectsByType<SceneLoader>(FindObjectsSortMode.None)[0];
        sceneLoader.LoadSceneAsync("HappyBubbleScene");
        gameObject.SetActive(false);
    }

}
