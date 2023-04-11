namespace Contracts.Model.Enterprise.Response;

public class MultipleFilesResponse
{
    public List<FileResponse> Files { get; set; }
    public bool isSuccesful { get; set; }
    public string Message { get; set; }
    public int TotalFiles { get; set; }
}