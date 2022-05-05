namespace ArticleBZ.Server.Repositories
{
    public interface IUserRepository
    {

        public bool IsUserExsit(Shared.DTOs.LoginVM login);

    }
}
