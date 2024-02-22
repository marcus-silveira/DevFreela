namespace DevFreela.Application.ViewModels;

public class CreateCommentInputModel
{
    public int IdProject { get; set; }
    public int IdUser { get; set; }
    public string Content { get; set; }
}