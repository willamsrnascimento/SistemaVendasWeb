using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SistemaVendasWeb.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Util
{
    public static class ImagemUtil
    {
        public async static Task<Imagem> ProcessaImagem(IFormFile file, IWebHostEnvironment webHostEnvironment)
        {
            var imagensDiretorio = Path.Combine(webHostEnvironment.WebRootPath, "images\\funcionario");
            Imagem imagem = new Imagem();

            if (file != null)
            {              
                string nomeImage = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{Guid.NewGuid().ToString()}_{DateTime.Now.ToString("yyyyMMddhhmmss")}{Path.GetExtension(file.FileName)}";
                imagem.Nome = Path.GetFileNameWithoutExtension(file.FileName);
                imagem.NomeGuia = nomeImage;

                using (var fileStream = new FileStream(Path.Combine(imagensDiretorio, nomeImage), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    imagem.DataInclusao = DateTime.Now;
                    imagem.URL = "~/images/funcionario/" + nomeImage;
                }
            }
            else
            {
                imagem.DataInclusao = DateTime.Now;
                imagem.URL = "~/images/funcionario/default.png";
            }

            return imagem;
        }

        public static void ExcluirImagem(Imagem imagem, IWebHostEnvironment webHostEnvironment)
        {
            var imagemDiretorio = Path.Combine(webHostEnvironment.WebRootPath, "images\\funcionario");
            var caminhoComNome = Path.Combine(imagemDiretorio, imagem.NomeGuia);

            if (File.Exists(caminhoComNome))
            {
                File.Delete(caminhoComNome);
            }
        }

        public static Imagem CriaImagem(IFormFile file)
        {
            Imagem imagem = new Imagem();

            if (file != null)
            {
                string nomeImage = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{Guid.NewGuid().ToString()}_{DateTime.Now.ToString("yyyyMMddhhmmss")}{Path.GetExtension(file.FileName)}";
                imagem.Nome = Path.GetFileNameWithoutExtension(file.FileName);
                imagem.NomeGuia = nomeImage;
                imagem.DataInclusao = DateTime.Now;
                imagem.URL = "~/images/funcionario/" + nomeImage;
                
            }
            return imagem;
        }
    }
}
