namespace chat_models;

public class Question
{    
    public Question()
    {
        UserName = "not defined";
        UserQuestion = "not defined";
    }

    public string UserName { get; set; }
    public string UserQuestion { get; set; }
        
    public override string ToString()
    {
        return $"UserName: {UserName}, UserQuestion: {UserQuestion}";
    }

}
