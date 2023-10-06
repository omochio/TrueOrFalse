using System;

public interface IQuestionService
{
    public int ExclCount { get; }
    public IObservable<int> ExclCountObservable { get; }
    public bool TextBool { get; }
    public bool CorrectAnswer { get; }
    public void ResetQuestion();
    public void Answer(bool answer);
    public void Skip();
}