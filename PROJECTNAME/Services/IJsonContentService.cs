namespace PROJECTNAME.Services
{
    public interface IJsonContentService
    {
        Task<T?> LoadAsync<T>(string path);
    }
}