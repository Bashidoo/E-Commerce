using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    public class Menu<T>
    {
        private Store<T> _store;
        public Menu(Store<T> store)
        {
            _store = store;
        }

        public void ShowMenu()
        {
            bool running = true;
            char choice = Convert.ToChar(Console.ReadKey());

            while (true)
            {
                switch (choice)
                {
                    case '1':

                        break;
                    case '2':

                        break;
                    case '3':

                        break;
                    case '4':

                        break;
                    case '5':

                        break;
                    case '6':

                        break;
                    case '7':

                        break;
                    case '8':

                        break;
                    case '9':

                        break;
                }

            }
        }

        public void AskForInfoToAddProductOBJ()
        {


        }
    }
}
