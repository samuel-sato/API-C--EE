using System.Text.RegularExpressions;

namespace DesafioAPI.Model
{
    public static class Ferramenta
    {
        public static bool ValidaCPF(string cpf)
        {
            if (cpf.Length == 11 && Regex.IsMatch(cpf, @"^[0-9]+$"))
            {
                int aux = 0;
                int x;
                for (int i = 0; i < 9; i++)
                {
                    x = cpf[i] - '0';
                    aux += (x * (10 - i));
                }

                int resto = (aux % 11);

                if ((11 - resto) != (cpf[9]-'0')) { return false; }

                aux = 0;
                for (int i = 0; i < 10; i++)
                {
                    aux += ((cpf[i]-'0') * (11 - i));
                }

                resto = (aux % 11);
                if ((11 - resto) != (cpf[10] - '0')) 
                    return false; 
                else 
                    return true; 
            }
            else
                return false;
        }
        
        public static bool ValidaIdade(DateTime date)
        {
            //idade deve ser maior que 18 anos
            var ano = DateTime.Now.Year - date.Year;
            var mes = DateTime.Now.Month - date.Month;
            var dia = DateTime.Now.Day - date.Day;

            Console.WriteLine($"Idade {dia} {mes} {ano}");

            if (ano >=18)
            {
                if(ano == 18)
                {
                    if( mes >= 0 && dia >= 0)
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }

            return false;
        }

        public static bool ValidaSexo(string sexo)
        {
            var aux = sexo.ToUpper();
            if(aux == "M" || aux == "F")
            {
                return true;
            }

            return false;
        }

        
    }
}
