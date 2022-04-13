using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestionGenerator : MonoBehaviour, IQuestion
{
    protected float answer;
    protected string question;

    public void Initialize()
    {
        question = SumOrMinusQuestion();
    }

    public string GetString()
    {
        return question;
    }

    bool IQuestion.CheckAnswer(float answer)
    {
        return answer == this.answer;
    }

    public string SumOrMinusQuestion()
    {
        int operand1 = Mathf.FloorToInt(Random.value * 100);
        int operand2 = Mathf.FloorToInt(Random.value * 100);

        int isMinusOrPlus = Mathf.FloorToInt(Random.value * 2);

        if (isMinusOrPlus == 0)
        {
            answer = (operand1 - operand2);
            return question = operand1 + "-" + operand2 + " = ? ";
        }
        else
        {
            answer = (operand1 + operand2);
            return question = operand1 + "+" + operand2 + " = ? ";
        }

    }
}
