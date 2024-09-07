using Microsoft.AspNetCore.Identity;

namespace LocadoraDeAutomoveis.Dominio.ModuloAutenticacao
{
    public class Usuario : IdentityUser<int>
    {
        public Usuario()
        {
            EmailConfirmed = true;
        }
    }
}