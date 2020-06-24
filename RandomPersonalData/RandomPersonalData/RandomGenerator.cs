using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPersonalData
{
    public class RandomGenerator
    {
        public static string RandomFirstName(Random random)
        {
            random = new Random();
            var Fnames = new string[] {"Maria","Erik","Anna","Lars","Margareta","Karl","Elisabeth","Anders","Nilsson",
                                      "Eva",  "Kristina", "Per", "Larsson", "Birgitta",  "Nils", "Karin",  "Carl", "Johan",
                  "Persson","Marie","Mikael","Svensson","Elisabet","Jan","Ingrid","Hans","Christina","Peter","Sofia",
                  "Olof","Linné","Lennart","Kerstin","Gunnar","Len", "Sven", "Helena"," Fredrik" ," Marianne"," Daniel" ,"Emma",
                " Bengt"," Linnea"," Bo"," Johanna", "Alexander"," Inger", "Gustav"," Sara",
                  "Göran"," Cecilia"," Åke" ,"ElinMagnus"," Anita"," Martin", "Louise"," Andreas"," Ida"," Stefan","Ulla" };
            var index = random.Next(Fnames.Length);
            string randomfirstname = Fnames[index];
            return randomfirstname;
        
        }
        public static string RandomLastName(Random random)
        {
            random = new Random();

            var Lnames = new string[]
            {"Andersson","Johansson","Karlsson","Nilsson","Eriksson","Larsson","Olsson","Persson","Svensson",
                "Gustafsson","Pettersson","Jonsson","Jansson","Hansson", "Bengtsson","Jönsson","Lindberg",
                "Jakobsson","Magnusson","Olofsson","Lindström","Lindqvist", "Axelsson","Berg","Bergström",
                "Lundberg","Lind","Lundgren","Lundqvist","Mattsson", "Berglund","Fredriksson","Sandberg",
                "Henriksson","Forsberg","Sjöberg","Wallin","Ali","Engström","Mohamed","Eklund","Danielsson","Lundin",
                "Håkansson","Björk","Bergman","Gunnarsson","Holm","Wikström","Samuelsson","Isaksson","Fransson",
                 "Bergqvist","Nyström","Holmberg","Arvidsson","Löfgren","Söderberg","Nyberg","Blomqvist",
            };
            var index = random.Next(Lnames.Length);
            string lastname = Lnames[index];
            return lastname;
        }
        public static string RandomSSN(Random random)
        {
            random = new Random();

            string year = random.Next(1920, 2020).ToString();
            string month = random.Next(1, 12).ToString();
            if(Convert.ToInt32(month)<10)
            {
                month = "0" + month;
            }
            string day = random.Next(1, 30).ToString();
            if(Convert.ToInt32(day)<10)
            {
                day = "0" + day;
            }
            string Birthdate = year + month + day;
            int lastfourdigits = random.Next(1111, 9999);
            string Lastfourdigits = lastfourdigits.ToString();
            if(Lastfourdigits.Length<4)
            {
                Lastfourdigits = "0" + Lastfourdigits;
            }
            string ssn = Birthdate + "-" + Lastfourdigits;
            
            return ssn;

        }
        public  static int Randomsymptomlevel(Random random)
        {
            random = new Random();
            int symptomlevel = random.Next(1, 11);
            return symptomlevel;
        }

    }
}
