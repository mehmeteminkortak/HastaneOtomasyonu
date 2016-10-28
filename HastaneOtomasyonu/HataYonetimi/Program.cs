using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HataYonetimi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ad Soyad giriniz");
            string adSoyad = Console.ReadLine();
            DateTime dogumTarihi = new DateTime();

            do
            {
                try
                {
                    Console.WriteLine("Doğum Tarihinizi Giriniz");
                    dogumTarihi = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Doğum tarihi bilginiz alınamadı!");
                }
            } while (true);

            double boy = 0;
            do
            {
                try
                {
                    Console.WriteLine("Buyunuzu giriniz metre:");
                    string boyGiris = Console.ReadLine();
                    boy = double.Parse(boyGiris);
                    if (boy < 30 || boy > 275)
                        throw new Exception("Dev misin cüce misin karar ver!");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);

            Console.WriteLine("Ad Soyad: " + adSoyad);
            Console.WriteLine("Doğum Tarihi: " + dogumTarihi);
            Console.WriteLine("Boy: " + boy);



            Console.Read();
        }
    }
}
