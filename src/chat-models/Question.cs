namespace chat_models;

public class Question
{    
    public Question()
    {
        ImageUrl = "not defined";
        UserName = "not defined";
        UserQuestion = "not defined";
    }

    public string ImageUrl { get; set; }
    public string UserName { get; set; }
    public string UserQuestion { get; set; }
        
    public override string ToString()
    {
        return $"ImageUrl: {ImageUrl}, UserName: {UserName}, UserQuestion: {UserQuestion}";        
    }

}
