using Gnexx.Services.Users;

namespace Gnexx.Services.Helper
{
    public sealed class SingletonRepository
    {
        public static SingletonRepository Instance { get; } = new SingletonRepository();

        public SaveUserVM client = new();

        public string origin = string.Empty;

        private SingletonRepository()
        { }

    }
}
