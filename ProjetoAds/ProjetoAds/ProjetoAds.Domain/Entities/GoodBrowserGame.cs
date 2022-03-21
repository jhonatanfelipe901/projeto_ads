using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Domain.Entities
{
    public class GoodBrowserGame : BaseEntity
    {
        public long UserIdAdministrador { get; set; }
        public long IdCategoria { get; set; }
        public string Descricao { get; set; }
        public string UrlJogo { get; set; }
        public string UrlVideoDemonstracao { get; set; }
        public string UrlImagemIlustrativa { get; set; }

        public GoodBrowserGame()
        {

        }

        private GoodBrowserGame(
            long userIdAdministrador, long idCategoria, 
            string descricao, string urlJogo, 
            string urlVideoDemonstracao, string urlImagemIlustrativa)
        {
            UserIdAdministrador = userIdAdministrador;
            IdCategoria = idCategoria;
            Descricao = descricao;
            UrlJogo = urlJogo;
            UrlVideoDemonstracao = urlVideoDemonstracao;
            UrlImagemIlustrativa = urlImagemIlustrativa;
        }

        public static GoodBrowserGame CreateInstance(
            long userIdAdministrador, long idCategoria, 
            string descricao, string urlJogo, 
            string urlVideoDemonstracao, string urlImagemIlustrativa)
        {
            return new GoodBrowserGame(userIdAdministrador, idCategoria, descricao, urlJogo, urlVideoDemonstracao, urlImagemIlustrativa);
        }
    }
}
