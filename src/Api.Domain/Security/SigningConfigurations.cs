using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Api.Domain.Security
{
    public class SigningConfigurations
    {
        // esse tipo de atributo é uma classe que vem no pacote instalado jwt 
        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }

        public SigningConfigurations()
        {
            //2048 é o tamanho em bits
            /*using fecha as conexões e descarta as variáveis depois que a função é encerrada.
             * logo a variável 'provider' é descartada ao sair do using
            */
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);


        }


    }
}
