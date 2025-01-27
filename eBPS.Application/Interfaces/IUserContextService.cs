namespace eBPS.Application.Interfaces
{
    public interface IUserContextService
    {
        int GetUserId();
        int GetRoleId();
        int GetOrgId();
    }
}
