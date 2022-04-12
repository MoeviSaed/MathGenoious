using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Randomizer : MonoBehaviour
{
    string questionText;

    public Text text;
    int sumOrMinusQuestion()
    {
        int operand1 = Mathf.FloorToInt(Random.value * 100);
        int operand2 = Mathf.FloorToInt(Random.value * 100);

        int isMinusOrPlus = Mathf.FloorToInt(Random.value * 2);
       
        if (isMinusOrPlus == 0)
        {
            questionText = operand1 + "-" + operand2 + " = ? ";
            return (operand1 - operand2);
        }
        else
        {
            questionText = operand1 + "+" + operand2 + " = ? ";
            return (operand1 + operand2);
        }

    }

    int multiplyQuestion()
    {
        int operand1 = Mathf.FloorToInt(Random.value * 50);
        int operand2 = Random.Range(2, 10);
        questionText = operand1 + "*" + operand2 + " =? ";
        return (operand1 * operand2);
    }
    int multiOperandQuestion()
    {
        int operand1 = Mathf.FloorToInt(Random.value * 30);
        int operand2 = Mathf.FloorToInt(Random.value * 20);
        int operand3 = Random.Range(1, 10);
        int isMinusOrPlus = Mathf.FloorToInt(Random.value * 2);
        if (isMinusOrPlus == 0)
        {
            questionText = "(" + operand1 + "-" + operand2 + ")*" + operand3 + " = ?";
            return ((operand1 - operand2) * operand3);
        }
        else
        {
            questionText = "(" + operand1 + "+" + operand2 + ")*" + operand3 + " = ?";
            return ((operand1 + operand2) * operand3);
        }

    }
    int algebraicQuestion()
    {
        int answer = Mathf.FloorToInt(Random.value * 30);
        int operand1 = Random.Range(1, 10);
        int operand2 = Mathf.FloorToInt(Random.value * 80);
        int isMinusOrPlus = Mathf.FloorToInt(Random.value * 2);
        if (isMinusOrPlus == 0)
        {
            questionText = operand1 + "*x - " + operand2 + " = " + ((operand1 * answer) - operand2) + ". Find x.";
        }
        else
        {
            questionText = operand1 + "*x + " + operand2 + " = " + ((operand1 * answer) + operand2) + ". Find x.";
        }
        return answer;
    }

    List<int> answerChoices = new List<int>();
    int correctAnswerIndex;
    void RandomAnswerGenerator(int answer)
    {
        correctAnswerIndex = Mathf.FloorToInt(Random.value * 3);
        for (int i = 0; i < 3; i++)
        {
            if (i == correctAnswerIndex)
            { 
                answerChoices.Add(answer);
            }
            else
            {
                int newAnswer = -1;
                int randOpt = Mathf.FloorToInt(Random.value * 2); //Should we add or subtract the random number
                int randBase = Mathf.FloorToInt(Random.value * 5) + 1; //Plus 1 so it doesn't equal zero. Change the 5 to modify how much the generated answers will differ from the real answer
                if (randOpt == 0)
                { //Add
                    newAnswer = answer + randBase;
                }
                else
                { //Subtract
                    newAnswer = answer - randBase;
                }
                answerChoices.Add(newAnswer);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Questions();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            print(algebraicQuestion());
            text.text = questionText;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            multiOperandQuestion();
            text.text = questionText;
        }
    }
    void Questions()
    {
        sumOrMinusQuestion();
        text.text = questionText;
    }
}
