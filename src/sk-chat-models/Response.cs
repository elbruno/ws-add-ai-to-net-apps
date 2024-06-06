namespace sk_chat_models;

public class Response
{
    // contructor that initialize the properties with default values
    public Response()
    {   
        Author = "not defined";
        QuestionResponse = "not defined";
    }

    public string Author { get; set; }
    public string QuestionResponse { get; set; }
}
