using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortFotos
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
=======
            Console.WriteLine("Gestor de imagens");
            Console.WriteLine("Caminho para a pasta das fotos:");
            CaminhoDaFoto = Console.ReadLine();

            if (Directory.Exists(CaminhoDaFoto))
            {
                ObterInfoDoDirectorio();
            }
            Console.WriteLine("Feito.");
            Console.ReadLine();
        }

        private static void ObterInfoDoDirectorio()
        {
            InfoDirectorio = new DirectoryInfo(CaminhoDaFoto);
            Console.WriteLine("Número de ficheiros: {0}", InfoDirectorio.GetFiles().Length);

            foreach (var photo in InfoDirectorio.GetFiles())
            {
                FotoActual = photo.FullName;

                if (photo.Extension.ToLower() == ".jpg")
                {
                    ProcessaImagem(photo);
                }
            }
        }

        private static void ProcessaImagem(FileInfo foto)
        {
            DateTime DataDaFoto = ObterDataDeCaptura(foto);

            CriaPasta(DataDaFoto);

        }

        private static void CriaPasta(DateTime dataDaFoto)
        {
            var nome = $"{dataDaFoto.Year}-{dataDaFoto.Month:D2}-{dataDaFoto.Day:D2}";
            var destino = Path.Combine(CaminhoDaFoto, nome);

            if (!Directory.Exists(destino))
            {
                //Move photo
                Directory.CreateDirectory(destino);
                Console.WriteLine(destino);
            }
            Console.WriteLine("A mover foto {0} para a directoria {1}", FotoActual, destino);
            File.Move(FotoActual, Path.Combine(destino, Path.GetFileName(FotoActual)));

        }

        private static DateTime ObterDataDeCaptura(FileInfo foto)
        {
            Console.WriteLine("A processar: {0}", foto.FullName);
            using (FileStream filestream = new FileStream(foto.FullName, FileMode.Open, FileAccess.Read))
            using (Image imagem = Image.FromStream(filestream, false, false))
            {
                PropertyItem propriedade = null;
                try
                {
                    propriedade = imagem.GetPropertyItem(36867);

                }
                catch (Exception)
                {
                    Console.WriteLine("Sem dados.");                    
                }

                if (propriedade!=null)
                {
                    string dataDeCaptura = Regex.Replace(Encoding.UTF8.GetString(propriedade.Value), "-", 2);
                    return DateTime.Parse(dataDeCaptura);
                }
                else
                {
                return DateTime.MinValue;
                }
            }
>>>>>>> 3f3cbb1e3b1e8fd759ae2fbeaefb3aee0ed20995
        }
    }
}
