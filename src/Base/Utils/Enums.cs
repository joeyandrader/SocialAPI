namespace RedeSocialAPI.src.Base.Utils
{
    /// <summary>
    /// Account type access
    /// </summary>
    public enum AccountType : int
    {
        Comum,
        Administrador
    }

    /// <summary>
    /// Return code api response
    /// </summary>
    public enum EnResultCode : int
    {
        Success = 0,
        Erro = 1
    }
}