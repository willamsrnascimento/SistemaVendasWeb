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
                string nomeImage = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{DateTime.Now.ToString("yyyyMMddhhmmss")}{Path.GetExtension(file.FileName)}"; 
                using(var fileStream = new FileStream(Path.Combine(imagensDiretorio, nomeImage), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    imagem.DataInclusao = DateTime.Now;
                    imagem.URL = "~/images/funcionario/" + nomeImage;
                }
            }
            return imagem;
        }
    }
}
