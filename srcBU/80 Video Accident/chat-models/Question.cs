namespace chat_models;

public class Question
{    
    public Question()
    {
        IsImage= false;
        UserName = "not defined";
        UserQuestion = "not defined";
        ImageMimeType = "not defined";
        FileBytes = null;
    }

    public bool IsImage { get; set; }
    public bool IsVideo { get; set; }
    public string ImageMimeType { get; set; }
    public byte[]? FileBytes { get; set; }
    public string UserName { get; set; }
    public string UserQuestion { get; set; }
        
    public override string ToString()
    {
        return $"User: {UserName}, Question: {UserQuestion}, HasImage: {IsImage}, Mime Type: {ImageMimeType}";         
    }

}
