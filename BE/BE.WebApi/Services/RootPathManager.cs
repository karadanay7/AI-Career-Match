using BE.Application.Common.Interfaces;

namespace BE.WebApi.Services
{
    public class RootPathManager : IRootPathService
    {
        private readonly string _rootPath;

        public RootPathManager(string rootPath)
        {
            _rootPath = rootPath;
        }
        public string GetRootPath() => _rootPath;

    }
}
