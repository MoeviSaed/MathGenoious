public interface IQuestion
{
    void Initialize();
    string GetString();
    bool CheckAnswer(float answer);
}
